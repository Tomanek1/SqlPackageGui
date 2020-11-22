﻿using System;
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
    /// Interaction logic for Script_Tab.xaml
    /// </summary>
    public partial class Script_Tab : UserControl
    {
        Process proc = new Process();

        public Script_Tab()
        {
            InitializeComponent();
        }

        private void Btn_Script_Click(object sender, RoutedEventArgs e)
        {
            proc = new Process();
            string act = tbCmdPath.Text;
            string arg = "/action:Script "
                        + "/OutputPath:" + OutputPath.Text + " "
                        + "/p:GenerateSmartDefaults=True "
                        + "/SourceFile:" + TbDacPacPath.Text + " "
                        + "/TargetDatabaseName:" + TargetDatabaseName.Text + " "
                        + "/TargetServerName:" + TargetServerName.Text;

            this.proc.StartInfo = new ProcessStartInfo
            {
                FileName = act,
                Arguments = arg,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            proc.OutputDataReceived += new DataReceivedEventHandler(this.Proc_ErrorDataReceived);
            proc.ErrorDataReceived += new DataReceivedEventHandler(this.Proc_ErrorDataReceived);

            proc.Start();
            proc.BeginOutputReadLine();
            proc.BeginErrorReadLine();
            proc.WaitForExit();
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