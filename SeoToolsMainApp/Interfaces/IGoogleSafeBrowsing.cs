﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeoToolsMainApp.Interfaces
{
    interface IGoogleSafeBrowsing
    {
        string HaveViruses { set; get; }
        string ColorMessage { set; get; }
    }
}
