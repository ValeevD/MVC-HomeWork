
using System;

namespace MVCExample
{
    public interface IUIInfo : IDestroyObject
    {
        void SetWin();
        void SetLose();
        void SetScore(int score);
    }
}
