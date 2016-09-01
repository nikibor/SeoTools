using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using OpenHtmlToPdf;
using System.Text;
using System.IO;

namespace SeoToolsMainApp.Core
{
    public static class PdfWriter
    {
        public static byte[] RenderDocument(string url)
        {
            string html = HttpProtocol.TakeData($"http://localhost:2274/Home/Cast?url={url}", "GET", Encoding.UTF8);
            return Pdf.From(html).EncodedWith("UTF8").Content();
        }
    }
}