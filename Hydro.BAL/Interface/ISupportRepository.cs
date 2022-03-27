using Hydro.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hydro.BAL.Interface
{
   public interface ISupportRepository
    {
        void AddLog(Logs obj);

 

        bool Save();
    }
}
