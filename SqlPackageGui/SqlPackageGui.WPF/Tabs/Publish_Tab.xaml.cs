using SqlPackageGui.ApplicationLogic;
using SqlPackageGui.ApplicationLogic.Models;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

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
            Connection conn = new Connection();
            MyVariableList var = new MyVariableList(common.v1.Text, common.v2.Text);
            if (common.CbConnectionString.IsChecked.HasValue && common.CbConnectionString.IsChecked.Value)
                conn.ConnectionString = common.TbConnectionString.Text;
            conn.TargetDatabaseName = common.TargetDatabaseName.Text;
            conn.TargetServerName = common.TargetServerName.Text;

            var model = new CommonParameters()
            {
                Action = "Publish",
                DacpacPath = common.TbDacPacPath.Text,
                BlockOnPossibleDataLoss = common.BlockOnPossibleDataLoss.IsChecked.Value
            };

            sqlPackage.Execute(model, null, conn, Proc_ErrorDataReceived, var);

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
