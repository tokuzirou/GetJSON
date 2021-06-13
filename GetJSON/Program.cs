using System;
using System.Threading;

namespace GetJSON
{
    class Program
    {
        static void Main()
        {
            //[名前]---JSONデータベースを効率良く作成できるソフトウェア---

            //[目標]全てのデータベース処理をボタン一つで操作できるようにし、開発者自身が本来の開発に集中できるようにすること

            //[課題]Webスクレイピングで、情報収集モードを追加

            //Writeモード : JSONファイルにデータベースを登録できる
            //Readモード  : JSONファイルを読み込める
            //Fileモード  : JSONファイルをポップアップできる
            //Webモード   : JSONファイルにWebクローリングして得られたデータベースを登録できる
            Console.Write("オプションを入力してください: ");
            string _option = Console.ReadLine();
            switch (_option)
            {
                case "Write":
                    WriteJSON writeJSON = new WriteJSON();
                    writeJSON.Write();
                    break;
                case "Read":
                    ReadJSON readJSON = new ReadJSON();
                    readJSON.Read();
                    break;
                case "File":
                case "Web":
                default:
                    Console.WriteLine("無効な入力です。");
                    break;
            }

            //[課題]静的メソッド化
            Console.WriteLine("プログラムを終了します。");
            Thread.Sleep(2000);
        }
    }
}
