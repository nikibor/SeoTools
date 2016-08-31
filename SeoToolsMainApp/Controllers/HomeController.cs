using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeoToolsMainApp.Core;
using SeoToolsMainApp.Models;

namespace SeoToolsMainApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Scan(string url)
        {
            url = HttpProtocol.HttpPrefixCheck(url);
            if (HttpProtocol.IsUrl(url) && HttpProtocol.ExistUrl(url))
            {                
                var model = new DividedModel(url);
                return View(model);
            }
            else
                return View("ErrorPage");
        }
    }
}