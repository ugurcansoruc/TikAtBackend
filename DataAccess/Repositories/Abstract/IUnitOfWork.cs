namespace DataAccess.Repositories.Abstract
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
