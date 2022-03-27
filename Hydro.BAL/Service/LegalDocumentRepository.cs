using Hydro.BAL.Interface;
using Hydro.DAL;
using Hydro.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hydro.BAL.Service
{
    public class LegalDocumentRepository : ILegalDocumentRepository
    {
        private readonly HydroDBContext _context;
        public LegalDocumentRepository(HydroDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void Add(LegalDocument legalDocument)
        {
            _context.LegalDocuments.Add(legalDocument);
        }

        public void Delete(long Id)
        {
            var existingParent = _context.LegalDocuments.Where(x => x.Id == Id).FirstOrDefault();
            existingParent.Isdelete = true;
            _context.LegalDocuments.Update(existingParent);
        }

        public List<LegalDocument> GetAll()
        {
            return _context.LegalDocuments.ToList();
        }

        public LegalDocument GetById(long Id)
        {
            return _context.LegalDocuments.Where(c => c.Id == Id).FirstOrDefault();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(LegalDocument legalDocument)
        {
            var existingParent = _context.LegalDocuments.Where(x => x.Id == legalDocument.Id).SingleOrDefault();
            if (existingParent != null)
            {
                _context.Entry(existingParent).CurrentValues.SetValues(legalDocument);
            }
        }
    }
}
