using UnityEngine;

namespace MVCExample
{
    public class BulletFactory : IBulletFactory
    {
        BulletData _data;

        public BulletFactory(BulletData data)
        {
            _data = data;
        }

        public IProjectile CreateBullet(Transform transform, Vector2 direction)
        {
            //Debug.Log(_data);
            var newObj = Object.Instantiate(_data.bulletPrefab, transform.position, Quaternion.identity);

            newObj.SetDirection(direction);
            newObj.SetSpeed(_data.Speed);
            newObj.SetLifeTime(_data.LifeTime);

            return newObj;
        }
    }
}
