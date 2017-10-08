using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace WPFStyle
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        #region Construtor

        /// <summary>
        /// Construtor padrão
        /// </summary>
        public Menu()
        {
            InitializeComponent();
            DataContext = new MenuViewModel();
        }

        #endregion

        #region Dependency Properties

        /// <summary>
        /// Informa se a janela hospedeira está maximizada
        /// </summary>
        public bool IsWindowMaximized
        {
            get { return (bool)GetValue(IsWindowMaximizedProperty); }
            set { SetValue(IsWindowMaximizedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsWindowMaximized.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsWindowMaximizedProperty =
            DependencyProperty.Register("IsWindowMaximized", typeof(bool), typeof(Menu), new PropertyMetadata(false, IsWindowMaximizedChangedCallback));


        #endregion

        #region Dependency Callbacks

        private static void IsWindowMaximizedChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                (d as Menu).MinAndMaximizedButton.SetValue(IsMaximized.ValueProperty, e.NewValue);
            }
            catch (Exception)
            {
                Debugger.Break();
            }
        }

        #endregion
    }
}
