using SqlPackageGui.ApplicationLogic.Models;
using SqlPackageGui.WPF.ViewModels.Tabs;
using SqlPackageGui.WPF.ViewModels.Tabs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqlPackageGui.WPF.ViewModels.Windows
{
    public class WindowVM
    {
        public Connection Connection { get; set; }
        public MyVariableList Variables { get; set; }

        public TabScriptVM TabScriptVm { get; set; }
        public TabDeployReportVM TabDeployReport { get; set; }
        public TabPublishVM TabPublishVM { get; set; }
        public TabDriftVM TabDriftVM { get; set; }



        public WindowVM()
        {
            Connection = new Connection();
            Variables = new MyVariableList();
            TabScriptVm = new TabScriptVM(Connection, Variables);
            TabDeployReport = new TabDeployReportVM(Connection, Variables);
            TabPublishVM = new TabPublishVM(Connection, Variables);
            TabDriftVM = new TabDriftVM(Connection, Variables);
        }

        public void Bind()
        {
            TabScriptVm.Connection = Connection;
            TabDeployReport.Connection = Connection;
            TabPublishVM.Connection = Connection;
            TabDriftVM.Connection = Connection;

            TabScriptVm.Variables = Variables;
            TabDeployReport.Variables = Variables;
            TabPublishVM.Variables = Variables;
            TabDriftVM.Variables = Variables;
        }
    }
}
