using System;
using System.IO;

namespace GetJSON
{
    internal class OperateDirectory : OperateIO, IDirectory
    {
        //ディレクトリ名を入力させる
        internal override string Input()
        {
            string dir;
            Console.Write("ディレクトリ名: ");
            dir = Console.ReadLine();
            dir = String.Format(@"{0}", dir);
            return dir;
        }
        
        //ディレクトリが見つからない場合
        //新しくディレクトリを作成する
        internal override void Create(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

        //無効なディレクトリの処理
        //public static void Vaild()
        //{

        //}

        //カレントディレクトリを移動
        public void Move(string directoryPath)
        {
            Directory.SetCurrentDirectory(directoryPath);
        }
    }
}
