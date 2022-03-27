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
    public class ServiceRequestRepository : IServiceRequestRepository
    {
        private readonly HydroDBContext _context;
        public ServiceRequestRepository(HydroDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void Add(ServiceRequestType serviceRequest)
        {
            _context.ServiceRequestTypes.Add(serviceRequest);
        }

        public void Delete(long Id)
        {
            //var existingParent = _context.ServiceRequestTypes.Where(x => x.Id == Id).FirstOrDefault();
            //existingParent.Isdelete = true;
            //_context.ServiceRequestTypes.Update(existingParent);
        }

        public List<ServiceRequestType> GetAll()
        {
            return _context.ServiceRequestTypes.Include(x=>x.Categories).Include(c =>c.FileFormat).ToList();
        }

        public ServiceRequestType GetById(long Id)
        {
            return _context.ServiceRequestTypes.Where(c => c.Id == Id).FirstOrDefault();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Update(ServiceRequestType serviceRequest)
        {
            var existingParent = _context.ServiceRequestTypes.Where(x => x.Id == serviceRequest.Id).SingleOrDefault();
            if (existingParent != null)
            {
                _context.Entry(existingParent).CurrentValues.SetValues(serviceRequest);
            }
        }
    }
}
