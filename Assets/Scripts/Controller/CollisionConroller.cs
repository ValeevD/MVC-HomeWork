using System.Collections.Generic;
using UnityEngine;

namespace MVCExample
{
    public class CollisionController: IInitialization, ICleanup, IExecute
    {
        private List<IDestructable> _destructables;
        private Dictionary<CollisionType, CollisionType> _collisionClasses;

        public bool CanExecute {get;set;}

        public CollisionController(List<IDestructable> destructables)
        {
            _collisionClasses = new Dictionary<CollisionType, CollisionType>();

            _collisionClasses.Add(CollisionType.Player, CollisionType.Enemy);
            _collisionClasses.Add(CollisionType.Enemy, CollisionType.Projectile);

            CanExecute = true;

            InitializeDistructables(destructables);
        }


        private void CheckCollision(IDestructable des, ICollision col)
        {
            if(_collisionClasses[des.SelfCollisionType] == col.SelfCollisionType)
            {
                des.CheckCollision -= CheckCollision;
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
            foreach(var des in _destructables)
            {
                des.CheckCollision -= CheckCollision;
                des.Destroy();
            }

            _destructables.Clear();
            _collisionClasses.Clear();
        }

        public void Initialization()
        {
        }

        public void Execute(float deltaTime)
        {
        }
    }
}
