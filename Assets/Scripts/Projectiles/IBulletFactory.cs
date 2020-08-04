using System;
using UnityEngine;

namespace MVCExample
{
    public interface IBulletFactory
    {
        IProjectile CreateBullet(Transform transform, Vector2 direction);
    }
}
