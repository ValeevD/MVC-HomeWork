using UnityEngine;

namespace MVCExample
{
    public interface IPlayer : IMove, IDirected, IIsDead, IDestroyObject
    {
        void SetSpeed(Vector2 _speed);
    }
}
