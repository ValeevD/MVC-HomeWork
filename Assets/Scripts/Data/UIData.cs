using UnityEngine;

namespace MVCExample
{
    [CreateAssetMenu(fileName = "UnitSettings", menuName = "Data/UI/UISettings")]
    public sealed class UIData : ScriptableObject
    {
        public UIInfo uIPrefab;
    }
}
