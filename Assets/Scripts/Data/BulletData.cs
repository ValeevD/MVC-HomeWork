using UnityEngine;

namespace MVCExample
{
    [CreateAssetMenu(fileName = "BulletSettings", menuName = "Data/Projectiles/BulletSettings")]
    public sealed class BulletData : ScriptableObject, IUnit
    {
        //public Sprite Sprite;
        [SerializeField, Range(0, 100)] private float _speed;
        [SerializeField, Range(0, 10)] private float _lifeTime;
        public float Speed => _speed;
        public float LifeTime => _lifeTime;
        public float _reloadTime;
        public BulletProvider bulletPrefab;
    }
}
