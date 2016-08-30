using SeoToolsMainApp.Interfaces;
using SeoToolsMainApp.Core;
using SeoToolsMainApp.Models;

namespace SeoToolsMainApp.Api
{
    /// <summary>
    /// Генерация ссылок на сторонние сервисы
    /// </summary>
    public class UrlSearchResult : AbstractApi, IUrlSearchResult
    {
        public string Domen { set; get; }
        public string YandexSearch { get; set; }
        public string YandexImagesSearch { set; get; }
        public string YandexIndexPagesSearch { set; get; }
        public string YandexNewsSearch { set; get; }
        public string YandexVirusCheck { set; get; }
        public string YandexOrphographyCheck { set; get; }
        public string HttpServerInformation { set; get; }
        public string GoogleSearch { set; get; }
        public string GoogleImagesSearch { set; get; }
        public string LinkPadStatistics { set; get; }
        public string DmozCatalog { set; get; }
        public string GoogleSafeBrowserCheck { set; get; }
        public string LiveInternetCatalog { set; get; }
        public string MainWord { set; get; }
        /// <summary>
        /// Формирование ссылок на сторонние сервисы
        /// </summary>
        /// <param name="url"></param>
        public UrlSearchResult(string url)
        {
            Url = url;
            Domen = HttpProtocol.CreateDomen(url);
            //string domen = HttpProtocol.CreateDomen(url);
            YandexSearch = $"https://yandex.ru/yandsearch?text={Domen}&lr=0&noreask=1&redircnt=1469797390.1";
            YandexImagesSearch = $"https://yandex.ru/images/search?itype=any&site={Domen}&redircnt=1469797912.1";
            YandexIndexPagesSearch =
                $"https://yandex.ru/yandsearch?text=host%3A{Domen}%20%7C%20host%3Awww.mik-coop.ru&how=tm&lr=195&redircnt=1469798041.1";
            YandexNewsSearch = $"https://news.yandex.ru/yandsearch?text={Domen}&rpt=nnews2";
            YandexVirusCheck = $"https://yandex.ru/infected?url={Domen}&redircnt=1469798199.1";
            YandexOrphographyCheck = $"https://old.webmaster.yandex.ru/spellcheck.xml?checkurl={Domen}";
            HttpServerInformation = $"http://pr-cy.ru/headers/{Domen}";
            GoogleSearch =
                $"https://www.google.ru/search?q=link:{Domen}&gws_rd=cr&ei=plibV8KCN8qXsgGM94TgBg#newwindow=1&q={Domen}";
            GoogleImagesSearch = $"https://www.google.ru/search?q={Domen}&tbm=isch&gws_rd=ssl";
            LinkPadStatistics = $"https://www.linkpad.ru/?search={Domen}";
            DmozCatalog = $"http://www.dmoz.org/search?q={Domen}&t=null&all=no&cat=all";
            GoogleSafeBrowserCheck =
                $"https://www.google.com/transparencyreport/safebrowsing/diagnostic/?hl=ru#url={Domen}";
            LiveInternetCatalog = $"http://www.liveinternet.ru/q/?q={Domen}&t=web";
            MainWord = Domen.Remove(Domen.IndexOf('.'), Domen.Length - Domen.IndexOf('.'));
        }
    }
}