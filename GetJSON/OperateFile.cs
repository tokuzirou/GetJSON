using System;
using System.IO;

namespace GetJSON
{
    public static class OperateFile
    {
        //ファイル名入力
        public static string InputFile()
        {
            string file;
            Console.Write("ファイル名: ");
            file = Console.ReadLine();
            file = String.Format(@"{0}", file);
            return file;
        }

        //ファイルがない場合、作成
        public static void CreateFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
        }
    }
}
