using System;
using System.Collections.Generic;
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

namespace SqlPackageGui.WPF.UserControls
{
    /// <summary>
    /// Interaction logic for Common.xaml
    /// </summary>
    public partial class Common : UserControl
    {
        public Common()
        {
            InitializeComponent();
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
