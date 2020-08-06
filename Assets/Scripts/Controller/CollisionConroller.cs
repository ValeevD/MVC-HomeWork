using System.Collections.Generic;
using UnityEngine;

namespace MVCExample
{
    public class CollisionController: ICleanup
    {
        private List<IDestructable> _destructables;
        private Dictionary<CollisionType, CollisionType> _collisionClasses;

        public CollisionController(List<IDestructable> destructables)
        {
            _collisionClasses = new Dictionary<CollisionType, CollisionType>();

            _collisionClasses.Add(CollisionType.Player, CollisionType.Enemy);
            _collisionClasses.Add(CollisionType.Enemy, CollisionType.Projectile);

            InitializeDistructables(destructables);
        }


        private void CheckCollision(IDestructable des, ICollision col)
        {
            //Debug.Log("Collision!!");
            if(_collisionClasses[des.SelfCollisionType] == col.SelfCollisionType)
            {
                des.Destroy();
                _destructables.Remove(des);

                if(col.SelfCollisionType == CollisionType.Projectile)
                {
                    ((IIsDead)col).IsDead = true;
                }
            }
        }

        public void InitializeDistructables(List<IDestructable> destructables)
        {
            _destructables = new List<IDestructable>();
            foreach(var destructable in destructables)
            {
                _destructables.Add(destructable);
                destructable.CheckCollision += CheckCollision;
            }
        }

        public void Cleanup()
        {
        }

    }
}
