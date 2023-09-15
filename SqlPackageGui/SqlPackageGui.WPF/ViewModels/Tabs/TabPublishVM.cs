using SqlPackageGui.ApplicationLogic.Models;
using SqlPackageGui.WPF.ViewModels.Tabs.Base;
using System;

namespace SqlPackageGui.WPF.ViewModels.Tabs
{
    public class TabPublishVM : TabBaseVM
    {
        public string OutputPath { get; set; }


        //public ICommand Execute { get; set; }

        public TabPublishVM()
        {
            //Execute = new BasicCommand(this.Executee);
        }

        public TabPublishVM(Connection connection, VariableItem valuePairs)
        {
            this.Connection = connection;
            //Execute = new BasicCommand(this.Executee);
            this.Variables = valuePairs;

        }

        private void Executee()
        {
            throw new NotImplementedException();
        }
    }
}
