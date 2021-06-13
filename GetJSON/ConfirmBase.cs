namespace GetJSON
{
    public abstract class ConfirmBase
    {
        internal bool _inputEndcodeFlag = true;

        internal string _inputEndcode;

        internal abstract bool JudgeEndFlag { get; set; }

        internal abstract void ConfirmData(string message = "データを入力しますか");
        internal abstract bool ConfirmData(bool loopFlag, string message = "データを入力しますか");
    }
}