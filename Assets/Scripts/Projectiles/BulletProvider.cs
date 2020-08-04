using System;
using UnityEngine;

namespace MVCExample
{
    public class BulletProvider : MonoBehaviour, IDirected, IProjectile, ICollision
    {
        private float _speed;

        private Transform _transform;
        private Vector2 _direction;
        private Rigidbody2D _rigidBody;
        private float _lifeTime;
        public bool IsDead{get; set;}

        public CollisionType SelfCollisionType {get; set;}

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
            _transform = transform;
            IsDead = false;
            SelfCollisionType = CollisionType.Projectile;
        }

        private void Start()
        {
            Invoke("SetDead", _lifeTime);
        }

        public Vector2 GetDirection()
        {
            return _direction;
        }

        public Transform GetPosition()
        {
            return _transform;
        }

        public void SetDirection(Vector2 newDirection)
        {
            _direction = newDirection;
        }

        public void Move(float deltaTime)
        {
            _rigidBody.velocity = _direction * _speed;
        }

        public void SetSpeed(float speed)
        {
            _speed = speed;
        }

        public void SetLifeTime(float lifeTime)
        {
            _lifeTime = lifeTime;
        }

        private void SetDead()
        {
            IsDead = true;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
