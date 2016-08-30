using System.Xml;
using SeoToolsMainApp.Core;
using System.Text;
using SeoToolsMainApp.Interfaces;
using SeoToolsMainApp.Models;

namespace SeoToolsMainApp.Api
{
    public class YandexIndex : AbstractApi, IYandexIndex
    {
        /// <summary>
        /// Уровень цитируемости(rang)
        /// </summary>
        public string TcyRang { set; get; }
        /// <summary>
        /// Количество страниц(value)
        /// </summary>
        public string TcyIndex { set; get; }
        /// <summary>
        /// Название категории сайта и её описание
        /// </summary>
        public string TextInfo { set; get; }
        /// <summary>
        /// Получение индекса цитирования, количества страниц и католога сайта
        /// </summary>
        /// <param name="url">Ссылка на ресурс</param>
        public YandexIndex(string url)
        {
            Url = $"http://bar-navig.yandex.ru/u?ver=2&url={url}&show=1";
            string responseXML = HttpProtocol.TakeData(Url, "GET", Encoding.GetEncoding(1251));
            Parse(responseXML);
        }
        public void Parse(string responseXml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(responseXml);
            if (doc.DocumentElement != null)
                foreach (XmlNode noda in doc.DocumentElement)
                {
                    if (noda.LocalName == "tcy")
                    {
                        if (noda.Attributes != null)
                        {
                            TcyRang = noda.Attributes["rang"]?.Value;
                            TcyIndex = noda.Attributes["value"]?.Value;
                        }
                    }
                    if (noda.LocalName == "textinfo")
                    {
                        TextInfo = noda.FirstChild?.Value;
                    }
                }
        }
    }
}