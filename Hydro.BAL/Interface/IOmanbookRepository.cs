using Hydro.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hydro.BAL.Interface
{
   public interface IOmanbookRepository
    {
        List<Omanbook> GetAll();
        Omanbook GetById(long Id);
        void Update(Omanbook omanbook);
        void Add(Omanbook omanbook);
        void Delete(long Id);
        bool Save();
    }
}
