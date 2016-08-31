using SeoToolsMainApp.Core;
using SeoToolsMainApp.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeoToolsMainApp.Interfaces;
using SeoToolsMainApp.Models;

namespace SeoToolsMainApp.Controllers
{
    public class TestingController : Controller
    {
        // GET: Testing
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public ActionResult Scan(string url)
        {
            url = HttpProtocol.HttpPrefixCheck(url);
            
            if (HttpProtocol.IsUrl(url))
            {
                var screen = new ScreenShoot(url);
                var model = new DividedModel(url);
                //model.Api.Add(screen);

                //var pageSpeed = new GooglePageSpeedApi(url);
                //var headers = new SystemInformation(url);
                //var searchResult = new UrlSearchResult(url);
                //var whoIs = new WhoIsApiXml(url);
                //var yandex = new YandexIndex(url);
                return View(model);
            }
            else
                return View("ErrorPage");
        }
    }
}