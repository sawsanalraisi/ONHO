using Hydro.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hydro.BAL.Interface
{
   public interface IFileFormatRepository
    {
        List<FileFormat> GetAll();
        FileFormat GetById(long Id);
        void Update(FileFormat fileFormat);
        void Add(FileFormat fileFormat);
        void Delete(long Id);
        bool Save();
    }
}
