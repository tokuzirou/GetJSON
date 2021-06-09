using System;

namespace GetJSON
{
    class Program
    {
        static void Main()
        {
            string _option = "";
            Console.WriteLine("オプションを入力してください。");
            _option = Console.ReadLine();
            switch (_option)
            {
                case "Write":
                    WriteJSON writeJSON = new WriteJSON();
                    writeJSON.Write();
                    break;
                default:
                    break;
            }
        }
    }
}
