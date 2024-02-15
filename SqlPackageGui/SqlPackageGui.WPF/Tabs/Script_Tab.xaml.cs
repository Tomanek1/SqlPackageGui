using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.Logging;
using SqlPackageGui.ApplicationLogic;
using SqlPackageGui.ApplicationLogic.Models;

namespace SqlPackageGui.WPF.Tabs
{
    /// <summary>
    /// Interaction logic for Script_Tab.xaml
    /// </summary>
    public partial class Script_Tab : UserControl
    {
        private SqlPackage sqlPackage;

        public Script_Tab()
        {
            InitializeComponent();
            sqlPackage = new SqlPackage(LoggerFactory.Create(builder => builder.AddEventLog()).CreateLogger("Log"));
        }

        private void Btn_Script_Click(object sender, RoutedEventArgs e)
        {
            sqlPackage.ConsoleLocation = common.tbCmdPath.Text;
            //proc = new Process();
            Connection conn = new Connection();
            VariableItem var1 = new VariableItem(common.v1.Text, common.v2.Text);
            VariableItem var2 = new VariableItem(common.p1.Text, common.p2.Text);
            if (common.CbConnectionString.IsChecked.HasValue && common.CbConnectionString.IsChecked.Value)
                conn.ConnectionString = common.TbConnectionString.Text;
            conn.TargetDatabaseName = common.TargetDatabaseName.Text;
            conn.TargetServerName = common.TargetServerName.Text;

            var model = new CommonParameters()
            {
                Action = "Script",
                BlockOnPossibleDataLoss = common.BlockOnPossibleDataLoss.IsChecked.Value,
                DacpacPath = common.TbDacPacPath.Text,
                IgnoreColumnOrder = common.IgnoreColumnOrder.IsChecked.Value,
            };


            var dic = new Dictionary<string, VariableItem>()
            {
                { "V", var1 },
                { "P", var2 },
            };
            sqlPackage.Execute(model, OutputPath.Text, conn, Proc_ErrorDataReceived, dic);
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
