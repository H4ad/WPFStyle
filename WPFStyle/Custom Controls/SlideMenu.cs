using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace WPFStyle
{
    /// <summary>
    /// É um controle personalizado que irá ser um menu que desliza para o lado
    /// </summary>
    public class SlideMenu : Control
    {

        #region DependencyProperty Content

        /// <summary>
        /// Registers a dependency property as backing store for the Content property
        /// </summary>
        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(object), typeof(SlideMenu),
            new FrameworkPropertyMetadata(null,
                  FrameworkPropertyMetadataOptions.AffectsRender |
                  FrameworkPropertyMetadataOptions.AffectsParentMeasure));

        /// <summary>
        /// Gets or sets the Content.
        /// </summary>
        /// <value>The Content.</value>
        public object Content
        {
            get { return (object)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        /// <summary>
        /// Registra a Dependency Property do MenuContent
        /// </summary>
        public static readonly DependencyProperty MenuContentProperty =
            DependencyProperty.Register("MenuContent", typeof(FrameworkElement), typeof(SlideMenu),
            new FrameworkPropertyMetadata(null,
                  FrameworkPropertyMetadataOptions.AffectsRender |
                  FrameworkPropertyMetadataOptions.AffectsParentMeasure));

        /// <summary>
        /// Será o conteudo do menu
        /// </summary>
        /// <value>O conteudo do menu.</value>
        public FrameworkElement MenuContent
        {
            get { return (FrameworkElement)GetValue(MenuContentProperty); }
            set { SetValue(MenuContentProperty, value); }
        }

        /// <summary>
        /// Indicará se o menu está aberto ou não
        /// </summary>
        public bool IsOpen
        {
            get { return (bool)GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsOpen.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsOpenProperty =
            DependencyProperty.Register("IsOpen", typeof(bool), typeof(SlideMenu), new PropertyMetadata(false, IsOpenChangedCallback));

        /// <summary>
        /// Direções que o menu pode aparecer
        /// </summary>
        public SlideDirections SlideDirection
        {
            get { return (SlideDirections)GetValue(SlideDirectionProperty); }
            set { SetValue(SlideDirectionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SlideDirection.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SlideDirectionProperty =
            DependencyProperty.Register("SlideDirection", typeof(SlideDirections), typeof(SlideMenu), new PropertyMetadata(SlideDirections.Left));

        #endregion

        #region Callbacks Methods


        private async static void IsOpenChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is SlideMenu control))
                return;

            var seconds = 1;
            // Create the storyboard
            var sb = new Storyboard();

            var border = (control.FindName("ShadowBorder") as Border) ?? new Border();

            if ((bool)e.NewValue == true)
            {
                control.MenuContent.Margin = new Thickness(control.MenuContent.ActualWidth * -1, 0, 0, 0);
                // Add slide from right animation
                sb.AddSlideFromLeft(seconds, control.MenuContent.ActualWidth);

                control.MenuContent.Visibility = Visibility.Visible;
                border.Visibility = Visibility.Visible;
                // Add fade in animation
                sb.AddFadeIn(seconds);

            }
            else
            {
                control.MenuContent.Margin = new Thickness(control.MenuContent.ActualWidth, 0, 0, 0);
                // Add slide from right animation
                sb.AddSlideToRight(seconds, control.MenuContent.ActualWidth * -1);

                control.MenuContent.Visibility = Visibility.Visible;
                border.Visibility = Visibility.Hidden;
                // Add fade in animation
                sb.AddFadeOut(seconds);
                
            }

            // Start animating
            sb.Begin(control.MenuContent);
            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }
        


        #endregion

    }
}
