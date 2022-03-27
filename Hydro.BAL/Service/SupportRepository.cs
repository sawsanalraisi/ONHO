using Hydro.BAL.Interface;
using Hydro.DAL;
using Hydro.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hydro.BAL.Service
{
    public class SupportRepository : ISupportRepository
    {

        private readonly HydroDBContext _context;
        public SupportRepository(HydroDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void AddLog(Logs obj)
        {
            _context.Logs.Add(obj);
        }

      

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
