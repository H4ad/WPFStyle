using System.Windows;

namespace WPFStyle
{
    /// <summary>
    /// Interaction logic for MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window
    {
        public MessageWindow(Window owner, string title, string content)
        {
            InitializeComponent();

            this.Owner = owner;
            Title.Text = title;
            Content.Text = content;
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
