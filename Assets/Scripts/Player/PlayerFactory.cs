using UnityEngine;

namespace MVCExample
{
    public sealed class PlayerFactory : IPlayerFactory
    {
        private readonly PlayerData _playerData;

        public PlayerFactory(PlayerData playerData)
        {
            _playerData = playerData;
        }

        public PlayerProvider CreatePlayer()
        {
           //return new GameObject("player").AddSprite(_playerData.Sprite).transform;

           return Object.Instantiate(_playerData.playerPrefab);
        }
    }
}
