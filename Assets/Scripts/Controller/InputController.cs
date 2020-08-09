namespace MVCExample
{
    public sealed class InputController : IExecute, ICleanup
    {
        public bool CanExecute {get;set;}

        private readonly IUserInputProxy _horizontal;
        private readonly IUserInputProxy _vertical;
        private readonly IUserFireInputProxy _fire;


        public InputController(IUserInputProxy horizontal, IUserInputProxy vertical, IUserFireInputProxy fire)
        {
            CanExecute = true;
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

        public void Cleanup()
        {
        }
    }
}
