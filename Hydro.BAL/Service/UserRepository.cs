using Hydro.BAL.Interface;
using Hydro.DAL;
using Hydro.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hydro.BAL.Service
{
    public class UserRepository : IUserRepository
    {
        private readonly HydroDBContext _context;
        public UserRepository(HydroDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
        }

        public void Delete(string Id)
        {
            var existingParent = _context.Users.Where(x => x.Id == Id).FirstOrDefault();
            existingParent.Isdelete = true;
            _context.Users.Update(existingParent);
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(string Id)
        {
            return _context.Users.Where(c => c.Id == Id).FirstOrDefault();
        }

        public User GetByUserName(string email)
        {
            return _context.Users.Where(c => c.Email ==email).FirstOrDefault();
             
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(User user)
        {
            var existingParent = _context.Users.Where(x => x.Id == user.Id).SingleOrDefault();
            if (existingParent != null)
            {
                _context.Entry(existingParent).CurrentValues.SetValues(user);
            }
        }
    }
}
