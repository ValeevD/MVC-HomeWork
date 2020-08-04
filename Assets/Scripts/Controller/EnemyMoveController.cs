using UnityEngine;

namespace MVCExample
{
    public sealed class EnemyMoveController : IExecute
    {
        private readonly IMoveToPoint _move;
        private readonly Transform _target;

        public EnemyMoveController(IMoveToPoint move, Transform target)
        {
            _move = move;
            _target = target;
        }

        public void Execute(float deltaTime)
        {
            _move.Move(_target.localPosition);
        }
    }
}
