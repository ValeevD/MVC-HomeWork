using System.Collections.Generic;

namespace MVCExample
{
    public class CollisionController
    {
        private List<IDestructable> _destructables;
        private Dictionary<CollisionType, CollisionType> _collisionClasses;

        public CollisionController(IDestructable[] destructables)
        {
            _collisionClasses = new Dictionary<CollisionType, CollisionType>();

            _collisionClasses.Add(CollisionType.Player, CollisionType.Enemy);
            _collisionClasses.Add(CollisionType.Enemy, CollisionType.Projectile);

            foreach(var destructable in _destructables)
            {
                destructable.CheckCollision += CheckCollision;
            }
        }

        private void CheckCollision(IDestructable des, ICollision col)
        {
            if(_collisionClasses[des.SelfCollisionType] == col.SelfCollisionType)
            {
                des.Destroy();
            }
        }


    }
}
