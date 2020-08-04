using UnityEngine;

namespace MVCExample
{
    public sealed class MoveController : IExecute, ICleanup
    {
        private readonly Transform _unit;
        private readonly IUnit _unitData;
        private IDirected _player;
        private float _horizontal;
        private float _vertical;
        private Vector3 _move;
        private IUserInputProxy _horizontalInputProxy;
        private IUserInputProxy _verticalInputProxy;

        public MoveController(IUserInputProxy horizontal, IUserInputProxy vertical, IDirected unit, IUnit unitData)
        {
            _player = unit;
            _unit = unit.GetPosition();
            _unitData = unitData;
            _horizontalInputProxy = horizontal;
            _verticalInputProxy = vertical;
            _horizontalInputProxy.AxisOnChange += HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange += VerticalOnAxisOnChange;
            //vertical.AxisOnChange += f => _vertical = f;
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
            var speed = deltaTime * _unitData.Speed;
            _move.Set(_horizontal * speed, _vertical * speed, 0.0f);
            _unit.localPosition += _move;

            if(_move != Vector3.zero)
            {
                _player.SetDirection(_move.normalized);
            }
        }

        public void Cleanup()
        {
            _horizontalInputProxy.AxisOnChange -= HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange -= VerticalOnAxisOnChange;
        }
    }
}
