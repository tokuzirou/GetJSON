using System;

namespace GetJSON
{
    public class Confirm : ConfirmBase
    {
        internal override bool JudgeEndFlag { get; set; }

        internal Confirm(){ }

        internal Confirm(bool judgeEndFlag) => this.JudgeEndFlag = judgeEndFlag;

        internal override void ConfirmData(string message = "データを入力しますか")
        {
            while (_inputEndcodeFlag)
            {
                //入力するかどうか確認
                Console.WriteLine(message);
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
            _inputEndcodeFlag = true;
        }

        internal override bool ConfirmData(bool loopFlag, string message = "データを入力しますか")
        {
            while (_inputEndcodeFlag)
            {
                //入力するかどうか確認
                Console.WriteLine(message);
                Console.Write("Yes/No: ");
                _inputEndcode = Console.ReadLine();
                switch (_inputEndcode)
                {
                    case "Yes":
                        loopFlag = true;
                        _inputEndcodeFlag = false;
                        break;
                    case "No":
                        loopFlag = false;
                        _inputEndcodeFlag = false;
                        break;
                    default:
                        Console.WriteLine("入力する形式が違います。");
                        _inputEndcodeFlag = true;
                        continue;
                }
            }
            _inputEndcodeFlag = true;
            return loopFlag;
        }
    }
}
