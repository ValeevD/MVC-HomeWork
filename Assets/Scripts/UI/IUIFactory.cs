using System;

namespace MVCExample
{
    public interface IUIFactory
    {
        IUIInfo CreateUI(UIData uiData);
    }
}
