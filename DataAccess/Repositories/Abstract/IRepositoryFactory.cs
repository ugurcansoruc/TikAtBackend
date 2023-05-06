namespace DataAccess.Repositories.Abstract
{
    public interface IRepositoryFactory
    {
        IUserRepository UserRepository { get; }
    }
}
