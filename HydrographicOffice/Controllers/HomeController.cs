using HydrographicOffice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HydrographicOffice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult ChangeLanguage()
        {

            CultureInfo culture = null;
            if ("en-US" == CultureInfo.CurrentCulture.Name)
            {
                culture = new CultureInfo("ar-EG");
            }
            else
            {
                culture = new CultureInfo("en-US");
            }
                  Response.Cookies.Append(
                  CookieRequestCultureProvider.DefaultCookieName,
                  CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
              new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
              );
            string nameof = CultureInfo.CurrentCulture.Name;
            string referer = Request.Headers["Referer"].ToString();
            return Redirect(referer);

        }
    }
}
