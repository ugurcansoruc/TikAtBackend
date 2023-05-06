using Business.Abstract;
using DataAccess.Repositories.Abstract;
using Entities.Concreate.Identity;

namespace Business.Concreate
{
    public class UserService : IUserService
    {
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IRepositoryFactory repositoryFactory, IUnitOfWork unitOfWork)
        {
            _repositoryFactory = repositoryFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await _repositoryFactory.UserRepository.CreateAsync(user);
            await _unitOfWork.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _repositoryFactory.UserRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _repositoryFactory.UserRepository.GetAllAsync();
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            await _repositoryFactory.UserRepository.UpdateAsync(user);
            await _unitOfWork.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUserAsync(User user)
        {
            await _repositoryFactory.UserRepository.DeleteAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
