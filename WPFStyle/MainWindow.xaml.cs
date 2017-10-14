using System.Windows;
using System.Windows.Input;

namespace WPFStyle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor 

        /// <summary>
        /// Construtor padrão
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
        } 

        #endregion

        #region Events

        /// <summary>
        /// Evento usado para mover a Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            DragMove();
        }

        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new MessageWindow(this, "Só testando", "Será que deu certo ?").Show();
        }
    }
}
