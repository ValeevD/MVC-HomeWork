namespace MVCExample
{
    public interface IExecute
    {
        bool CanExecute{get;set;}
        void Execute(float deltaTime);
    }
}
