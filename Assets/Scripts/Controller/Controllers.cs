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

            IBulletFactory bulletFactory = new BulletFactory(data.Bullet);

            IEnemyFactory enemyFactory = new EnemyFactory();
            CompositeMove enemy = new CompositeMove();

            int enemiesNum = 5;

            for(int i=0; i<enemiesNum; ++i)
                enemy.AddUnit(enemyFactory.CreateEnemy(data.Enemy, EnemyType.Small));


            var enemiesList = enemy.GetEnemiesList();
            List<IDestructable> destructables = new List<IDestructable>();

            foreach(var _enemy in enemiesList)
            {
                destructables.Add((IDestructable)_enemy);
            }
            destructables.Add((IDestructable)player);


            IUIFactory uIFactory = new UIFactory();
            IUIInfo uI = uIFactory.CreateUI(data.UISettings);

            var executes = new List<IExecute>();
            executes.Add(new InputController(pcInputHorizontal, pcInputVertical, pcInputFire));
            executes.Add(new MoveController(pcInputHorizontal, pcInputVertical, player, data.Player));
            executes.Add(new EnemyMoveController(enemy, player.GetPosition()));
            executes.Add(new FireController(player, pcInputFire, data.Bullet, bulletFactory));
            executes.Add(new CollisionController(destructables));
            executes.Add(new UIController(uI, player, enemiesList));

            _executeControllers = executes.ToArray();
        }

        public void Initialization()
        {
        }

        public void Cleanup()
        {
            for (var i = 0; i < _executeControllers.Length; i++)
            {
                if(_executeControllers[i] is ICleanup)
                    ((ICleanup)_executeControllers[i]).Cleanup();
            }
        }
    }
}
