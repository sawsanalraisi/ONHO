using Hydro.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hydro.BAL.Interface
{
  public  interface ICategoryRepository
    {
        List<Category> GetAll();
        Category GetById(long Id);
        void Update(Category servcieType);
        void Add(Category servcieType);
        void Delete(long Id);
        bool Save();
    }
}
