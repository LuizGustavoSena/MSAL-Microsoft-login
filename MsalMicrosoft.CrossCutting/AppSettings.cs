using MsalMicrosoft.CrossCutting.AppModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MsalMicrosoft.CrossCutting
{
    public class AppSettings
    {
        public const string ActionName = "MyConfig";

        public Azure Azure { get; set; }
    }
}
