using System;
using System.IO;

namespace GetJSON
{
    internal class OperateFile : OperateIO, IFile
    {
        //ファイル名入力
        internal override string Input()
        {
            Console.Write("ファイル名: ");
            string file = Console.ReadLine();
            file = string.Format(@"{0}", file);
            return file;
        }

        //ファイルがない場合、作成
        internal override void Create(string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
        }
    }
}
