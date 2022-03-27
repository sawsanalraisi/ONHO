using Hydro.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hydro.BAL.Interface
{
   public interface INewFeatureRepository
    {
        List<NewFeature> GetAll();
         NewFeature GetById(long Id);
        void Update(NewFeature newFeature);
        void Add(NewFeature newFeature);
        void AddDocument(List<DocumentFile> documentFiles, long Paraentid);

        void Delete(long Id);
        bool Save();
    }
}
