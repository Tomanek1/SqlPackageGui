using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using System.Xml.Serialization;
using SqlPackageGui.WPF.ViewModels.Tabs.Base;

namespace SqlPackageGui.WPF.ViewModels.Tabs
{
    public class TabScriptVM : TabBaseVM
    {
        public string OutputPath { get; set; }

        //[NonSerialized]
        [XmlIgnore]
        public Connection Connection { get; set; }

        //public ICommand Execute { get; set; }

        public TabScriptVM()
        {
            //Execute = new BasicCommand(this.Executee);
        }

        public TabScriptVM(Connection connection)
        {
            this.Connection = connection;
            //Execute = new BasicCommand(this.Executee);

        }

        private void Executee()
        {
            throw new NotImplementedException();
        }
    }
}
