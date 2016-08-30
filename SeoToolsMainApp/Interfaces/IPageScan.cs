using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeoToolsMainApp.Interfaces
{
    interface IPageScan
    {
        string HaveNoindex { get; set; }
        string HaveComments { get; set; }
        string HaveDescription { get; set; }
        string HaveKeyWords { get; set; }
        int CssCount { get; set; }
        string HaveAltImgText { get; set; }
        string HaveTitleImg { get; set; }
        string HaveRobots { get; set; }
        string HaveHeader { get; set; }
        string HaveFooter { get; set; }
    }
}
