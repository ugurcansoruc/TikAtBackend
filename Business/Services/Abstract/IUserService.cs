using Entities.Concreate.Identity;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(User user);
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> UpdateUserAsync(User user);
        Task DeleteUserAsync(User user);
    }
}
