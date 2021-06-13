using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace GetJSON
{
    //[課題]ReadJSONと共通項があるので、抽象クラス(IOJSON)を作る
    //書き込み機能(追加/更新)
    internal class WriteJSON : WriteJSONBase
    {
        internal override OperateDirectory OperateDirectory => _operateDirectory;

        internal override OperateFile OperateFile => _operateFile;

        internal override JsonSerializerOptions JsonSerializeOptions => _jsonSerializerOptions;

        internal WriteJSON(){ }

        internal override void Write()
        {
            //ローディングアニメーション
            char[] loadingAnimation = new char[4] { '↑', '→', '↓', '←' };

            //入力確認インスタンス
            Confirm confirm = new Confirm(constantJudgement);

            //JSONファイル更新処理
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
                //ファイル作成
                OperateFile.Create(file);

                //JSONオブジェクト読み取り
                JSON json = _inputData.Input();
                //シリアライズ
                string jsonString = JsonSerializer.Serialize(json, JsonSerializeOptions);

                //[課題]ファイル・ディレクトリ入力時にエラー処理
                try
                {
                    if (File.Exists(file))
                    {
                        Task task = Task.Run(() => { 
                            using(StreamWriter sw = new StreamWriter(file))
                            {
                                sw.WriteLine(jsonString);
                            }
                        });

                        //タスクが終わるまでローディング
                        int count = 0;
                        //ローディング表示が開始される位置を取得
                        int leftPosition = Console.CursorLeft;
                        int topPosition = Console.CursorTop;
                        while (!task.IsCompleted)
                        {
                            //ローディング表示が開始される位置にカーソルを合わせる
                            Console.SetCursorPosition(leftPosition, topPosition);
                            //ローディング表示
                            Console.WriteLine(loadingAnimation[count % 4]);
                            //カウンタ更新
                            count++;
                        }
                        Console.SetCursorPosition(leftPosition, topPosition);
                        Console.WriteLine("書き込み完了");
                    }
                }catch(Exception ex)
                {
                    Console.WriteLine("ファイル名が無効です。");
                    Console.WriteLine(ex.ToString());
                }

                //継続確認
                confirm.ConfirmData("他のデータベースを作成しますか？");

            } while (confirm.JudgeEndFlag);
        }
    }
}
