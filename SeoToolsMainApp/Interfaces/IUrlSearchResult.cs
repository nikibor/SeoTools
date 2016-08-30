using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeoToolsMainApp.Interfaces
{
    interface IUrlSearchResult
    {
        string Domen { set; get; }
        string YandexSearch { get; set; }
        string YandexImagesSearch { set; get; }
        string YandexIndexPagesSearch { set; get; }
        string YandexNewsSearch { set; get; }
        string YandexVirusCheck { set; get; }
        string YandexOrphographyCheck { set; get; }
        string HttpServerInformation { set; get; }
        string GoogleSearch { set; get; }
        string GoogleImagesSearch { set; get; }
        string LinkPadStatistics { set; get; }
        string DmozCatalog { set; get; }
        string GoogleSafeBrowserCheck { set; get; }
        string LiveInternetCatalog { set; get; }
        string MainWord { set; get; }
    }
}
