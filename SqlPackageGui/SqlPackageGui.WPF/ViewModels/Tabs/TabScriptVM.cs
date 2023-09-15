using System;
using SqlPackageGui.ApplicationLogic.Models;
using SqlPackageGui.WPF.ViewModels.Tabs.Base;

namespace SqlPackageGui.WPF.ViewModels.Tabs
{
    public class TabScriptVM : TabBaseVM
    {
        public string OutputPath { get; set; }

        //public ICommand Execute { get; set; }

        public TabScriptVM()
        {
            //Execute = new BasicCommand(this.Executee);
        }

        public TabScriptVM(Connection connection, VariableItem valuePairs)
        {
            this.Connection = connection;
            Variables = valuePairs;
            //Execute = new BasicCommand(this.Executee);

        }

        private void Executee()
        {
            throw new NotImplementedException();
        }
    }
}
