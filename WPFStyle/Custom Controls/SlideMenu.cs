using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace WPFStyle
{
    [TemplatePart(Name = ShadowBorderPartName, Type = typeof(FrameworkElement))]
    [TemplatePart(Name = MenuContentPartName, Type = typeof(FrameworkElement))]
    [TemplatePart(Name = ShadowMenuContentPartName, Type = typeof(FrameworkElement))]

    /// <summary>
    /// É um controle personalizado que irá ser um menu que desliza para o lado
    /// </summary>
    public class SlideMenu : ContentControl
    {
        public const string MenuContentPartName = "PART_MenuContent";
        public const string ShadowBorderPartName = "PART_ContentCover";
        public const string ShadowMenuContentPartName = "PART_ShadowMenuContent";
        public const float TimeOfSlide = 0.6f;

        private FrameworkElement _shadowBorderElement;

        #region DependencyProperty

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
            DependencyProperty.Register(nameof(IsOpen), typeof(bool), typeof(SlideMenu), new FrameworkPropertyMetadata(default(bool), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, IsOpenChangedCallback));

        /// <summary>
        /// Direções que o menu pode aparecer
        /// </summary>
        public Directions SlideDirection
        {
            get { return (Directions)GetValue(SlideDirectionProperty); }
            set { SetValue(SlideDirectionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SlideDirection.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SlideDirectionProperty =
            DependencyProperty.Register(nameof(SlideDirection), typeof(Directions), typeof(SlideMenu), new PropertyMetadata(Directions.Left, SlideDirectionChangedCallback));

        #endregion

        #region Callbacks Methods
        
        private async static void IsOpenChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as SlideMenu;

            if (control == null)
                return;

            var sb = new Storyboard();
            
            var isOpen = (bool)e.NewValue;

            switch (control.SlideDirection)
            {
                case Directions.Left:
                    if (isOpen)
                        sb.AddSlideFromLeft(TimeOfSlide, control.MenuContent.ActualWidth);
                    else
                        sb.AddSlideToRight(TimeOfSlide, control.MenuContent.ActualWidth * -1);
                    break;

                case Directions.Right:
                    if (isOpen)
                        sb.AddSlideFromRight(TimeOfSlide, control.MenuContent.ActualWidth);
                    else
                        sb.AddSlideToLeft(TimeOfSlide, control.MenuContent.ActualWidth * -1);
                    break;

                default:
                    break;
            }

            control.MenuContent.Visibility = Visibility.Visible;

            sb.AddFadeIn(TimeOfSlide);

            // Começa a animação
            sb.Begin(control.MenuContent);

            // Espera até a animimação terminar
            await Task.Delay((int)(TimeOfSlide * 1000));
        }

        private static void SlideDirectionChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as SlideMenu;
            if(control == null)
                return;

            control.SlideChanged(control.IsOpen);
        }

        public void SlideChanged(bool isOpen)
        {
            SetCurrentValue(IsOpenProperty, !isOpen);
            SetCurrentValue(IsOpenProperty, isOpen);
        }
        
        #endregion

        #region Override Methods

        public override void OnApplyTemplate()
        {

            if (_shadowBorderElement != null)
                _shadowBorderElement.MouseLeftButtonDown += ShadowBorderOnPreviewMouseLeftButtonUp;

            base.OnApplyTemplate();

            // Busca o elemento e retorna na variável para ser usada
            _shadowBorderElement = GetTemplateChild(ShadowBorderPartName) as FrameworkElement;

            if (_shadowBorderElement != null)
                _shadowBorderElement.MouseLeftButtonDown += ShadowBorderOnPreviewMouseLeftButtonUp;
        }

        #endregion

        #region Event Methods

        /// <summary>
        /// Quando clicam no conteudo sombreado do menu, ativa este evento que fecha o menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="mouseButtonEventArgs"></param>
        private void ShadowBorderOnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            SetCurrentValue(IsOpenProperty, false);
        }

        #endregion
    }
}
