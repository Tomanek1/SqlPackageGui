using System;
using System.Collections.Generic;
using System.Text;

namespace SqlPackageGui.ApplicationLogic.Models
{
    /// <summary>
    /// Třída s parametry pro základní nastavení SqlConsole
    /// </summary>
    public class CommonParameters
    {
        public string Action { get; set; }
        public string DacpacPath { get; set; }
        public bool IgnoreColumnOrder { get; set; }
    }
}
