using SqlPackageGui.ApplicationLogic;
using SqlPackageGui.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SqlPackageGui.WPF.ViewModels.Tabs.Base
{
    public class TabBaseVM
    {

        [XmlIgnore]
        public MyVariableList Variables { get; set; }


        [XmlIgnore]
        public Connection Connection { get; set; }

        //public string Console { get; set; }
        //public string Target { get; set; }

    }

}
