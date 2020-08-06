using UnityEngine;

namespace MVCExample
{
    public sealed class MoveController : IExecute, ICleanup
    {
        public bool CanExecute {get;set;}

        private readonly Transform _unit;
        private readonly IUnit _unitData;
        private IPlayer _player;
        private float _horizontal;
        private float _vertical;
        private Vector3 _move;
        private IUserInputProxy _horizontalInputProxy;
        private IUserInputProxy _verticalInputProxy;


        public MoveController(IUserInputProxy horizontal, IUserInputProxy vertical, IPlayer unit, IUnit unitData)
        {
            CanExecute = true;
            _player = unit;
            _unit = unit.GetPosition();
            _unitData = unitData;
            _horizontalInputProxy = horizontal;
            _verticalInputProxy = vertical;
            _horizontalInputProxy.AxisOnChange += HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange += VerticalOnAxisOnChange;
        }

        private void HorizontalOnAxisOnChange(float value)
        {
            _horizontal = value;
        }

        private void VerticalOnAxisOnChange(float value)
        {
            _vertical = value;
        }


        public void Execute(float deltaTime)
        {
            if(_player.IsDead){
                return;
            }

            var speed = _unitData.Speed;
            _move.Set(_horizontal * speed, _vertical * speed, 0.0f);

            _player.SetSpeed(_move);
            _player.Move(deltaTime);
        }

        public void Cleanup()
        {
            _horizontalInputProxy.AxisOnChange -= HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange -= VerticalOnAxisOnChange;
        }
    }
}
