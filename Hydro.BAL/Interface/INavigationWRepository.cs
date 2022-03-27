using Hydro.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hydro.BAL.Interface
{
    public interface INavigationWRepository
    {
        List<NavigationWarning> GetAll();
        NavigationWarning GetById(long Id);
        void Update(NavigationWarning navigationWarning);
        void Add(NavigationWarning navigationWarning);
        void Delete(long Id);
        bool Save();
    }
}
