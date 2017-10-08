using System.Windows;
using System.Windows.Input;

namespace WPFStyle
{
    public class MenuViewModel
    {
        #region Construtor

        /// <summary>
        /// Construtor padrão
        /// </summary>
        public MenuViewModel()
        {
            MinimizeCommand = new RelayCommand(Minimize);
            RestoreCommand = new RelayCommand(Restore);
            ExitCommand = new RelayCommand(Exit);
        }

        #endregion

        #region Commands

        /// <summary>
        /// Minimiza a Window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// Restaura a Window a seu tamanho normal
        /// </summary>
        public ICommand RestoreCommand { get; set; }

        /// <summary>
        /// Fecha a Window
        /// </summary>
        public ICommand ExitCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Lógica do MinimizeCommand
        /// </summary>
        public void Minimize()
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Lógica do RestoreCommand
        /// </summary>
        public void Restore()
        {
            if (Application.Current.MainWindow.WindowState == WindowState.Maximized)
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
        }

        /// <summary>
        /// Lógica do ExitCommand
        /// </summary>
        public void Exit()
        {
            Application.Current.MainWindow.Close();
        }

        #endregion

    }
}
