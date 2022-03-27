using Hydro.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hydro.BAL.Interface
{
   public interface INoticeToMarinerRepository
    {
        List<NoticeToMariner> GetAll();
        NoticeToMariner GetById(long Id);
        void Update(NoticeToMariner noticeToMariner);
        void Add(NoticeToMariner noticeToMariner);
        void Delete(long Id);
        bool Save();
    }
}
