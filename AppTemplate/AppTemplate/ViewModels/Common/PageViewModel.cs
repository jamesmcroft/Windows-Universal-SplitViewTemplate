namespace AppTemplate.ViewModels.Common
{
    using System;
    using System.Windows.Input;

    using Windows.UI.Core;
    using Windows.UI.Xaml.Controls;

    using AppTemplate.Common;

    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using GalaSoft.MvvmLight.Messaging;

    public abstract class PageViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PageViewModel"/> class.
        /// </summary>
        /// <param name="messenger">
        /// The messenger.
        /// </param>
        /// <param name="navigationService">
        /// The navigation Service.
        /// </param>
        protected PageViewModel(IMessenger messenger, NavigationService navigationService)
        {
            if (messenger == null) throw new ArgumentNullException(nameof(messenger));
            if (navigationService == null) throw new ArgumentNullException(nameof(navigationService));

            this.Messenger = messenger;
            this.NavigationService = navigationService;

            this.NavigateBackCommand = new RelayCommand(() => this.NavigateBack(null));
        }

        /// <summary>
        /// Gets the navigation service.
        /// </summary>
        public NavigationService NavigationService { get; private set; }

        /// <summary>
        /// Gets the messenger.
        /// </summary>
        public IMessenger Messenger { get; private set; }

        /// <summary>
        /// Gets the command for navigating backwards.
        /// </summary>
        public ICommand NavigateBackCommand { get; private set; }

        /// <summary>
        /// Called to request the navigation frame to navigate backwards.
        /// </summary>
        /// <param name="args">
        /// The arguments passed from sources requesting to go back (i.e. System back button).
        /// </param>
        public virtual void NavigateBack(BackRequestedEventArgs args)
        {
            if (this.NavigationService.CanGoBack)
            {
                if (args != null)
                {
                    args.Handled = true;
                }

                this.NavigationService.GoBack();
            }
        }

        /// <summary>
        /// Sets the navigation page frame.
        /// </summary>
        /// <param name="frame">
        /// The frame to set as the navigation frame.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if any parameter is null.
        /// </exception>
        public void SetPageFrame(Frame frame)
        {
            if (frame == null) throw new ArgumentNullException(nameof(frame));

            this.NavigationService.SetNavigationFrame(frame);
        }
    }
}