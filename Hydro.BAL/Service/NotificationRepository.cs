using Hydro.BAL.Interface;
using Hydro.DAL;
using Hydro.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hydro.BAL.Service
{
   public class NotificationRepository: INotificationRepository
    {
        private readonly HydroDBContext _context;
        public NotificationRepository(HydroDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }
     

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }


        public Notification GetNotificationByID(long Id)
        {

            return _context.Notifications
               .Where(x => x.RefId == Id).FirstOrDefault();
        }

        public User UserDetails(string userLogin)
        {

            return _context.Users.Where(x => x.UserName == userLogin).FirstOrDefault(); ;
        }

        public User UserDetailsById(string userLogin)
        {

            return _context.Users.Where(x => x.Id == userLogin).FirstOrDefault(); ;
        }

        public void AddNotification(Notification obj)
        {
            _context.Notifications.Add(obj);

        }
        public void Update(Notification obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();

        }
        public void ReviewNotification(long NewsId)
        {
            //var existingParent = _context.Notifications.Where(x => x.NewId == NewsId).ToList();
            //foreach (var item in existingParent)
            //{
            //    item.isRead = true;
            //    _context.Notifications.Update(item);
            //}


        }


        public int GetNotificationcCount(string Role)
        {
            return _context.Notifications
               .Where(x => x.AssignTo == Role && x.isRead == false).ToList().Count();
        }

        //public PagedResult<Notification> GetNotificationList(int page, int pageSize, string Role)
        //{
        //    var result = new PagedResult<Notification>();
        //    var query = new List<Notification>();


        //    query = _context.Notifications
        //        .Where(x => x.isRead == false && x.AssignTo == Role)
        //        .OrderByDescending(x => x.CreateDate).OrderByDescending(x => x.Id).ToList();

        //    result.CurrentPage = page;
        //    result.RowCount = query.Count();
        //    result.PageSize = pageSize;
        //    var pageCount = (double)result.RowCount / pageSize;
        //    result.PageCount = (int)Math.Ceiling(pageCount);
        //    var skip = (page - 1) * pageSize;
        //    result.Results = query.Skip(skip).Take(pageSize).ToList();
        //    return result;
        //}


        public List<Notification> GetLatestNotification(string role)
        {
            return _context.Notifications
                .Where(x => x.AssignTo == (role) && x.isRead == false)
                .OrderByDescending(x => x.CreateDate).ToList();
        }


        public List<Notification> GetNotificationListWithoutPaging(string Role)
        {
            return _context.Notifications
                  .Where(x => x.isRead == false && x.AssignTo == Role)
                  .OrderByDescending(x => x.CreateDate).OrderByDescending(x => x.Id).ToList();

        }

        public Notification GetNotificationByIDAndNotName(long id, string notName)
        {
            return _context.Notifications.Where(c => c.RefId == id && c.NotificationName == notName).FirstOrDefault();
        }
    }
}
