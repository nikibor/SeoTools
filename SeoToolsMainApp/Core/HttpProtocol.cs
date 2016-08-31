using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using System.Configuration;

namespace SeoToolsMainApp.Core
{
    public class HttpProtocol
    {
        public string Url { set; get; }
        /// <summary>
        /// Отправка запроса на сервер через url
        /// </summary>
        /// <param name="url">Ссылка на сервер</param>
        /// <param name="method">Тип запроса(GET, PUSH, PUT, DELETE)</param>
        /// <returns>Ответ с сервера</returns>
        public static string TakeData(string url, string method, Encoding code)
        {
            try
            {
                string responseXml;
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = method;
                var response = (HttpWebResponse)request.GetResponse();
                using (StreamReader stream = new StreamReader(response.GetResponseStream(), code))
                {
                    responseXml = stream.ReadToEnd();
                }
                return responseXml;
            }
            catch (Exception)
            {
                return null;
            }
            
        }
        /// <summary>
        /// Получение данных через прямой запрос на сервер
        /// </summary>
        /// <param name="url">Адрес сервера</param>
        /// <param name="method">Тип запроса(GET, PUSH, PUT, DELETE)</param>
        /// <param name="contentType">Тип отправляемого сообщения</param>
        /// <param name="data">Передаваемое сообщение</param>
        /// <returns>Текстовое сообщение полученное от сервера</returns>
        public static string TakeData(string url, string method, string contentType,string data )
        {
            var request =WebRequest.Create(url);
            request.Method = method;
            request.ContentType = contentType;
            byte[] sentData = Encoding.GetEncoding(1251).GetBytes(data);
            request.ContentLength = sentData.Length;
            Stream sentStream = request.GetRequestStream();
            sentStream.Write(sentData, 0, sentData.Length);
            sentStream.Close();
            WebResponse response = request.GetResponse();
            Stream receiveStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(receiveStream, Encoding.UTF8);
            Char[] read = new Char[256];
            int count = sr.Read(read, 0, 256);
            string Out = String.Empty;
            while (count > 0)
            {
                String str = new String(read, 0, count);
                Out += str;
                count = sr.Read(read, 0, 256);
            }
            return Out;
        }

        /// <summary>
        /// Получение информации из html по маске
        /// </summary>
        /// <param name="url">Адрес сайта</param>
        /// <param name="mask">Параметры поиска</param>
        /// <returns>Запрашиваемое значение</returns>
        public static string GetDataFromHtml(string url, string mask)
        {
            var doc = new HtmlDocument();
            string request = TakeData(url, "GET", Encoding.UTF8);
            if (request != null)
            {
                doc.LoadHtml(request);
                var node = doc.DocumentNode.SelectSingleNode(mask);
                return node.InnerText;
            }
            return null;
        }

        /// <summary>
        /// Обрезка адреса до его домена
        /// </summary>
        /// <param name="url">Ссылка</param>
        /// <returns>Домен</returns>
        public static string CreateDomen(string url)
        {
            url = url.Remove(0, url.IndexOf('/') + 2);
            if (url.StartsWith("www."))
                url = url.Remove(0, 4);
            return url;
        }

        /// <summary>
        /// Проверка строки url на её валидность
        /// </summary>
        /// <returns>true, если строка типа url или false, если нет</returns>
        public static bool IsUrl(string urlAdress)
        {
            string pattern = @"(http|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?";
            return new Regex(pattern).IsMatch(urlAdress);
        }

        /// <summary>
        /// Проверка на наличение заголовка с протоколом
        /// </summary>
        /// <param name="url">Ссылка</param>
        /// <returns>Дополненную или первоначальную ссылку</returns>
        public static string HttpPrefixCheck(string url)
        {
            if(!(url.StartsWith("http://") || url.StartsWith("https://")))
                url = $"http://{url}";
            return url;
        }
        public static bool ExistUrl(string url)
        {
            var response = TakeData(url, "GET", Encoding.UTF8);
            return (response != null) ? true : false;
        }
    }
}