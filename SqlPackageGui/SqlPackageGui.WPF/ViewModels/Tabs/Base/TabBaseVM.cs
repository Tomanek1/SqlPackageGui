using SqlPackageGui.ApplicationLogic.Models;
using System.Xml.Serialization;

namespace SqlPackageGui.WPF.ViewModels.Tabs.Base
{
    public class TabBaseVM
    {
        /// <summary>
        /// /v:xxx
        /// </summary>
        [XmlIgnore]
        public VariableItem Variables { get; set; }

        /// <summary>
        /// /p:xxx
        /// </summary>
        [XmlIgnore]
        public VariableItem Parameters { get; set; }


        [XmlIgnore]
        public Connection Connection { get; set; }

        //public string Console { get; set; }
        //public string Target { get; set; }

    }

}
