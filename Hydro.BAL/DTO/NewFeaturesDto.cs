using Hydro.DAL.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hydro.BAL.DTO
{
    public class NewFeaturesDto
    {
        public long Id { set; get; }

        public string Email { set; get; }

  
        public string Phone { set; get; }

  
        public string Organization { set; get; }

        public string Position { set; get; }

    
        public DateTime NewFeatureDate { set; get; }

        public string Region { set; get; }

    
        public string Character { set; get; }

      
        public int Status { set; get; }

     
        public string Purpose { set; get; }

   
        public string Description { set; get; }
        public int RequestStatus { get; set; }

        public List<DocumentFile> ListOfFiles { get; set; }
    }
}
