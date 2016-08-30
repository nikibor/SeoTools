using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeoToolsMainApp.Interfaces
{
    interface IGooglePageSpeed
    {
        string TitleOfSite { set; get; }
        string SpeedScore { set; get; }
        string NumberOfHosts { set; get; }
        string NumberStaticOfResources { set; get; }
        string NumberJsResources { set; get; }
        string NumberCssResources { set; get; }
        string HtmlSize { set; get; }
        string CssSize { set; get; }
        string ImageSize { set; get; }
        string JavaScriptSize { set; get; }
    }
}
