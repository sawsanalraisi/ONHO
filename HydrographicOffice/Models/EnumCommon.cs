using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HydrographicOffice.Models
{
    public class EnumCommon
    {
      public enum NoticeToMariner
        {
            [Display(Name = "Oman Notice To Mariner")]
            Oman = 1,
            [Display(Name = "British Notice To Mariner")]
            British = 2
        }

        public enum NavigationWarning
        {
            [Display(Name = "Inforce")]
            Inforce = 1,
            [Display(Name = "Cancelled")]
            Cancelled = 2
        }

        public enum DifferentReportType
        {
            [Display(Name = "Malfunction of the Navigation Aids")]
            Malfunction = 1,
            [Display(Name = "Navigation Hazards")]
            Navigation_Hazards = 2,
            [Display(Name = "New Servy")]
            New_Servy = 3,
            [Display(Name = "Special Report")]
            Special_Report = 4,

        }
        public enum StatusNewFeature
        {
            [Display(Name ="Temporary")]
            Temporary=1,
            [Display(Name = "Permeant")]
            Permeant=2

        }

        public enum SpecialTaskTType
        {
            [Display(Name ="Training")]
            Training=1,
            [Display(Name ="Others")]
            Others=2
        }
        public enum ServiceType
        {
            [Display(Name ="Product")]
            Product=1,
            [Display(Name = "Data")]
            Data=2

        }

        public enum SurveyType
        {
            [Display(Name ="Multi-Beam")]
            MultiBeam=1,
            [Display(Name = "Single-Beam")]
            SingleBeam = 2,

        }

        public enum RequestStatus
        {
            [Display(Name = "Pendding")]
            Pendding = 1,
            [Display(Name = "Approve")]
            Approve = 2,
            [Display(Name = "Rejected")]
            Rejected = 3,
        }
    }
}
