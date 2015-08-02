namespace AppTemplate.ViewModels.Common
{
    using AppTemplate.Common;

    using GalaSoft.MvvmLight.Ioc;
    using GalaSoft.MvvmLight.Messaging;

    using Microsoft.Practices.ServiceLocation;

    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            RegisterServiceProviders();
            RegisterViewModels();
        }

        /// <summary>
        /// Gets the main page view model.
        /// </summary>
        public MainPageViewModel MainPageViewModel => SimpleIoc.Default.GetInstance<MainPageViewModel>();

        private static void RegisterViewModels()
        {
            SimpleIoc.Default.Register<MainPageViewModel>();
        }

        private static void RegisterServiceProviders()
        {
            SimpleIoc.Default.Register<IMessenger, Messenger>();
            SimpleIoc.Default.Register<NavigationService>();
        }
    }
}
