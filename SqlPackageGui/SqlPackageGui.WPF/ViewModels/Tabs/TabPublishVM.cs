using SqlPackageGui.WPF.ViewModels.Tabs.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SqlPackageGui.WPF.ViewModels.Tabs
{
    public class TabPublishVM
    {
        public string OutputPath { get; set; }

        //[NonSerialized]
        [XmlIgnore]
        public Connection Connection { get; set; }

        //public ICommand Execute { get; set; }

        public TabPublishVM()
        {
            //Execute = new BasicCommand(this.Executee);
        }

        public TabPublishVM(Connection connection)
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
