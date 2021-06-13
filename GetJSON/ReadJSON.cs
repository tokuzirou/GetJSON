using System;
using System.IO;
using System.Text.Json;

namespace GetJSON
{
    //[課題]WriteJSONと共通項があるので、抽象クラス(IOJSON)を作る
    //[課題]出力形式を増やし、オプションで選べるようにする
    //読み取り機能(一覧表示、条件検索)
    internal class ReadJSON
    {
        //入力確認インスタンス変数
        private const bool constantJudgement = true;

        //ディレクトリクラスインスタンス
        private readonly OperateDirectory _operateDirectory = new OperateDirectory();
        internal OperateDirectory OperateDirectory => _operateDirectory;

        //ファイルクラスインスタンス
        private readonly OperateFile _operateFile = new OperateFile();
        internal OperateFile OperateFile => _operateFile;

        //JsonSerializerOptionsクラスインスタンス
        private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
        };
        internal JsonSerializerOptions JsonSerializeOptions => _jsonSerializerOptions;

        internal void Read()
        {
            Confirm confirm = new Confirm(constantJudgement);

            do
            {
                //ディレクトリ名を入力
                string dirctory = OperateDirectory.Input();
                //ディレクトリ作成
                OperateDirectory.Create(dirctory);
                //カレントディレクトリを移動
                OperateDirectory.Move(dirctory);
                //ファイル名を入力
                string file = OperateFile.Input();

                try
                {
                    //ファイルストリームを出力
                    using (StreamReader sr = new StreamReader(file))
                    {
                        while (sr.ReadLine() != null)
                        {
                            Console.WriteLine(sr.ReadLine());
                        }
                    }
                }catch(Exception ex)
                {
                    Console.WriteLine("ファイル名が違います。");
                    Console.WriteLine(ex.ToString());
                }

                //最終確認
                //文字を変えたい
                confirm.ConfirmData();
            } while (confirm.JudgeEndFlag);
        }
    }
}
