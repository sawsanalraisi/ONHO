using Hydro.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hydro.BAL.Interface
{
   public interface IServiceRequestRepository
    {
        List<ServiceRequestType> GetAll();
        ServiceRequestType GetById(long Id);

        void Update(ServiceRequestType serviceRequest);
        void Add(ServiceRequestType serviceRequest);
        void Delete(long Id);
        bool Save();
    }
}
