﻿using SqlPackageGui.ApplicationLogic;
using SqlPackageGui.ApplicationLogic.Models;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace SqlPackageGui.WPF.Tabs
{
    /// <summary>
    /// Interaction logic for DeployReport_Tab.xaml
    /// </summary>
    public partial class DeployReport_Tab : UserControl
    {
        SqlPackage sqlPackage = new SqlPackage();

        public DeployReport_Tab()
        {
            InitializeComponent();
        }


        private void Btn_DeployReport_Click(object sender, RoutedEventArgs e)
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
                Action = "DeployReport",
                DacpacPath = common.TbDacPacPath.Text,
                BlockOnPossibleDataLoss = common.BlockOnPossibleDataLoss.IsChecked.Value
            };
            sqlPackage.Execute(model, OutputPath.Text, conn, Proc_DataReceived, var);
            BtnOpenFile.IsEnabled = true;
        }

        private void BtnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            //Process.Start()
        }

        private void Proc_DataReceived(object sender, DataReceivedEventArgs e)
        {
            tbOutput.Dispatcher.BeginInvoke(new Action(() =>
            {
                var value = (e.Data ?? "") + Environment.NewLine;
                tbOutput.AppendText(value);
            }));
        }

    }
}
