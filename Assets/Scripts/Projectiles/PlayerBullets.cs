using System.Collections.Generic;

namespace MVCExample
{
    public sealed class PlayerBullets : IMove, ICollision
    {

        private List<IProjectile> _projectiles;
        private List<IProjectile> _deadProjectiles;

        public CollisionType SelfCollisionType {get;set;}

        public PlayerBullets()
        {
            _projectiles = new List<IProjectile>();
            _deadProjectiles = new List<IProjectile>();
            SelfCollisionType = CollisionType.Projectile;
        }

        public void Move(float deltaTime)
        {
            foreach(var projectile in _projectiles)
            {
                projectile.Move(deltaTime);

                if(projectile.IsDead)
                    _deadProjectiles.Add(projectile);
            }

            foreach(var deadProjectile in _deadProjectiles)
            {
                _projectiles.Remove(deadProjectile);
                deadProjectile.Destroy();
            }

            _deadProjectiles.Clear();
        }

        public void AddBullet(IProjectile projectile)
        {
            _projectiles.Add(projectile);
        }
    }
}
