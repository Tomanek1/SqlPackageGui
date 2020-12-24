using SqlPackageGui.WPF.ViewModels.Tabs;
using SqlPackageGui.WPF.ViewModels.Tabs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlPackageGui.WPF.ViewModels.Windows
{
    public class WindowVM
    {
        public TabScriptVM TabScriptVm { get; set; }
        public Connection Connection { get; set; }


        public WindowVM()
        {
            Connection = new Connection();
            TabScriptVm = new TabScriptVM(Connection);
        }

        public void Bind()
        {
            TabScriptVm.Connection = Connection;
        }
    }
}
