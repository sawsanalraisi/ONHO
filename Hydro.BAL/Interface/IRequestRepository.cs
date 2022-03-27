using Hydro.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hydro.BAL.Interface
{
    public interface IRequestRepository
    {
        List<Request> GetAll();
        Request GetById(long Id);
        void Update(Request request);
        void Add(Request request);
        void Delete(long Id);
        bool Save();
    }
}
