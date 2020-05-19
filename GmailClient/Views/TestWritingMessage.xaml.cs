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
using GmailClientLibrary;

namespace GmailClient.Views
{
    public partial class TestWritingMessage : UserControl
    {
        private TestPage WorkSpace ;
        private MainClient Session;
        private string FieldContent;
        public TestWritingMessage(TestPage workSpace, MainClient session)
        {
            InitializeComponent();
            WorkSpace = workSpace;
            Session = session;
        }

        private void SendMesssageButton_Click(object sender, RoutedEventArgs e)
        {
            Session.SendMessage(ToField.Text, SubjectField.Text, MessageField.Text);
        }

        private void BackToMainButton_Click(object sender, RoutedEventArgs e)
        {
            WorkSpace.ContentChangerToMain();            
        }

        private void ClearBoxOnMouseDown(object sender, RoutedEventArgs e)
        {
            var element = (TextBox)sender;
            if (element.Text == "To" | element.Text == "Subject" | element.Text == "Write the message")
            {
                FieldContent = element.Text;
                element.Text = "";
            }

        }

        private void FillBoxIfNoContent(object sender, RoutedEventArgs e)
        {
            var element = (TextBox)sender;
            if (element.Text == "")
                element.Text = FieldContent;

        }
    }
}
