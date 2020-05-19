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

namespace GmailClient.Views
{
    public partial class TestLoginWindow : UserControl
    {
        private TestPage CurrentPage;
        public TestLoginWindow(TestPage currentPage)
        {
            InitializeComponent();
            CurrentPage = currentPage;
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CurrentPage.GetNewSession();
        }
    }
}
