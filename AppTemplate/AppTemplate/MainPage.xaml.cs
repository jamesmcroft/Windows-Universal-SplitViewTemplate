namespace AppTemplate
{
    using AppTemplate.ViewModels.Common;

    using Windows.Foundation.Metadata;
    using Windows.UI.Core;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public sealed partial class MainPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            this.InitializeComponent();

            this.Loaded += this.OnLoaded;

            SystemNavigationManager.GetForCurrentView().BackRequested += this.OnBackRequested;

            if (ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                this.BackButton.Visibility = Visibility.Collapsed;
            }

            this.DataContextChanged += this.OnDataContextChanged;
        }

        private void OnDataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            var viewModel = this.DataContext as PageViewModel;
            viewModel?.SetPageFrame(this.AppFrame);
        }

        private void OnBackRequested(object sender, BackRequestedEventArgs args)
        {
            var viewModel = this.DataContext as PageViewModel;
            viewModel?.NavigateBack(args);
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            this.ToggleMenuButton.Focus(FocusState.Programmatic);
        }

        private void OnMenuButtonChecked(object sender, RoutedEventArgs e)
        {
            if (this.AppMenu.DisplayMode == SplitViewDisplayMode.Inline
                || this.AppMenu.DisplayMode == SplitViewDisplayMode.Overlay)
            {
                this.ToggleMenuButton.TransformToVisual(this);
            }
        }
    }
}