﻿using System;
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
            string act = tbCmdPath.Text;
            string arg = "/action:Script "
                        + "/outputPath:" + OutputPath + " "
                        + "/p:GenerateSmartDefaults=True "
                        + "/SourceFile:" + TbDacPacPath.Text + " "
                        + "/TargetDatabaseName:" + TargetDatabaseName.Text + " "
                        + "/TargetServerName:" + TargetServerName.Text;

            Process.Start(act, arg);
        }
    }
}
