using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeoToolsMainApp.Interfaces
{
    interface IYandexIndex
    {
        string TcyRang { set; get; }
        string TcyIndex { set; get; }
        string TextInfo { set; get; }
    }
}
