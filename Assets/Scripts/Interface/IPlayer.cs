using UnityEngine;

namespace MVCExample
{
    public interface IPlayer : IMove, IDirected, IIsDead
    {
        void SetSpeed(Vector2 _speed);
    }
}
