namespace Domain.Interfaces.Generics
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
