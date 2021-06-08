using System;
using System.IO;

namespace GetJSON
{
    public static class OperateDirectory
    {
        //ディレクトリ名を入力させる
        public static string InputDirectory()
        {
            string dir;
            Console.Write("ディレクトリ名: ");
            dir = Console.ReadLine();
            dir = String.Format(@"{0}", dir);
            return dir;
        }

        //無効なディレクトリの処理

        
        //ディレクトリが見つからない場合
        //新しくディレクトリを作成する
        public static void CreateDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

        //カレントディレクトリを移動
        public static void MoveDirectory(string dirPath)
        {
            Directory.SetCurrentDirectory(dirPath);
        }
    }
}
