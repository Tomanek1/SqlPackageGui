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
    /// Interaction logic for DeployReport_Tab.xaml
    /// </summary>
    public partial class DeployReport_Tab : UserControl
    {
        private Process proc;

        public DeployReport_Tab()
        {
            InitializeComponent();
        }


        private void Btn_DeployReport_Click(object sender, RoutedEventArgs e)
        {
            proc = new Process();
            string act = common.tbCmdPath.Text;
            string arg = "/action:DeployReport "
                        + "/OutputPath:" + OutputPath.Text + " "
                        + "/SourceFile:" + common.TbDacPacPath.Text + " "
                        + "/TargetDatabaseName:" + common.TargetDatabaseName.Text + " "
                        + "/TargetServerName:" + common.TargetServerName.Text;

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
