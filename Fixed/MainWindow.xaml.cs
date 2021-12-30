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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;

namespace Fixed
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void OpenDocXps(string docStr)
        {
            XpsDocument doc = new XpsDocument(docStr, FileAccess.Read);
            documentV.Document = doc.GetFixedDocumentSequence();
            doc.Close();
        }
        public MainWindow()
        {
            InitializeComponent();
            OpenDocXps("../../Data/Пример.xps");
        }
        private void Button_Click_Open(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файлы разметки XML Paper (*.xps)|*.xps|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                OpenDocXps(openFileDialog.FileName);
            }
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Файлы разметки XML Paper (*.xps)|*.xps|Все файлы (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == true)
            {
                XpsDocument doc = new XpsDocument(saveFileDialog.FileName, FileAccess.Write);
                XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(doc);
                writer.Write(documentV.Document as FixedDocument);

                doc.Close();
            }
        }
    }
}
