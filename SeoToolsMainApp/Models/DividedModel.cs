using SeoToolsMainApp.Api;
using SeoToolsMainApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeoToolsMainApp.Models
{
    public class DividedModel
    {
        public DividedModel() { }      
        public DividedModel(string url)
        {            
            Api.Add("_GooglePageSpeed", new GooglePageSpeedApi(url));
            Api.Add("_GoogleSafeBrowsing", new GoogleSafeBrowser(url));
            Api.Add("_PageScan", new PageScan(url));
            Api.Add("_SystemInformation", new SystemInformation(url));
            Api.Add("_UrlSearch", new UrlSearchResult(url));
            Api.Add("_WhoIsApi", new WhoIsApiXml(url));
            Api.Add("_Yandex", new YandexIndex(url));
            Api.Add("_ScreenShoot", new ScreenShoot(url));
        }

        public Dictionary<string, AbstractApi> Api = new Dictionary<string, AbstractApi>();
        public string Url { set; get; }
    }
}