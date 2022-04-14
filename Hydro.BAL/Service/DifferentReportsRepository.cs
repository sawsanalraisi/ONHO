using Hydro.BAL.Interface;
using Hydro.DAL;
using Hydro.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hydro.BAL.Service
{
  public  class DifferentReportsRepository : IDifferentReportsRepository
    {
        private readonly HydroDBContext _context;
        public DifferentReportsRepository(HydroDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void Add(DifferentReport differentReports)
        {
            _context.DifferentReports.Add(differentReports);
        }

        public void AddDocument(List<DocumentFile> documentFiles, long Parantid)
        {
            foreach (var item in documentFiles)
            {
                item.ParentId = Parantid;
                _context.DocumentFiles.Add(item);
                _context.SaveChanges();
            }
        }

        public void Delete(long Id)
        {
            var existingParent = _context.DifferentReports.Where(x => x.Id == Id).FirstOrDefault();
            existingParent.Isdelete = true;
            _context.DifferentReports.Update(existingParent);
        }

        public List<DifferentReport> GetAll()
        {
           var list =_context.DifferentReports.ToList();
            foreach (var item in list)
            {
                item.ListOfFiles = new List<DocumentFile>();
                item.ListOfFiles = _context.DocumentFiles.Where(c => c.Type == 1 && c.ParentId == item.Id).ToList();
            }

            return list;
        }

        public DifferentReport GetById(long Id)
        {
            return _context.DifferentReports.Where(c => c.Id == Id).FirstOrDefault();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);

        }

        public void Update(DifferentReport differentReports)
        {
            var existingParent = _context.DifferentReports.Where(x => x.Id == differentReports.Id).SingleOrDefault();
            if (existingParent != null)
            {
                _context.Entry(existingParent).CurrentValues.SetValues(differentReports);
            }
        }
    }
}
