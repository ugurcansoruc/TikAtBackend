using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<User> GetAll()
        {
            return _userDal.GetList();
        }

        public User GetById(int id)
        {
            return _userDal.Get(u => u.ID== id);
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public void Delete(User user) 
        {
            _userDal.Delete(user);
        }
    }
}
