using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

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
            string act = common.tbCmdPath.Text;
            string arg = "/action:Script "
                        + "/OutputPath:" + OutputPath.Text + " "
                        + "/p:GenerateSmartDefaults=True "
                        + "/SourceFile:" + TbDacPacPath.Text + " ";

            if (CbConnectionString.IsChecked.HasValue && CbConnectionString.IsChecked.Value)
                arg += "/TargetConnectionString:" + TbConnectionString.Text + " ";
            else
                arg += "/TargetDatabaseName:" + TargetDatabaseName.Text + " "
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

        private void CbConnectionString_Checked(object sender, RoutedEventArgs e)
        {
            if (CbConnectionString.IsChecked.HasValue && CbConnectionString.IsChecked.Value)
            {
                TargetDatabaseName.Visibility = Visibility.Collapsed;
                LbTargetDatabaseName.Visibility = Visibility.Collapsed;
                TargetServerName.Visibility = Visibility.Collapsed;
                LbTargetServerName.Visibility = Visibility.Collapsed;

                TbConnectionString.Visibility = Visibility.Visible;
                LbConnectionString.Visibility = Visibility.Visible;
            }
            else
            {

                TargetDatabaseName.Visibility = Visibility.Visible;
                LbTargetDatabaseName.Visibility = Visibility.Visible;
                TargetServerName.Visibility = Visibility.Visible;
                LbTargetServerName.Visibility = Visibility.Visible;

                TbConnectionString.Visibility = Visibility.Collapsed;
                LbConnectionString.Visibility = Visibility.Collapsed;
            }
        }
    }
}
