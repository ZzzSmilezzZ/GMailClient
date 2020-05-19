using System.Windows.Controls;
using System.Windows.Input;
using GmailClientLibrary;

namespace GmailClient.Layouts
{
    public partial class MessageLayout : UserControl
    {
        public GmailMessageDTO message { get; private set; }

        public MessageLayout(GmailMessageDTO message)
        {
            InitializeComponent();
            this.message = message;
            MessageSender.Text = message.From;
            MessageSnippet.Text = message.Snippet;
            MessageDate.Text = message.Date;
        }

        private void ColumnDefinition_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Message_MouseEnter(object sender, MouseEventArgs e)
        {
            var element = sender as MessageLayout;
            OnMessageDeleteButton.Opacity = 100;
            OnMessageDeleteButton.IsEnabled = true;
        }

        private void Message_MouseLeave(object sender, MouseEventArgs e)
        {
            var element = sender as MessageLayout;
            OnMessageDeleteButton.IsEnabled = false;
            OnMessageDeleteButton.Opacity = 0;
        }

        private void OnMessageDeleteButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            var element = this;
        }
    }
}
