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
    public class NewSurveyRepository : INewSurveyRepository
    {
        private readonly HydroDBContext _context;
        public NewSurveyRepository(HydroDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void Add(NewSurvey newSurvey)
        {
            _context.NewSurveys.Add(newSurvey);
        }

        public void Delete(long Id)
        {
            var existingParent = _context.NewSurveys.Where(x => x.Id == Id).FirstOrDefault();
            existingParent.Isdelete = true;
            _context.NewSurveys.Update(existingParent);
        }

        public List<NewSurvey> GetAll()
        {
            return _context.NewSurveys.Include(c =>c.FileFormat).Include(c=>c.ListOLegalDocument).ToList();
        }

        public NewSurvey GetById(long Id)
        {
            return _context.NewSurveys.Where(c => c.Id == Id).FirstOrDefault();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(NewSurvey newSurvey)
        {
            var existingParent = _context.NewSurveys.Where(x => x.Id == newSurvey.Id).SingleOrDefault();
            if (existingParent != null)
            {
                _context.Entry(existingParent).CurrentValues.SetValues(newSurvey);
            }
        }

        public void AddLegalDocument(List<LegalDocument> documentFiles, long SurveyId)
        {
            foreach (var item in documentFiles)
            {
                item.NewSurveyId = SurveyId;
                item.LegalDocumentsType = "Download";
                _context.LegalDocuments.Add(item);
                //_context.SaveChanges();
            }
        }
    }
}
