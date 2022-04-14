using Hydro.BAL.DTO;
using Hydro.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hydro.BAL.Interface
{
   public interface INotificationRepository
    {
        Notification GetNotificationByID(long ID);
        Notification GetNotificationByIDAndNotName(long id,string notName);

        User UserDetails(string userLogin);
        User UserDetailsById(string userLogin);
        void AddNotification(Notification obj);
        void Update(Notification obj);

        int GetNotificationcCount(string role); // count to role admin

        List<Notification> GetLatestNotification(string role);
        //PagedResult<Notification> GetNotificationList(int page, int pageSize, string Role);
        List<Notification> GetNotificationListWithoutPaging(string Role);

        bool Save();
    }
}
