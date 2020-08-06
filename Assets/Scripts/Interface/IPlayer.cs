using UnityEngine;

namespace MVCExample
{
    public interface IPlayer : IMove, IDirected
    {
        void SetSpeed(Vector2 _speed);
    }
}
