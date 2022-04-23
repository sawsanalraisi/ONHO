using Hydro.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hydro.BAL.Interface
{
    public interface INewsRepository
    {
        List<News> GetAll();
        News  GetById(long Id);
        void Update(News news);
        void Add(News news);
        void Delete(long Id);
    }
}
