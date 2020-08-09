using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVCExample
{
    public class PlayerProvider : MonoBehaviour, IDestructable, IPlayer
    {
        public CollisionType SelfCollisionType {get;set;}

        public bool IsDead{get;set;}

        public event Action<IDestructable, ICollision> CheckCollision;
        //public event Action<IDestructable, ICollision> CheckCollision;

        private Transform _transform;
        private Vector2 _speed;
        private Vector2 _direction;
        private Rigidbody2D _rigidBody;

        private void Awake()
        {
            IsDead = false;
            _transform = transform;
            _speed = new Vector2(0, 0);
            _direction = new Vector2(0, 1);
            _rigidBody = GetComponent<Rigidbody2D>();
            SelfCollisionType = CollisionType.Player;
        }

        public Vector2 GetDirection()
        {
            return _direction;
        }

        public Transform GetPosition()
        {
            return _transform;
        }

        public void Destroy()
        {
            if(this == null)
                return;

            IsDead = true;
            Destroy(gameObject);
        }


        public void SetSpeed(Vector2 speed)
        {
            _speed = speed;
        }

        public void SetDirection(Vector2 newDirection)
        {
            if (newDirection != Vector2.zero)
            {
                _direction = newDirection;
            }
        }

        public void Move(float deltaTime)
        {
            _rigidBody.velocity = _speed;
            SetDirection(_speed.normalized);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            CheckCollision.Invoke(this, other.GetComponent<ICollision>());
        }


    }
}
