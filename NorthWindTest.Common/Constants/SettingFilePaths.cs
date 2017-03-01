using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindTest.Common.Constants
{
    public class SettingFilePaths
    {
        public static string DBJsonConfigPath
        {
            get
            {
                string path = ConfigurationManager.AppSettings["JsonConfigPath"];
                return path;
            }
        }

    }
}
