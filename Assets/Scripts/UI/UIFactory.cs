using UnityEngine;


namespace MVCExample
{
    public class UIFactory : IUIFactory
    {
        public IUIInfo CreateUI(UIData uiData)
        {
            var _prefab = uiData.uIPrefab;

            return UnityEngine.Object.Instantiate(_prefab);
        }
    }
}
