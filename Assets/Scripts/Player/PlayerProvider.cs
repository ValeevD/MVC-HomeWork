using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVCExample
{
    public class PlayerProvider : MonoBehaviour, IDirected, IDestructable
    {
        public CollisionType SelfCollisionType {get;set;}
        public event Action<IDestructable, ICollision> CheckCollision = delegate(IDestructable des, ICollision col) {};

        private Transform _transform;
        private Vector2 _direction;

        private void Awake()
        {
            _transform = transform;
            _direction = new Vector2(0, 1);
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

        public void SetDirection(Vector2 newDirection)
        {
            _direction = newDirection;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
