namespace AppTemplate.ViewModels.Common
{
    using System;
    using System.Windows.Input;

    using Windows.UI.Core;
    using Windows.UI.Xaml.Controls;

    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using GalaSoft.MvvmLight.Messaging;

    public abstract class PageViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PageViewModel"/> class.
        /// </summary>
        protected PageViewModel(IMessenger messenger, NavigationService navigationService)
        {
            this.NavigateBackCommand = new RelayCommand(() => this.NavigateBack(null));
        }

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
            // ToDo: navigation
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

            // Set navigation frame;
        }
    }
}