using Hydro.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hydro.BAL.Interface
{
   public interface IDifferentReportsRepository
    {
        List<DifferentReport> GetAll();
        DifferentReport GetById(long Id);
        void Update(DifferentReport differentReports);
        void Add(DifferentReport differentReports);
        void AddDocument(List<DocumentFile> documentFiles, long Paraentid);
        void Delete(long Id);
        bool Save();
    }
}
