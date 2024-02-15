using SqlPackageGui.WPF.ViewModels.Windows;
using System;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace SqlPackageGui.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WindowVM window;
        private string serializationFile = @"C:\\sqlconsolegui\data.xml";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            XmlSerializer ser = new XmlSerializer(typeof(WindowVM));
            if (!Directory.Exists(@"C:\\SqlConsoleGui\\"))
                Directory.CreateDirectory(@"C:\\SqlConsoleGui\\");
            using (Stream stream = new FileStream(serializationFile, FileMode.OpenOrCreate))
            {
                if (stream.Length == 0)
                    window = new WindowVM();
                else
                    window = (WindowVM)ser.Deserialize(stream);

                window.Bind();
                this.DataContext = window;
            }
        }


        private void Window_Closed(object sender, EventArgs e)
        {
            XmlSerializer ser = new XmlSerializer(typeof(WindowVM));
            using (Stream stream = new FileStream(serializationFile, FileMode.OpenOrCreate))
            {
                ser.Serialize(stream, window);
            }
        }

    }
}
