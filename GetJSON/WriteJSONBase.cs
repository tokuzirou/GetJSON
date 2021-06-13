using System.Text.Json;

namespace GetJSON
{
    internal abstract class WriteJSONBase
    {
        //[課題]
        //非公開のインスタンス変数と公開のプロパティで分割する

        //入力確認インスタンス変数
        internal const bool constantJudgement = true;

        //ディレクトリクラスインスタンス
        internal readonly OperateDirectory _operateDirectory = new OperateDirectory();

        //ファイルクラスインスタンス
        internal readonly OperateFile _operateFile = new OperateFile();

        //JsonSerializerOptionsクラスインスタンス
        internal readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
        };

        //InputDataクラスインスタンス
        internal readonly InputData _inputData = new InputData();

        internal abstract OperateDirectory OperateDirectory { get; }
        internal abstract OperateFile OperateFile { get; }
        internal abstract JsonSerializerOptions JsonSerializeOptions { get; }

        internal abstract void Write();
    }
}