using SqlPackageGui.ApplicationLogic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SqlPackageGui.WPF.Tabs
{
    /// <summary>
    /// Interaction logic for Publish_Tab.xaml
    /// </summary>
    public partial class Publish_Tab : UserControl
    {
        SqlPackage sqlPackage = new SqlPackage();

        public Publish_Tab()
        {
            InitializeComponent();
        }

        private void Btn_Publish_Click(object sender, RoutedEventArgs e)
        {
            sqlPackage.ConsoleLocation = common.tbCmdPath.Text;
            //proc = new Process();
            Connection conn = new Connection();
            if (common.CbConnectionString.IsChecked.HasValue && common.CbConnectionString.IsChecked.Value)
                conn.ConnectionString = common.TbConnectionString.Text;
            conn.TargetDatabaseName = common.TargetDatabaseName.Text;
            conn.TargetServerName = common.TargetServerName.Text;

            sqlPackage.Execute("Script", null, common.TbDacPacPath.Text, conn, Proc_ErrorDataReceived);

        }

        private void Proc_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            tbOutput.Dispatcher.BeginInvoke(new Action(() =>
            {
                var value = (e.Data ?? "") + Environment.NewLine;
                tbOutput.AppendText(value);
            }));
        }
    }
}
