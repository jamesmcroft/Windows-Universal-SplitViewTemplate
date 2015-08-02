namespace AppTemplate.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using Windows.UI.Xaml.Controls;

    using AppTemplate.Common;
    using AppTemplate.Controls.Models;
    using AppTemplate.ViewModels.Common;
    using AppTemplate.Views;

    using GalaSoft.MvvmLight.Command;
    using GalaSoft.MvvmLight.Messaging;

    public class MainPageViewModel : PageViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPageViewModel"/> class.
        /// </summary>
        /// <param name="messenger">
        /// The messenger.
        /// </param>
        /// <param name="navigationService">
        /// The navigation service.
        /// </param>
        public MainPageViewModel(IMessenger messenger, NavigationService navigationService)
            : base(messenger, navigationService)
        {
            this.InitializeMenu();

            this.ItemInvokedCommand = new RelayCommand<ListViewItem>(this.ItemInvoked);

        }

        /// <summary>
        /// Gets the menu items for the app.
        /// </summary>
        public ObservableCollection<SplitViewPaneMenuItem> MenuItems { get; private set; }

        /// <summary>
        /// Gets the item invoked command.
        /// </summary>
        public ICommand ItemInvokedCommand { get; private set; }

        private void InitializeMenu()
        {
            // Dummy Data
            this.MenuItems = new ObservableCollection<SplitViewPaneMenuItem>
                                 {
                                     new SplitViewPaneMenuItem
                                         {
                                             Label = "Home",
                                             Symbol = Symbol.Home,
                                             AssociatedPage = typeof(HomePage)
                                         },
                                     new SplitViewPaneMenuItem
                                         {
                                             Label = "Settings",
                                             Symbol = Symbol.Setting,
                                             AssociatedPage = typeof(SettingPage)
                                         }
                                 };

        }

        private void ItemInvoked(ListViewItem obj)
        {
            var menuItem = obj?.Content as SplitViewPaneMenuItem;
            if (menuItem != null)
            {
                this.NavigationService.Navigate(menuItem.AssociatedPage, menuItem.Parameters);
            }
        }
    }
}