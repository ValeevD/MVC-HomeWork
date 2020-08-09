using System;
using UnityEngine;

namespace MVCExample
{
    public sealed class EnemyProvider : MonoBehaviour, IEnemy, IDestructable

    {
        [SerializeField] private float _speed;
        [SerializeField] private float _stopDistance;
        private Rigidbody2D _rigidbody2D;
        private Transform _transform;

        public CollisionType SelfCollisionType {get; set;}

        public bool IsDead{get;set;}

        public bool CanMove {get;set;}

        public event Action<IDestructable, ICollision> CheckCollision;

        private void Awake()
        {
            IsDead = false;
            CanMove = true;
            _transform = transform;
            SelfCollisionType = CollisionType.Enemy;
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void Move(Vector3 point)
        {
            if ((_transform.localPosition - point).sqrMagnitude >= _stopDistance * _stopDistance)
            {
                var dir = (point - _transform.localPosition).normalized;
                _rigidbody2D.velocity = dir * _speed;
            }
            else
            {
                _rigidbody2D.velocity = Vector2.zero;
            }
        }

        public void Destroy()
        {
            IsDead = true;
            CanMove = false;
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            CheckCollision.Invoke(this, other.gameObject.GetComponent<ICollision>());
        }
    }
}
