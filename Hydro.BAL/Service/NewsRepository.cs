using Hydro.BAL.Interface;
using Hydro.DAL;
using Hydro.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hydro.BAL.Service
{
    public class NewsRepository : INewsRepository
    {
        private readonly HydroDBContext _context;

        public NewsRepository(HydroDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void Add(News news)
        {
            _context.Newss.Add(news);
        }

        public void Delete(long Id)
        {
            var existingParent = _context.Newss.Where(x => x.Id == Id).FirstOrDefault();
            _context.Newss.Update(existingParent);
        }

        public List<News> GetAll()
        {
           return _context.Newss.ToList();
        }

        public News GetById(long Id)
        {
           return _context.Newss.Where(c => c.Id == Id).FirstOrDefault();
        }

        public void Update(News news)
        {
            var existingParent = _context.Newss.Where(x => x.Id == news.Id).SingleOrDefault();
            if (existingParent != null)
            {
                _context.Entry(existingParent).CurrentValues.SetValues(news);
            }
        }
    }
}
