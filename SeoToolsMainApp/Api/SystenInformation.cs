using System.Text.RegularExpressions;
using SeoToolsMainApp.Core;
using SeoToolsMainApp.Interfaces;
using SeoToolsMainApp.Models;

namespace SeoToolsMainApp.Api
{
    /// <summary>
    /// Получение системной информации передоваемой в http заголовке
    /// </summary>
    public class SystemInformation : AbstractApi, IHttpHeadersOfServer
    {
        public string InformationAboutServer { set; get; }

        public SystemInformation(string url)
        {
            string domen = url.Remove(0, url.IndexOf('/') + 2);
            string Url = $"http://pr-cy.ru/headers/{domen}";
            InformationAboutServer = HttpProtocol.GetDataFromHtml(Url, "//pre[@class='prettyprint lang-bsh']");
            //Regex regex = new Regex(@"(\r\n|\r|\n)+");
            //if (InformationAboutServer != null)
            //    InformationAboutServer = regex.Replace(InformationAboutServer, "<br />");
        }
    }
}
