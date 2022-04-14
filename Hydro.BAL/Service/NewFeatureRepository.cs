using Hydro.BAL.Interface;
using Hydro.DAL;
using Hydro.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hydro.BAL.Service
{
    public class NewFeatureRepository : INewFeatureRepository
    {
        private readonly HydroDBContext _context;
        public NewFeatureRepository(HydroDBContext context)
        {
            _context = context;
        }
        public void Add(NewFeature newFeature)
        {
            _context.NewFeatures.Add(newFeature);
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
            var existingParent = _context.NewFeatures.Where(x => x.Id == Id).FirstOrDefault();
            existingParent.Isdelete = true;
            _context.NewFeatures.Update(existingParent);
        }

        public List<NewFeature> GetAll()
        {
           var list= _context.NewFeatures.ToList();
            foreach (var item in list)
            {
                item.ListOfFiles = new List<DocumentFile>();
                item.ListOfFiles = _context.DocumentFiles.Where(c => c.Type == 2 && c.ParentId == item.Id).ToList();
            }
            return list;
        }

        //public NewFeature GetById(long Id)
        //{
        //    return _context.NewFeatures.Where(c => c.Id == Id).FirstOrDefault();
        //}


        public NewFeature GetById(long Id)
        {
            var obj = _context.NewFeatures.Where(c => c.Id == Id).FirstOrDefault();

            obj.ListOfFiles = new List<DocumentFile>();
            obj.ListOfFiles = _context.DocumentFiles.Where(c => c.Type == 2 && c.ParentId == obj.Id).ToList();

            return obj;

        }
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(NewFeature newFeature)
        {
            var existingParent = _context.NewFeatures.Where(x => x.Id == newFeature.Id).SingleOrDefault();
            if (existingParent != null)
            {
                _context.Entry(existingParent).CurrentValues.SetValues(newFeature);
            }


        }
    }
}
