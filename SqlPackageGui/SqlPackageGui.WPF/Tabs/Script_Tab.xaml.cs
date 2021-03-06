﻿using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using SqlPackageGui.ApplicationLogic;
using SqlPackageGui.ApplicationLogic.Models;

namespace SqlPackageGui.WPF.Tabs
{
    /// <summary>
    /// Interaction logic for Script_Tab.xaml
    /// </summary>
    public partial class Script_Tab : UserControl
    {
        //Process proc = new Process();
        SqlPackage sqlPackage = new SqlPackage();
        public Script_Tab()
        {
            InitializeComponent();
        }

        private void Btn_Script_Click(object sender, RoutedEventArgs e)
        {
            sqlPackage.ConsoleLocation = common.tbCmdPath.Text;
            //proc = new Process();
            Connection conn = new Connection();
            MyVariableList var = new MyVariableList(common.v1.Text, common.v2.Text);
            if (common.CbConnectionString.IsChecked.HasValue && common.CbConnectionString.IsChecked.Value)
                conn.ConnectionString = common.TbConnectionString.Text;
            conn.TargetDatabaseName = common.TargetDatabaseName.Text;
            conn.TargetServerName = common.TargetServerName.Text;

            var model = new CommonParameters() { Action = "Script", DacpacPath = common.TbDacPacPath.Text, };
            sqlPackage.Execute(model, OutputPath.Text, conn, Proc_ErrorDataReceived, var);
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
