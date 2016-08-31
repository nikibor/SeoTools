using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeoToolsMainApp.Interfaces;
using SeoToolsMainApp.Api;
using System.ComponentModel;

namespace SeoToolsMainApp.Models
{
    public class SeoScan : IGooglePageSpeed, IGoogleSafeBrowsing, IHttpHeadersOfServer, IPageScan, IScreenShoot, IUrlSearchResult, IWhoIsApiXml, IYandexIndex
    {        
        [DisplayName("Адрес")]        
        public string Url { set; get; }
        [DisplayName("Дата регистрации домена")]
        public string CreatedDate { set; get; }
        [DisplayName("Количество Css элементов на странице")]
        public int CssCount { set; get; }
        [DisplayName("Размер Css элементов")]
        public string CssSize { set; get; }
        [DisplayName("Наличие в Dmoz каталогах")]
        public string DmozCatalog { set; get; }
        [DisplayName("Домен")]
        public string Domen { set; get; }
        [DisplayName("Дата истечения сроков пользования доменом")]
        public string ExpiresDate { set; get; }
        [DisplayName("Поиск в Google картинках")]
        public string GoogleImagesSearch { set; get; }
        [DisplayName("Проверка в Google Safe Browsing")]
        public string GoogleSafeBrowserCheck { set; get; }
        [DisplayName("Поиск в Google")]
        public string GoogleSearch { set; get; }
        [DisplayName("Наличие альтернативного текста у картинок")]
        public bool HaveAltImgText { set; get; }
        [DisplayName("Наличие комментируемого кода")]
        public bool HaveComments { set; get; }
        [DisplayName("Наличие тега Description")]
        public bool HaveDescription { set; get; }
        [DisplayName("Наличие тега Footer")]
        public bool HaveFooter { set; get; }
        [DisplayName("Наличие тега Header")]
        public bool HaveHeader { set; get; }
        [DisplayName("Присутствие ключевых слов SEO")]
        public bool HaveKeyWords { set; get; }
        [DisplayName("Наличие тега noindex")]
        public bool HaveNoindex { set; get; }
        [DisplayName("Наличие тега robots")]
        public bool HaveRobots { set; get; }
        [DisplayName("Наличие описания у картинок")]
        public bool HaveTitleImg { set; get; }
        [DisplayName("Проверка на наличие вирусов GoogleSafeBrowsing")]
        public bool HaveViruses { set; get; }
        [DisplayName("Хост")]
        public string Host { set; get; }
        [DisplayName("Размер страницы целиком")]
        public string HtmlSize { set; get; }
        [DisplayName("Заголовки сервера")]
        public string HttpServerInformation { set; get; }
        [DisplayName("Размер картинок на странице")]
        public string ImageSize { set; get; }
        [DisplayName("Сервер")]
        public string InformationAboutServer { set; get; }
        [DisplayName("Размер всего JavaScript")]
        public string JavaScriptSize { set; get; }
        [DisplayName("Проверка на LinkPad")]
        public string LinkPadStatistics { set; get; }
        [DisplayName("Наличие в каталоге LiveInternet")]
        public string LiveInternetCatalog { set; get; }
        [DisplayName("Ключевое слово")]
        public string MainWord { set; get; }
        [DisplayName("Картинка для мобильных устройств")]
        public string MobileUrl { set; get; }
        [DisplayName("Количество Css файлов")]
        public string NumberCssResources { set; get; }
        [DisplayName("Количество JavaScript файлов")]
        public string NumberJsResources { set; get; }
        [DisplayName("Количество хостов")]
        public string NumberOfHosts { set; get; }
        [DisplayName("Количество ресурсов")]
        public string NumberStaticOfResources { set; get; }
        [DisplayName("Компания зарегистрировшая домен")]
        public string Organization { set; get; }
        [DisplayName("Оценка скорости загрузки сайта Google PageSpeed")]
        public string SpeedScore { set; get; }
        [DisplayName("Статус сайта")]
        public string Status { set; get; }
        [DisplayName("Яндекс индекс цитируемости")]
        public string TcyIndex { set; get; }
        [DisplayName("Яндекс оценка SEO")]
        public string TcyRang { set; get; }
        [DisplayName("Яндекс каталоги")]
        public string TextInfo { set; get; }
        [DisplayName("Заголовок страницы")]
        public string TitleOfSite { set; get; }
        [DisplayName("Поиск в Яндекс картинках")]
        public string YandexImagesSearch { set; get; }
        [DisplayName("Поиск индексируемых страниц в Яндекс")]
        public string YandexIndexPagesSearch { set; get; }
        [DisplayName("Поиск в Яндекс новостях")]
        public string YandexNewsSearch { set; get; }
        [DisplayName("Проверка орфографии на странице")]
        public string YandexOrphographyCheck { set; get; }
        [DisplayName("Поиск в Яндекс")]
        public string YandexSearch { set; get; }
        [DisplayName("Проверка на вирусы Яндексом")]
        public string YandexVirusCheck { set; get; }
        [DisplayName("Картинка на десктопах")]
        public string DesktopUrl { set; get; }
        public SeoScan(string url)
        {
            GooglePageSpeedApi googlePageSpeed = new GooglePageSpeedApi(url);
            TitleOfSite = googlePageSpeed.TitleOfSite;
            SpeedScore = googlePageSpeed.SpeedScore;
            NumberOfHosts = googlePageSpeed.NumberOfHosts;
            NumberStaticOfResources = googlePageSpeed.NumberStaticOfResources;
            NumberJsResources = googlePageSpeed.NumberJsResources;
            NumberCssResources = googlePageSpeed.NumberCssResources;
            HtmlSize = googlePageSpeed.HtmlSize;
            CssSize = googlePageSpeed.CssSize;
            ImageSize = googlePageSpeed.ImageSize;
            JavaScriptSize = googlePageSpeed.JavaScriptSize;

            GoogleSafeBrowser googleSafeBrowser = new GoogleSafeBrowser(url);
            HaveViruses = googleSafeBrowser.HaveViruses;

            SystemInformation systemInformation = new SystemInformation(url);
            InformationAboutServer = systemInformation.InformationAboutServer;

            PageScan pageScan = new PageScan(url);
            HaveNoindex = pageScan.HaveNoindex;
            HaveComments = pageScan.HaveComments;
            HaveDescription = pageScan.HaveDescription;
            HaveKeyWords = pageScan.HaveKeyWords;
            CssCount = pageScan.CssCount;
            HaveAltImgText = pageScan.HaveAltImgText;
            HaveTitleImg = pageScan.HaveTitleImg;
            HaveRobots = pageScan.HaveRobots;
            HaveHeader = pageScan.HaveHeader;
            HaveFooter = pageScan.HaveFooter;

            ScreenShoot screenShoot = new ScreenShoot(url);
            DesktopUrl = screenShoot.DesktopUrl;
            MobileUrl = screenShoot.MobileUrl;

            UrlSearchResult urlSearch = new UrlSearchResult(url);
            Domen = urlSearch.Domen;
            YandexSearch = urlSearch.YandexSearch;
            YandexImagesSearch = urlSearch.YandexImagesSearch;
            YandexIndexPagesSearch = urlSearch.YandexIndexPagesSearch;
            YandexNewsSearch = urlSearch.YandexNewsSearch;
            YandexVirusCheck = urlSearch.YandexVirusCheck;
            YandexOrphographyCheck = urlSearch.YandexOrphographyCheck;
            HttpServerInformation = urlSearch.HttpServerInformation;
            GoogleSearch = urlSearch.GoogleSearch;
            GoogleImagesSearch = urlSearch.GoogleImagesSearch;
            LinkPadStatistics = urlSearch.LinkPadStatistics;
            DmozCatalog = urlSearch.DmozCatalog;
            GoogleSafeBrowserCheck = urlSearch.GoogleSafeBrowserCheck;
            LiveInternetCatalog = urlSearch.LiveInternetCatalog;
            MainWord = urlSearch.MainWord;

            WhoIsApiXml whoIsApi = new WhoIsApiXml(url);
            CreatedDate = whoIsApi.CreatedDate;
            ExpiresDate = whoIsApi.ExpiresDate;
            Organization = whoIsApi.Organization;
            Host = whoIsApi.Host;
            Status = whoIsApi.Status;

            YandexIndex yandexIndex = new YandexIndex(url);
            TcyIndex = yandexIndex.TcyIndex;
            TcyRang = yandexIndex.TcyRang;
            TextInfo = yandexIndex.TextInfo;
        }
    }
}