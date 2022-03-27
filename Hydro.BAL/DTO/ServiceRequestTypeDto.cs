using Hydro.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hydro.BAL.DTO
{
    public class ServiceRequestTypeDto
    {
        public long Id { get; set; }
        public int Status { get; set; }

        public DateTime Years { get; set; }
        public int Quantity { get; set; }
        public string Postion { get; set; }
        public string Purpose { get; set; }
        public string Description { get; set; }
        public string Region { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateAt { get; set; }

        public DateTime CreateAt { get; set; }
        public string CreateBy { get; set; }
        public long CategoryId { get; set; }
        public long FileFormatId { get; set; }
        public FileFormat FileFormat { get; set; }
        public Category Categories { get; set; }

    }
}
