using System;
using System.Collections.Generic;

namespace MVCExample
{

    public class UIController : IInitialization, ICleanup, IExecute
    {
        private IUIInfo _UI;
        private IPlayer _player;
        private List<IMoveToPoint> _enemies;

        private int initialEnemiesNumber;
        private int score;

        public bool CanExecute {get;set;}

        public UIController(IUIInfo uI, IPlayer player, List<IMoveToPoint> enemies)
        {
            CanExecute = true;
            _UI = uI;
            _player = player;
            _enemies = enemies;

            initialEnemiesNumber = enemies.Count;
            score = 0;
        }

        public void Initialization()
        {
        }

        public void Cleanup()
        {
            if(_enemies == null)
            {
                return;
            }

            _UI.Destroy();
            _enemies.Clear();
        }

        public void Execute(float deltaTime)
        {
            CanExecute = false;

            if(_player == null || _player.IsDead)
            {
                _UI.SetLose();
                return;
            }

            if(score != initialEnemiesNumber - _enemies.Count)
            {
                score = initialEnemiesNumber - _enemies.Count;
                _UI.SetScore(score);
            }

            if(score == initialEnemiesNumber)
            {
                _UI.SetWin();
                return;
            }

            CanExecute = true;
        }


    }
}
