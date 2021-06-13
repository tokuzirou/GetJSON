using System;
using System.Collections.Generic;

namespace GetJSON
{
    internal class InputData : InputDataBase
    {
        internal InputData(){ }

        internal override JSON Input()
        {
            //[課題]_loopFlagをConfirmクラス内部のプロパティにしたい
            //区切り文字
            char[] delimiters = { ' ', ',', '.', '/', '\\', '*', ':', ';' };
            //フラグ
            bool _loopFlag = true;
            while (_loopFlag)
            {
                Console.WriteLine("空白区切りでデータを入力してください。");
                Console.Write("データ: ");
                string readLine = Console.ReadLine();
                sb.Append(readLine + ' ');

                //データ入力を終了するかどうか確認
                _loopFlag = _confirm.ConfirmData(_loopFlag, "続けてデータを入力しますか？");
            }

            //入力文字列の最後の空白を削除
            sb.Remove(sb.Length - 1, 1);

            //入力文字配列に' '区切りで追加
            words = new List<string>(sb.ToString().Split(delimiters));

            //入力文字列の前後空白対策
            for(int i = 0; i < words.Count; i++)
            {
                //空白処理
                words[i] = words[i].Trim();

                //[課題]空白が消えない
                //抽出した単語が空白の場合
                if (String.IsNullOrEmpty(words[i]))
                {
                    words.RemoveAt(i);
                }
            }

            //データベース登録
            JSON _json = new JSON();
            foreach(string word in words)
            {
                JSONDATA _jsonData = new JSONDATA
                {
                    Word = word,
                    Date = DateTime.Now
                };

                //同じキーが入力されたら、入力情報を更新する
                if (_json.Words.ContainsKey(_jsonData.Word))
                {
                    _json.Words[_jsonData.Word] = _jsonData;
                    continue;
                }
                _json.Words.Add(_jsonData.Word, _jsonData);
            }

            return _json;
        }
    }
}
