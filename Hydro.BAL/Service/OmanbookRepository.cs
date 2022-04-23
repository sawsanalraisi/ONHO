using Hydro.BAL.Interface;
using Hydro.DAL;
using Hydro.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydro.BAL.Service
{
    public class OmanbookRepository : IOmanbookRepository
    {
        private readonly HydroDBContext _context;

        public OmanbookRepository(HydroDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void Add(Omanbook Omanbook)
        {
            _context.Omanbooks.Add(Omanbook);
        }

        public void Delete(long Id)
        {
            var existingParent = _context.Omanbooks.Where(x => x.Id == Id).FirstOrDefault();
            existingParent.Isdelete = true;
            _context.Omanbooks.Update(existingParent);
        }

        public List<Omanbook>  GetAll()
        {
            return _context.Omanbooks.ToList();

        }
        public Omanbook GetById(long Id)
        {
          return _context.Omanbooks.Where(c =>c.Id ==Id).FirstOrDefault();          
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(Omanbook Omanbook)
        {
            var existingParent = _context.Omanbooks.Where(x => x.Id == Omanbook.Id).SingleOrDefault();
            if (existingParent != null)
            {
                _context.Entry(existingParent).CurrentValues.SetValues(Omanbook);
            }
        }

    }
}
