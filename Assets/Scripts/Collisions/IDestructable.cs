using System;

namespace MVCExample
{
    //Player and all enemies
    public interface IDestructable : ICollision
    {
        event Action<IDestructable, ICollision> CheckCollision;
        void Destroy();
    }
}
