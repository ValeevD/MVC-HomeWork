using System;
using UnityEngine;

namespace MVCExample
{
    public sealed class PCFireInput : IUserFireInputProxy
    {
        public event Action<bool> FireOnEnable = delegate(bool b) {};

        public void GetFireInput()
        {
            FireOnEnable.Invoke(Input.GetButton(AxisManager.FIRE1));
        }
    }
}
