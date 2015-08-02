namespace AppTemplate.ViewModels
{
    using AppTemplate.Common;
    using AppTemplate.ViewModels.Common;

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
        }
    }
}
