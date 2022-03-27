using Hydro.BAL.DTO;
using Hydro.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hydro.BAL.Interface
{
   public interface IContactUsRepository
    {
        ContactUs GetContactUsByID(long ID);
        void AddContactUs(ContactUs obj);
        PagedResult<ContactUs> GetContactUsListForAdmin(int page, int pageSize, string Search);
        void DeleteContactUs(long id);


        bool Save();
    }
}
