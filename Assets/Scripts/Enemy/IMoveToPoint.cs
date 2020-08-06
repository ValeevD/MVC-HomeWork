using UnityEngine;

namespace MVCExample
{
    public interface IMoveToPoint
    {
        bool CanMove{get; set;}
        void Move(Vector3 point);
    }
}
