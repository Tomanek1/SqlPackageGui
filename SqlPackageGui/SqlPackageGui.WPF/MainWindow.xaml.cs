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
        WindowVM window;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            XmlSerializer ser = new XmlSerializer(typeof(WindowVM));
            using (Stream stream = new FileStream("C:\\data.xml", FileMode.OpenOrCreate))
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
            using (Stream stream = new FileStream("C:\\data.xml", FileMode.OpenOrCreate))
            {
                ser.Serialize(stream, window);
            }
        }

    }
}
