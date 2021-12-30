using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;

namespace Sreaming
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Clear(object sender, RoutedEventArgs e)
        {
            docViewer.ClearValue(FlowDocumentScrollViewer.DocumentProperty);
        }

        private void Button_Click_Open(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файлы разметки WPF (*.xaml)|*.xaml|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                using(FileStream fs =File.Open(openFileDialog.FileName,FileMode.Open))
                {
                    docViewer.Document = XamlReader.Load(fs) as FlowDocument;
                }
            }
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Файлы разметки WPF (*.xaml)|*.xaml|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                using (FileStream fs = File.Open(saveFileDialog.FileName, FileMode.Create))
                {
                     XamlWriter.Save(docViewer.Document, fs);
                }
            }
        }
    }
}
