using Hydro.BAL.Interface;
using Hydro.DAL;
using Hydro.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hydro.BAL.Service
{
    public class FileFormatRepository : IFileFormatRepository
    {
        private readonly HydroDBContext _context;
        public FileFormatRepository(HydroDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void Add(FileFormat fileFormat)
        {
            _context.FileFormats.Add(fileFormat);
        }

        public void Delete(long Id)
        {
            var existingParent = _context.FileFormats.Where(x => x.Id == Id).FirstOrDefault();
            existingParent.Isdelete = true;
            _context.FileFormats.Update(existingParent);
        }

        public List<FileFormat> GetAll()
        {
            return _context.FileFormats.ToList();
        }

        public FileFormat GetById(long Id)
        {
            return _context.FileFormats.Where(c => c.Id == Id).FirstOrDefault();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(FileFormat fileFormat)
        {
            var existingParent = _context.FileFormats.Where(x => x.Id == fileFormat.Id).SingleOrDefault();
            if (existingParent != null)
            {
                _context.Entry(existingParent).CurrentValues.SetValues(fileFormat);
            }
        }
    }
}
