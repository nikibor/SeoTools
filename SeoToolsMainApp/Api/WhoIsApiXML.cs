using System.Configuration;
using System.Xml;
using SeoToolsMainApp.Core;
using System.Text;
using SeoToolsMainApp.Interfaces;
using SeoToolsMainApp.Models;

namespace SeoToolsMainApp.Api
{
    /// <summary>
    /// Получение информации о домене
    /// </summary>
    public class WhoIsApiXml : AbstractApi, IWhoIsApiXml
    { 
        public string CreatedDate { set; get; }
        public string ExpiresDate { set; get; }
        public string Organization { set; get; }
        public string Host { set; get; }
        public string Status { set; get; }
        public WhoIsApiXml(string url)
        {
            Url = url;
            TakeData();
        }

        private void TakeData()
        {
            string adress =
                $"http://www.whoisxmlapi.com/whoisserver/WhoisService?domainName={Url}&username={ConfigurationManager.AppSettings["WhoIsApiUsername"]}&password={ConfigurationManager.AppSettings["WhoIsApiPassword"]}";
            string response = HttpProtocol.TakeData(adress, "GET", Encoding.UTF8);
            Parse(response);
        }

        public void Parse(string response)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(response);
            if (doc.DocumentElement != null)
                foreach (XmlNode noda in doc.DocumentElement)
                {
                    XmlNodeList xnList = doc.SelectNodes("/WhoisRecord/registryData");
                    foreach (XmlNode xn in xnList)
                    {
                        CreatedDate = xn["createdDate"]?.InnerText;
                        ExpiresDate = xn["expiresDate"]?.InnerText;
                        Status = xn["status"]?.InnerText;
                    }
                    xnList = doc.SelectNodes("/WhoisRecord/registryData/registrant");
                    foreach (XmlNode xn in xnList)
                    {
                        Organization = xn["organization"]?.InnerText;
                    }
                    xnList = doc.SelectNodes("/WhoisRecord/registryData/nameServers");
                    foreach (XmlNode xn in xnList)
                    {
                        Host = xn["rawText"]?.InnerText;
                    }
                }
        }
    }
}