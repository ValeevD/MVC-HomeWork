using UnityEngine;

namespace MVCExample
{
    public sealed class EnemyMoveController : IExecute, ICleanup
    {
        private readonly IMoveToPoint _move;
        private readonly Transform _target;

        public bool CanExecute {get;set;}

        public EnemyMoveController(IMoveToPoint move, Transform target)
        {
            CanExecute = true;
            _move = move;
            _target = target;
        }

        public void Execute(float deltaTime)
        {
            if(_target == null)
            {
                CanExecute = false;
                return;
            }

            _move.Move(_target.localPosition);
        }

        public void Cleanup()
        {
            if(_move is ICleanup)
                ((ICleanup)_move).Cleanup();
        }
    }
}
