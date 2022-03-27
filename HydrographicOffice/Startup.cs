using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hydro.DAL;
using Hydro.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Hydro.BAL.Interface;
using Hydro.BAL.Service;
using AutoMapper;
using HydrographicOffice.Mapping;
using System.Reflection;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Localization;
using HydrographicOffice.Resoures;
using HydrographicOffice.Utilities;
using System.Globalization;
using System.Reflection;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace HydrographicOffice
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation();


            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;



            })

           .AddEntityFrameworkStores<HydroDBContext>();
            services.AddDbContext<HydroDBContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("HydroConnectionString"));
            });

            services.AddScoped<INoticeToMarinerRepository, NoticeToMarinerRepository>();
            services.AddScoped<INavigationWRepository, NavigationWRepository>();
            services.AddScoped<IDifferentReportsRepository, DifferentReportsRepository>();
            services.AddScoped<INewFeatureRepository, NewFeatureRepository>();
            services.AddScoped<ISpecialTaskRepository, SpecialTaskRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>(); 
            services.AddScoped<IFileFormatRepository, FileFormatRepository>();
            services.AddScoped<IServiceRequestRepository, ServiceRequestRepository>();
            services.AddScoped<INewSurveyRepository, NewSurveyRepository>();
            services.AddScoped<ISupportRepository, SupportRepository>();
            services.AddScoped<IContactUsRepository, ContactUsRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddAuthentication().AddCookie();




            services.AddSingleton<CultureLocalizer>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddControllersWithViews().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
            .AddDataAnnotationsLocalization(
            o =>
            {
                var type = typeof(ViewResource);
                var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
                var factory = services.BuildServiceProvider().GetService<IStringLocalizerFactory>();
                var localizer = factory.Create("ViewResource", assemblyName.Name);
                o.DataAnnotationLocalizerProvider = (t, f) => localizer;
            }
            );
              services.AddControllersWithViews().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
             .AddDataAnnotationsLocalization(
             o =>
             {
                 var type = typeof(ViewResource);
                 var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
                 var factory = services.BuildServiceProvider().GetService<IStringLocalizerFactory>();
                 var localizer = factory.Create("ViewResource", assemblyName.Name);
                 o.DataAnnotationLocalizerProvider = (t, f) => localizer;
             }
             );

            services.Configure<LocalizationOptions>(Options => {

                Options.ResourcesPath = "Resoures";
            }
            );
            services.Configure<RequestLocalizationOptions>(Options =>
            {
                var supportedCultures = new List<CultureInfo> {
                     new CultureInfo("ar-EG"),
                    new CultureInfo("en-US")

               };
                Options.DefaultRequestCulture = new RequestCulture("en-US");
                Options.DefaultRequestCulture = new RequestCulture("ar-EG");
                // Formatting numbers, dates, etc.
                Options.SupportedCultures = supportedCultures;
                // UI strings that we have localized.
                Options.SupportedUICultures = supportedCultures;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRequestLocalization();
            app.UseRouting();

                app.UseAuthorization();
                app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                 name: "areas",
                 pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
