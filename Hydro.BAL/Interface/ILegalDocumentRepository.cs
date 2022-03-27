using Hydro.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hydro.BAL.Interface
{
   public interface ILegalDocumentRepository
    {
        List<LegalDocument> GetAll();
        LegalDocument GetById(long Id);
        void Update(LegalDocument legalDocument);
        void Add(LegalDocument legalDocument);
        void Delete(long Id);
        bool Save();
    }
}
