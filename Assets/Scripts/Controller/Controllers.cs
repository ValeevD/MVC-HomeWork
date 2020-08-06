using System.Collections.Generic;
using UnityEngine;

namespace MVCExample
{
    public sealed class Controllers : IInitialization, ICleanup
    {
        private readonly IExecute[] _executeControllers;

        public int Length => _executeControllers.Length;

        public IExecute this[int index] => _executeControllers[index];

        public Controllers(Data data)
        {
            var pcInputHorizontal = new PCInputHorizontal();
            var pcInputVertical = new PCInputVertical();
            var pcInputFire = new PCFireInput();

            IPlayerFactory playerFactory = new PlayerFactory(data.Player);
            IPlayer player = playerFactory.CreatePlayer();
            //Transform playerTransform = player.transform;
            //var playerProvider = player.GetComponent<PlayerProvider>();

            IBulletFactory bulletFactory = new BulletFactory(data.Bullet);

            IEnemyFactory enemyFactory = new EnemyFactory();
            CompositeMove enemy = new CompositeMove();

            enemy.AddUnit(enemyFactory.CreateEnemy(data.Enemy, EnemyType.Small));
            enemy.AddUnit(enemyFactory.CreateEnemy(data.Enemy, EnemyType.Small));
            enemy.AddUnit(enemyFactory.CreateEnemy(data.Enemy, EnemyType.Small));
            enemy.AddUnit(enemyFactory.CreateEnemy(data.Enemy, EnemyType.Small));
            enemy.AddUnit(enemyFactory.CreateEnemy(data.Enemy, EnemyType.Small));

            var executes = new List<IExecute>();
            executes.Add(new InputController(pcInputHorizontal, pcInputVertical, pcInputFire));
            executes.Add(new MoveController(pcInputHorizontal, pcInputVertical, player, data.Player));
            executes.Add(new EnemyMoveController(enemy, player.GetPosition()));
            executes.Add(new FireController(player, pcInputFire, data.Bullet, bulletFactory));

            _executeControllers = executes.ToArray();
        }

        public void Initialization()
        {
        }

        public void Cleanup()
        {
        }
    }
}
