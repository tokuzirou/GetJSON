using System;
using System.IO;
using System.Text.Json;

namespace GetJSON
{
    class Program
    {
        static void Main()
        {
            //JsonSerializerOptionsクラスをインスタンス化
            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            //ディレクトリ名
            string dir;

            //ファイル名
            string file;

            //入力確認
            bool inputWordFlag = true;
            string inputWordFlagString;
            string inputWordProperty;
            int countWord = 0;

            //最終確認
            string inputEndcode;
            bool inputEndcodeFlag = true;
            bool judgeEndFlag = true;

            //JSONファイル更新処理
            do
            {
                //ディレクトリ名を入力
                dir = OperateDirectory.InputDirectory();
                //ディレクトリ作成
                OperateDirectory.CreateDirectory(dir);
                //カレントディレクトリを移動
                OperateDirectory.MoveDirectory(dir);

                //ファイル名を入力
                file = OperateFile.InputFile();
                //ファイル作成
                OperateFile.CreateFile(file);

                //JSONオブジェクトインスタンス化
                JSON json = new JSON();

                //whileステートメント
                while (inputWordFlag)
                {
                    //データ入力するかどうか確認
                    Console.WriteLine("データを入力しますか");
                    Console.Write("Yes/No: ");
                    inputWordFlagString = Console.ReadLine();
                    switch (inputWordFlagString)
                    {
                        case "Yes":
                            inputWordFlag = false;
                            break;
                        case "No":
                            goto endPoint;
                        default:
                            Console.WriteLine("入力する形式が違います。");
                            inputWordFlag = true;
                            continue;
                    }

                    //JSONオブジェクトのWordリストプロパティの入力
                    Console.WriteLine("データを入力してください。");
                    Console.Write("データ: ");
                    inputWordProperty = Console.ReadLine();
                    //追加
                    json.Word[countWord] = inputWordProperty;
                    //カウント
                    countWord++;
                    //whileステートメント終了
                }

                //シリアライズ
                string jsonString = JsonSerializer.Serialize(json, jsonSerializerOptions);

                //usingステートメント
                using (StreamWriter sw = new StreamWriter(file))
                {
                    //JSON文字列をファイルに出力
                    sw.WriteLine(jsonString);

                    //usingステートメント終了
                }

                while (inputEndcodeFlag)
                {
                    //入力するかどうか確認
                    Console.WriteLine("データを入力しますか");
                    Console.Write("Yes/No: ");
                    inputEndcode = Console.ReadLine();
                    switch (inputEndcode)
                    {
                        case "Yes":
                            judgeEndFlag = true;
                            inputEndcodeFlag = false;
                            break;
                        case "No":
                            judgeEndFlag = false;
                            inputEndcodeFlag = true;
                            break;
                        default:
                            Console.WriteLine("入力する形式が違います。");
                            inputEndcodeFlag = true;
                            continue;
                    }
                }

            } while (judgeEndFlag);

            //終了地点
            endPoint:; 
        }
    }
}
