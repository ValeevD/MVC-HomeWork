using System;
using System.Collections;
using UnityEngine;

namespace MVCExample
{
    public sealed class FireController:  IExecute, ICleanup
    {
        private readonly Transform _playerTransform;
        private readonly IDirected _player;

        private IBulletFactory _bulletFactory;
        private IUserFireInputProxy _fireInput;
        private BulletData _data;
        private bool _fire;
        private float _currentCooldown;

        private PlayerBullets _playerBullets;

        public bool CanExecute {get;set;}

        public FireController(IDirected player, IUserFireInputProxy fireInput, BulletData data, IBulletFactory bulletFactory)
        {
            CanExecute = true;
            _player = player;
            _fireInput = fireInput;
            _playerTransform = player.GetPosition();
            _data = data;
            _fireInput.FireOnEnable += FireInput;
            _currentCooldown = 0;
            _bulletFactory = bulletFactory;
            _playerBullets = new PlayerBullets();
            _fire = false;
        }


        public void Execute(float deltaTime)
        {
            if(_playerTransform == null)
            {
                CanExecute = false;
                return;
            }

            if(_fire && _currentCooldown == 0)
            {
                _playerBullets.AddBullet(_bulletFactory.CreateBullet(_playerTransform, _player.GetDirection()));
                _currentCooldown = _data._reloadTime;
                _fire = false;
            }
            else
            {
                _currentCooldown = _currentCooldown > 0 ? _currentCooldown - deltaTime : 0;
            }

            _playerBullets.Move(deltaTime);
        }

        private void FireInput(bool fire)
        {
            _fire = fire;
        }

        public void Cleanup()
        {
            _fireInput.FireOnEnable -= FireInput;
        }
    }
}
