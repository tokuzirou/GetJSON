using System.Text;
using System.Collections.Generic;
namespace GetJSON
{
    internal abstract class InputDataBase
    {
        //入力確認インスタンス
        internal readonly Confirm _confirm = new Confirm();

        //入力文字列
        internal readonly StringBuilder sb = new StringBuilder();

        //入力文字配列
        internal List<string> words;

        internal abstract JSON Input();
    }
}