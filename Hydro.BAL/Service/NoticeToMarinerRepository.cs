using Hydro.BAL.Interface;
using Hydro.DAL;
using Hydro.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydro.BAL.Service
{
    public class NoticeToMarinerRepository : INoticeToMarinerRepository
    {
        private readonly HydroDBContext _context;

        public NoticeToMarinerRepository(HydroDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void Add(NoticeToMariner noticeToMariner)
        {
            _context.NoticeToMariners.Add(noticeToMariner);
        }

        public void Delete(long Id)
        {
            var existingParent = _context.NoticeToMariners.Where(x => x.Id == Id).FirstOrDefault();
            existingParent.Isdelete = true;
            _context.NoticeToMariners.Update(existingParent);
        }

        public List<NoticeToMariner>  GetAll()
        {
            return _context.NoticeToMariners.ToList();

        }
        public NoticeToMariner GetById(long Id)
        {
          return _context.NoticeToMariners.Where(c =>c.Id ==Id).FirstOrDefault();          
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(NoticeToMariner noticeToMariner)
        {
            var existingParent = _context.NoticeToMariners.Where(x => x.Id == noticeToMariner.Id).SingleOrDefault();
            if (existingParent != null)
            {
                _context.Entry(existingParent).CurrentValues.SetValues(noticeToMariner);
            }
        }

    }
}
