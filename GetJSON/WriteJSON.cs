using System.IO;
using System.Text.Json;

namespace GetJSON
{
    internal class WriteJSON
    {
        //入力確認インスタンス変数
        private const bool constantJudgement = true;

        //ディレクトリクラスインスタンス
        private readonly OperateDirectory _operateDirectory = new OperateDirectory();
        internal OperateDirectory OperateDirectory => _operateDirectory;

        //ファイルクラスインスタンス
        private readonly OperateFile _operateFile = new OperateFile();
        internal OperateFile OperateFile => _operateFile;


        internal void Write()
        {
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

                //入力確認
                confirm.ConfirmData();

                //JSONオブジェクト読み取り
                JSON json = InputData.Input();

                //JsonSerializerOptionsクラスをインスタンス化
                JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
                {
                    WriteIndented = true,
                };

                //usingステートメント
                using (StreamWriter sw = new StreamWriter(file))
                {
                    //シリアライズ
                    string jsonString = JsonSerializer.Serialize(json, jsonSerializerOptions);

                    //JSON文字列をファイルに出力
                    sw.WriteLine(jsonString);
                }

                //再度入力確認
                confirm.ConfirmData();

            } while (confirm.JudgeEndFlag);
        }
    }
}
