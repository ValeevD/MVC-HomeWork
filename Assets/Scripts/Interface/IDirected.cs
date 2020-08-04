using UnityEngine;

namespace MVCExample
{
    public interface IDirected
    {
        Vector2 GetDirection();
        Transform GetPosition();
        void SetDirection(Vector2 newDirection);
    }
}
