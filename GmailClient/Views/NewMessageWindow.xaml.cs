using System.Windows;
using GmailClientLibrary;

namespace GmailClient.Views
{
    public partial class NewMessageWindow : Window
    {
        private MainClient Session;
        public NewMessageWindow(MainClient session)
        {
            InitializeComponent();
            Session = session;
        }

        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Session.SendMessage(To.Text,Subj.Text,MessageField.Text);
            Close();
        }
    }
}
