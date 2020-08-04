using System.Collections.Generic;

namespace MVCExample
{
    public sealed class PlayerBullets : IMove
    {

        private List<IProjectile> _projectiles;
        private List<IProjectile> _deadProjectiles;

        public PlayerBullets()
        {
            _projectiles = new List<IProjectile>();
            _deadProjectiles = new List<IProjectile>();
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
