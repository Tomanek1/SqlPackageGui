using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using SqlPackageGui.ApplicationLogic;

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
            if (CbConnectionString.IsChecked.HasValue && CbConnectionString.IsChecked.Value)
                conn.ConnectionString = TbConnectionString.Text;
            conn.TargetDatabaseName = TargetDatabaseName.Text;
            conn.TargetServerName = TargetServerName.Text;

            sqlPackage.Execute("Script", OutputPath.Text, TbDacPacPath.Text, conn, Proc_ErrorDataReceived);
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
