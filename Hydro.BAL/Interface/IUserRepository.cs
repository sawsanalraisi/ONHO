using Hydro.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hydro.BAL.Interface
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetById(string Id);
        User GetByUserName(string Email);
        void Update(User user);
        void Add(User user);
        void Delete(string Id);
        bool Save();
    }
}
