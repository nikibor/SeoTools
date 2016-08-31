using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using SeoToolsMainApp.Interfaces;
using SeoToolsMainApp.Core;
using SeoToolsMainApp.Models;

namespace SeoToolsMainApp.Api
{
    public class GoogleSafeBrowser: AbstractApi, IGoogleSafeBrowsing
    {
        public string HaveViruses { set; get; }
        public string ColorMessage { set; get; }

        /// <summary>
        /// Проверка ссылки на наличие вирусов при помощи Google Safe Browsing
        /// </summary>
        /// <returns>true - безопасно, false - содержит вирусы</returns>
        public GoogleSafeBrowser(string url)
        {
            try
            {
                string request =$"https://safebrowsing.googleapis.com/v4/threatMatches:find?key={ConfigurationManager.AppSettings["GoogleSafeBrowsingApiKey"]}";
                string method = "POST";
                string contentType = "application/json";
                string data =
                    "{'client': {'clientId': 'opslog','clientVersion': '1.0.0'},'threatInfo':{'platformTypes': ['ANY_PLATFORM'],'threatEntries': [{'url': '" +
                    url +
                    "'}],'threatEntryTypes': ['THREAT_ENTRY_TYPE_UNSPECIFIED','URL','EXECUTABLE','IP_RANGE'],'threatTypes': ['THREAT_TYPE_UNSPECIFIED','MALWARE','SOCIAL_ENGINEERING','UNWANTED_SOFTWARE', 'POTENTIALLY_HARMFUL_APPLICATION']}}";

                var response = HttpProtocol.TakeData(request, method, contentType, data);
                HaveViruses = (data == "{}\n") ? "Сайт находится в реестре опасных сайтов" : "Сайт не содержит вирусов";
                ColorMessage = (data == "{}\n") ? "red" : "forestgreen";
            }
            catch (Exception)
            {
                //ignored
            }
        }
    }
}