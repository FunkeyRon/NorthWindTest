using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthWindTest.Models.JsonConfigModels
{
    public class ConnectionStrings
    {
        public string NorthwindConnection { get; set; } = string.Empty;
    }

    public class SqlConfigRoot
    {
        public List<CategoryItem> Categories { get; set; }
    }

    public class CategoryItem
    {
        public string name { get; set; }
        public List<Script> Scripts { get; set; }
    }

    public class Script
    {
        public string name { get; set; }
        public string cmd { get; set; }
    }

}
