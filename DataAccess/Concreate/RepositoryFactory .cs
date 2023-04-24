﻿using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concreate
{
    public class RepositoryFactory:IRepositoryFactory
    {
        private readonly DbContext _dbContext;

        public RepositoryFactory(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IUserRepository _userRepository;
        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_dbContext);
    }
}
