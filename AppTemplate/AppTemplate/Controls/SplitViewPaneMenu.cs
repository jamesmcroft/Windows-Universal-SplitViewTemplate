namespace AppTemplate.Controls
{
    using System;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Animation;

    using AppTemplate.Extensions;

    public class SplitViewPaneMenu : ListView
    {
        private SplitView _parent;

        public event EventHandler<ListViewItem> ItemInvoked;

        public SplitViewPaneMenu()
        {
            this.SelectionMode = ListViewSelectionMode.Single;
            this.IsItemClickEnabled = true;
            this.ItemClick += this.OnItemClick;

            this.Loaded += this.OnLoaded;
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            for (var i = 0; i < this.ItemContainerTransitions.Count; i++)
            {
                if (this.ItemContainerTransitions[i] is EntranceThemeTransition)
                {
                    this.ItemContainerTransitions.RemoveAt(i);
                }
            }
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            var splitView = this.GetParentByType<SplitView>();
            if (splitView == null)
            {
                throw new InvalidOperationException(
                    "SplitViewPaneMenu cannot be applied to a control that is not of type SplitView");
            }

            this._parent = splitView;
            this._parent.RegisterPropertyChangedCallback(
                SplitView.IsPaneOpenProperty,
                (control, args) => { this.OnPaneToggled(); });

            this.OnPaneToggled(); ;
        }

        private void OnPaneToggled()
        {
            if (this._parent.IsPaneOpen)
            {
                this.ItemsPanelRoot.ClearValue(WidthProperty);
                this.ItemsPanelRoot.ClearValue(HorizontalAlignmentProperty);
            }
            else if (this._parent.DisplayMode == SplitViewDisplayMode.CompactInline
                     || this._parent.DisplayMode == SplitViewDisplayMode.CompactOverlay)
            {
                this.ItemsPanelRoot.SetValue(WidthProperty, this._parent.CompactPaneLength);
                this.ItemsPanelRoot.SetValue(HorizontalAlignmentProperty, HorizontalAlignment.Left);
            }
        }

        private void OnItemClick(object sender, ItemClickEventArgs e)
        {
            var item = this.ContainerFromItem(e.ClickedItem);
            this.InvokeItem(item);
        }

        private void InvokeItem(object item)
        {
            var lvi = item as ListViewItem;

            var isAlreadySelected = lvi != null && lvi.IsSelected;

            this.SetSelected(lvi);

            if (!isAlreadySelected)
            {
                this.ItemInvoked?.Invoke(this, item as ListViewItem);
            }

            if (this._parent.IsPaneOpen
                && (this._parent.DisplayMode == SplitViewDisplayMode.CompactOverlay
                    || this._parent.DisplayMode == SplitViewDisplayMode.Overlay))
            {
                this._parent.IsPaneOpen = false;

                var viewItem = item as ListViewItem;
                viewItem?.Focus(FocusState.Programmatic);
            }
        }

        private void SetSelected(ListViewItem item)
        {
            var idx = -1;
            if (item != null)
            {
                idx = this.IndexFromContainer(item);
            }

            for (var i = 0; i < this.Items.Count; i++)
            {
                var lvi = (ListViewItem)this.ContainerFromIndex(i);
                if (i != idx)
                {
                    lvi.IsSelected = false;
                }
                else if (i == idx)
                {
                    lvi.IsSelected = true;
                }
            }
        }
    }
}