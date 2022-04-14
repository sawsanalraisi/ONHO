using Hydro.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hydro.DAL
{
   public class HydroDBContext : IdentityDbContext<User>
    {
        
        public HydroDBContext(DbContextOptions<HydroDBContext> options) : base(options)
        {
        }

        public DbSet<NoticeToMariner> NoticeToMariners { get; set; }
        public DbSet<NavigationWarning> NavigationWarnings { get; set; }
        public DbSet<DifferentReport> DifferentReports { get; set; }
        public DbSet<NewFeature> NewFeatures { get; set; }
        public DbSet<SpecialTask> SpecialTasks { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<LegalDocument> LegalDocuments { get; set; }
        public DbSet<NewSurvey> NewSurveys { get; set; }
        public DbSet<FileFormat> FileFormats { get; set; }
        public DbSet<SuveryFileFormat> SuveryFileFormats { get; set; }
        public DbSet<DocumentFile> DocumentFiles { get; set; }
        public DbSet<ServiceRequestType> ServiceRequestTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Logs> Logs { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }

        public DbSet <Order> Orders { get; set; }
        public DbSet<News> Newss { get; set; }
        
        public DbSet<BeforProces> BeforProcess { get; set; }
        public DbSet<EmailConfigur> EmailConfigurs { get; set; }
        public DbSet<Notification> Notifications { get; set; }

    }
}
