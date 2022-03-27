using Hydro.BAL.Interface;
using Hydro.DAL;
using Hydro.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hydro.BAL.Service
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly HydroDBContext _context;
        public CategoryRepository(HydroDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Category servcieType)
        {
            _context.Categories.Add(servcieType);
        }

        public void Delete(long Id)
        {
            var existingParent = _context.Categories.Where(x => x.Id == Id).FirstOrDefault();
            existingParent.Isdelete = true;
            _context.Categories.Update(existingParent);
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category GetById(long Id)
        {
            return _context.Categories.Where(c => c.Id == Id).FirstOrDefault();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(Category servcieType)
        {
            var existingParent = _context.Categories.Where(x => x.Id == servcieType.Id).SingleOrDefault();
            if (existingParent != null)
            {
                _context.Entry(existingParent).CurrentValues.SetValues(servcieType);
            }
        }
    }
}
