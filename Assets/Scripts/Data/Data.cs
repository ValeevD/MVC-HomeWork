using System.IO;
using UnityEngine;


namespace MVCExample
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
    public sealed class Data : ScriptableObject
    {
        [SerializeField] private string _playerDataPath;
        [SerializeField] private string _enemyDataPath;
        [SerializeField] private string _bulletDataPath;
        [SerializeField] private string _uiDataPath;
        private PlayerData _player;
        private EnemyData _enemy;
        private BulletData _bullet;
        private UIData _ui;


        public PlayerData Player
        {
            get
            {
                if (_player == null)
                {
                    _player = Load<PlayerData>("Data/" + _playerDataPath);
                }

                return _player;
            }
        }


        public EnemyData Enemy
        {
            get
            {
                if (_enemy == null)
                {
                    _enemy = Load<EnemyData>("Data/" + _enemyDataPath);
                }

                return _enemy;
            }
        }

        public BulletData Bullet
        {
            get
            {
                if (_bullet == null)
                {
                    _bullet = Load<BulletData>("Data/" + _bulletDataPath);
                }

                return _bullet;
            }
        }

        public UIData UISettings
        {
            get
            {
                if (_ui == null)
                {
                    _ui = Load<UIData>("Data/" + _uiDataPath);
                }

                return _ui;
            }
        }


        private T Load<T>(string resourcesPath) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
    }
}
