using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SqlPackageGui.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string act = @"C:\Users\Administrator\Desktop\150\sqlpackage.exe";
            string arg = @" /action:Script /outputPath:C:\\test.txt /p:GenerateSmartDefaults=True /SourceFile:"+ TbDacPacPath.Text + @" /TargetDatabaseName:Eshop /TargetServerName:"".\SQLProduction""";
            //Process p = new Process();

            Process.Start(act, arg);
        }
    }
}
