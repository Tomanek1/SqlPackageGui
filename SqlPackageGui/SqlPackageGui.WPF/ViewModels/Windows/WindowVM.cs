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

        public TabScriptVM TabScriptVm { get; set; }
        public TabDeployReportVM TabDeployReport { get; set; }
        public TabPublishVM TabPublishVM { get; set; }
        public TabDriftVM TabDriftVM { get; set; }



        public WindowVM()
        {
            Connection = new Connection();
            TabScriptVm = new TabScriptVM(Connection);
            TabDeployReport = new TabDeployReportVM(Connection);
            TabPublishVM = new TabPublishVM(Connection);
            TabDriftVM = new TabDriftVM(Connection);
        }

        public void Bind()
        {
            TabScriptVm.Connection = Connection;
            TabDeployReport.Connection = Connection;
            TabPublishVM.Connection = Connection;
            TabDriftVM.Connection = Connection;
        }
    }
}
