using Hydro.BAL.Interface;
using Hydro.DAL;
using Hydro.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hydro.BAL.Service
{
    public class NavigationWRepository : INavigationWRepository
    {
        private readonly HydroDBContext _context;
        public NavigationWRepository(HydroDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }    
        public void Add(NavigationWarning navigationWarning)
        {
            _context.NavigationWarnings.Add(navigationWarning);
        }

        public void Delete(long Id)
        {
            var existingParent = _context.NavigationWarnings.Where(x => x.Id == Id).FirstOrDefault();
            existingParent.Isdelete = true;
            _context.NavigationWarnings.Update(existingParent);
        }

        public List<NavigationWarning> GetAll()
        {
            return _context.NavigationWarnings.ToList();
        }

        public NavigationWarning GetById(long Id)
        {
            return _context.NavigationWarnings.Where(c => c.Id == Id).FirstOrDefault();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(NavigationWarning navigationWarning)
        {
            var existingParent = _context.NavigationWarnings.Where(x => x.Id == navigationWarning.Id).SingleOrDefault();
            if (existingParent != null)
            {
                _context.Entry(existingParent).CurrentValues.SetValues(navigationWarning);
            }
        }
    }
}
