using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVCExample
{
    public class PlayerProvider : MonoBehaviour, IDestructable, IPlayer
    {
        public CollisionType SelfCollisionType {get;set;}
        public event Action<IDestructable, ICollision> CheckCollision = delegate(IDestructable des, ICollision col) {};

        private Transform _transform;
        private Vector2 _speed;
        private Vector2 _direction;
        private Rigidbody2D _rigidBody;

        private void Awake()
        {
            _transform = transform;
            _speed = new Vector2(0, 0);
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
            Destroy(gameObject);
        }

        public void Move(float deltaTime)
        {
            _rigidBody.velocity = _speed;
            SetDirection(_speed.normalized);
            //var speed = deltaTime * _unitData.Speed;
            //_move.Set(_horizontal * speed, _vertical * speed, 0.0f);
            //_unit.localPosition += _move;
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
    }
}
