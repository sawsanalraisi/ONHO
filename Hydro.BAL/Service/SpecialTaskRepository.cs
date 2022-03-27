using Hydro.BAL.Interface;
using Hydro.DAL;
using Hydro.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hydro.BAL.Service
{
    public class SpecialTaskRepository : ISpecialTaskRepository
    {
        private readonly HydroDBContext _context;
        public SpecialTaskRepository(HydroDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void Add(SpecialTask specialTask)
        {
            _context.SpecialTasks.Add(specialTask);
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
            var existingParent = _context.SpecialTasks.Where(x => x.Id == Id).FirstOrDefault();
            existingParent.Isdelete = true;
            _context.SpecialTasks.Update(existingParent);
        }

        public List<SpecialTask> GetAll()
        {
            return _context.SpecialTasks.ToList();
        }

        public SpecialTask GetById(long Id)
        {
            return _context.SpecialTasks.Where(c => c.Id == Id).FirstOrDefault();

        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(SpecialTask specialTask)
        {
            var existingParent = _context.SpecialTasks.Where(x => x.Id == specialTask.Id).SingleOrDefault();
            if (existingParent != null)
            {
                _context.Entry(existingParent).CurrentValues.SetValues(specialTask);
            }
        }
    }
}
