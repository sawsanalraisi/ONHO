using Hydro.DAL.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hydro.BAL.DTO
{
   public class DifferentRepDto
    {

        public long Id { set; get; }


        public string Email { set; get; }

        public string Phone { set; get; }


        public string Organization { set; get; }


        public int ReportType { set; get; }

        public string Position { set; get; }


        public DateTime DifferentRepDate { set; get; }

        public string Region { set; get; }


        public string Character { set; get; }

        public string Purpose { set; get; }

        public string Description { set; get; }
        public bool Isdelete { set; get; } = false;
        public int Status { get; set; }

        public string UploadFiles { get; set; }
        public List<DocumentFile> ListOfFiles { get; set; }

    }
}
