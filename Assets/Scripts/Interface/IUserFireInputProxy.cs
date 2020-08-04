using System;

namespace MVCExample
{
    public interface IUserFireInputProxy
    {
        event Action<bool> FireOnEnable;
        void GetFireInput();
    }
}
