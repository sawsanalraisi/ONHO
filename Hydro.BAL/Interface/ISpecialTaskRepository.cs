using Hydro.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hydro.BAL.Interface
{
  public  interface ISpecialTaskRepository
    {
        List<SpecialTask> GetAll();
        SpecialTask GetById(long Id);
        void Update(SpecialTask specialTask);
        void Add(SpecialTask specialTask);
        void AddDocument(List<DocumentFile> documentFiles, long Paraentid);

        void Delete(long Id);
        bool Save();
    }
}
