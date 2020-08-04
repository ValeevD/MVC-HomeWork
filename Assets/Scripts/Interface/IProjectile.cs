namespace MVCExample
{
    public interface IProjectile : IMove, IDestroyObject
    {
        bool IsDead{get;}
    }
}
