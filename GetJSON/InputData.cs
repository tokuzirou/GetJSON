using System;

namespace GetJSON
{
    public static class InputData
    {
        internal static JSON Input()
        {
            //ループフラグ
            bool loopFlag = true;

            //JSONオブジェクトをインスタンス化
            JSON json = new JSON();
            JSONDATA jSONDATA = new JSONDATA();

            //カウンタ変数
            int countWord = 0;

            //入力確認インスタンス
            Confirm confirm = new Confirm();

            while (loopFlag)
            {
                //JSONオブジェクトのWordsプロパティの入力
                //[課題]同じ英単語は登録できない用に、フィルタリングする
                Console.WriteLine("データを入力してください。");
                Console.Write("データ: ");
                jSONDATA.Word = Console.ReadLine(); ;
                jSONDATA.Date = DateTime.Now;
                json.Words.Add(jSONDATA.Word, jSONDATA);

                //データ入力を終了するかどうか確認
                loopFlag = confirm.ConfirmData(loopFlag);

                //インクリメント
                countWord++;
            }

            return json;
        }
    }
}
