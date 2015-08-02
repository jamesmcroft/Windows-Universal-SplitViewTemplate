namespace AppTemplate.Common
{
    using System;

    using Windows.UI.Xaml.Controls;

    using AppTemplate.Views;

    using GalaSoft.MvvmLight;

    /// <summary>
    /// The navigation service.
    /// </summary>
    public class NavigationService : ViewModelBase
    {
        private bool _canGoBack;

        /// <summary>
        /// Gets or sets the navigation frame.
        /// </summary>
        public Frame NavigationFrame { get; private set; }

        /// <summary>
        /// Gets or sets the root page type.
        /// </summary>
        public Type RootPageType => typeof(HomePage); 

        /// <summary>
        /// Gets the current page type from the navigation frame.
        /// </summary>
        public Type CurrentPageType => this.NavigationFrame.CurrentSourcePageType;

        /// <summary>
        /// Gets or sets a value indicating whether the app navigation can go back.
        /// </summary>
        public bool CanGoBack
        {
            get
            {
                return this._canGoBack;
            }
            set
            {
                this.Set(() => this.CanGoBack, ref this._canGoBack, value);
            }
        }

        public void SetNavigationFrame(Frame frame)
        {
            if (frame == null) throw new ArgumentNullException(nameof(frame));

            if (this.NavigationFrame == null)
            {
                this.NavigationFrame = frame;

                if (this.RootPageType != null)
                {
                    this.Navigate(this.RootPageType);
                }

                this.CheckCanGoBack();
            }
        }

        public void GoBack()
        {
            if (this.NavigationFrame.CanGoBack)
            {
                this.NavigationFrame.GoBack();
            }

            this.CheckCanGoBack();
        }

        public void Navigate(Type sourcePage)
        {
            this.Navigate(sourcePage, null);
        }

        public void Navigate(Type sourcePage, object parameter)
        {
            this.NavigationFrame.Navigate(sourcePage, parameter);

            this.CheckCanGoBack();
        }

        private void CheckCanGoBack()
        {
            this.CanGoBack = this.NavigationFrame.CanGoBack && this.NavigationFrame.BackStackDepth > 1;
        }
    }
}
