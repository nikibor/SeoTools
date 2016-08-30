using SeoToolsMainApp.Core;
using SeoToolsMainApp.Interfaces;
using SeoToolsMainApp.Models;

namespace SeoToolsMainApp.Api
{
    /// <summary>
    /// Получение ссылок на скриншоты сайтов
    /// </summary>
    public class ScreenShoot : AbstractApi, IScreenShoot
    {

        /// <summary>
        /// Адрес картинки настольной версии
        /// </summary>
        public string DesktopUrl { set; get; }

        /// <summary>
        /// Адрес картинки мобильной версии
        /// </summary>
        public string MobileUrl { set; get; }

        /// <summary>
        /// Получение ссылок на получение изиображений через api
        /// </summary>
        /// <param name="url"></param>
        public ScreenShoot(string url)
        {            
            DesktopUrl = $"http://mini.s-shot.ru/1024/1000/jpeg/?{url}";
            MobileUrl = $"http://mini.s-shot.ru/720/800/jpeg/?{url}";
        }
    }
}