using System.Collections.Generic;
using SeoToolsMainApp.Core;
using System.Text;
using SeoToolsMainApp.Interfaces;
using SeoToolsMainApp.Models;

namespace SeoToolsMainApp.Api
{
    public class PageScan : AbstractApi, IPageScan
    {
        private string Response { get; set; }
        private string[] Lines { get; set; }
        public string HaveNoindex { get; set; } = "Отсутствует";
        public string HaveComments { get; set; } = "Отсутствует";
        public string HaveDescription { get; set; } = "Отсутствует";
        public string HaveKeyWords { get; set; } = "Отсутствует";
        public int CssCount { get; set; }
        public string HaveAltImgText { get; set; } = "Отсутствует";
        public string HaveTitleImg { get; set; } = "Отсутствует";
        public string HaveRobots { get; set; } = "Отсутствует";
        public string HaveHeader { get; set; } = "Отсутствует";
        public string HaveFooter { get; set; } = "Отсутствует";

        public PageScan(string url)
        {
            Response = HttpProtocol.TakeData(url, "GET", Encoding.UTF8);
            Lines = Response.Split('\n');
            foreach (var line in Lines)
            {
                LineCheck(line);
            }
        }

        private void LineCheck(string line)
        {
            if (line.StartsWith("<noindex"))
                HaveNoindex = "Присутствует";
            MetaScan(line);
            if (line.StartsWith("<--"))
                HaveComments = "Присутствует";
            if (line.Contains("rel='stylesheet'"))
                CssCount++;
            ImageScan(line);
            HeaderFooterScan(line);
        }

        private void HeaderFooterScan(string line)
        {
            if (line.StartsWith("<header"))
                HaveHeader = "Присутствует";
            if (line.StartsWith("<footer"))
                HaveFooter = "Присутствует";
        }

        private void MetaScan(string line)
        {
            if (line.StartsWith("<meta"))
            {
                if (line.Contains("name=\"keywords\""))
                    HaveKeyWords = "Присутствует";
                if (line.Contains("name=\"description\""))
                    HaveDescription = "Присутствует";
                if (line.Contains("name=\"robots\""))
                    HaveRobots = "Присутствует";
            }
        }

        private void ImageScan(string line)
        {
            if (line.StartsWith("<img"))
            {
                if (line.Contains("alt=\""))
                    HaveAltImgText = "Присутствует";
                if (line.Contains("title=\""))
                    HaveTitleImg = "Присутствует";
            }
        }
    }
}
