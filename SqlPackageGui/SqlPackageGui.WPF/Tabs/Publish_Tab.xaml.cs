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
        Process proc = new Process();

        public Publish_Tab()
        {
            InitializeComponent();
        }

        private void Btn_Publish_Click(object sender, RoutedEventArgs e)
        {
            proc = new Process();
            string act = tbCmdPath.Text;
            string arg = "/action:Publish "
                        + "/SourceFile:" + TbSourceFile.Text + " "
                        //+ "/p:GenerateSmartDefaults=True "
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

            proc.OutputDataReceived += new DataReceivedEventHandler(this.Proc_OutputDataReceived);
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

        private void Proc_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            tbOutput.Dispatcher.BeginInvoke(new Action(() =>
            {
                var value = (e.Data ?? "") + Environment.NewLine;
                tbOutput.AppendText(value);
            }));
        }
    }
}
