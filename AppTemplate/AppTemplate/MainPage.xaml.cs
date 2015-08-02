namespace AppTemplate
{
    using Windows.UI.Xaml;

    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.Loaded += this.OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            this.ToggleMenuButton.Focus(FocusState.Programmatic);
        }
    }
}