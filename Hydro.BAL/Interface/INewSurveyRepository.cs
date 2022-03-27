using Hydro.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hydro.BAL.Interface
{
  public interface INewSurveyRepository
    {
        List<NewSurvey> GetAll();
        NewSurvey GetById(long Id);
        void Update(NewSurvey newSurvey);
        void AddLegalDocument(List<LegalDocument> documentFiles, long SurveyId);

        void Add(NewSurvey newSurvey);
        void Delete(long Id);
        bool Save();
    }
}
