﻿namespace MVCExample
{
    public sealed class InputController : IExecute
    {
        private readonly IUserInputProxy _horizontal;
        private readonly IUserInputProxy _vertical;
        private readonly IUserFireInputProxy _fire;

        public InputController(IUserInputProxy horizontal, IUserInputProxy vertical, IUserFireInputProxy fire)
        {
            _horizontal = horizontal;
            _vertical = vertical;
            _fire = fire;
        }

        public void Execute(float deltaTime)
        {
            _horizontal.GetAxis();
            _vertical.GetAxis();
            _fire.GetFireInput();
        }
    }
}
