using System;

namespace GetJSON
{
    public class Confirm
    {
        private bool _inputEndcodeFlag;
        private string _inputEndcode;

        internal bool JudgeEndFlag { get; set; }

        internal Confirm()
        {

        }

        internal Confirm(bool judgeEndFlag)
        {
            this.JudgeEndFlag = judgeEndFlag;
        }

        internal void ConfirmData()
        {
            while (_inputEndcodeFlag)
            {
                //入力するかどうか確認
                Console.WriteLine("データを入力しますか");
                Console.Write("Yes/No: ");
                _inputEndcode = Console.ReadLine();
                switch (_inputEndcode)
                {
                    case "Yes":
                        JudgeEndFlag = true;
                        _inputEndcodeFlag = false;
                        break;
                    case "No":
                        JudgeEndFlag = false;
                        _inputEndcodeFlag = false;
                        break;
                    default:
                        Console.WriteLine("入力する形式が違います。");
                        _inputEndcodeFlag = true;
                        continue;
                }
            }
        }

        internal bool ConfirmData(bool judgeEnd)
        {
            while (_inputEndcodeFlag)
            {
                //入力するかどうか確認
                Console.WriteLine("データを入力しますか");
                Console.Write("Yes/No: ");
                _inputEndcode = Console.ReadLine();
                switch (_inputEndcode)
                {
                    case "Yes":
                        _inputEndcodeFlag = false;
                        judgeEnd = true;
                        break;
                    case "No":
                        _inputEndcodeFlag = false;
                        judgeEnd = false;
                        break;
                    default:
                        Console.WriteLine("入力する形式が違います。");
                        _inputEndcodeFlag = true;
                        continue;
                }
            }

            return judgeEnd;
        }
    }
}
