using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeoToolsMainApp.Interfaces
{
    interface IWhoIsApiXml
    {
        string CreatedDate { set; get; }
        string ExpiresDate { set; get; }
        string Organization { set; get; }
        string Host { set; get; }
        string Status { set; get; }
    }
}
