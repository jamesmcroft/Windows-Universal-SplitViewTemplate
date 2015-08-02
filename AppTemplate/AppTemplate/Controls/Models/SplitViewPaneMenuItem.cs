namespace AppTemplate.Controls.Models
{
    using System;

    using Windows.UI.Xaml.Controls;

    public class SplitViewPaneMenuItem
    {
        public string Label { get; set; }

        public Symbol Symbol { get; set; }

        public char SymbolAsChar => (char)this.Symbol;

        public Type AssociatedPage { get; set; }

        public object Parameters { get; set; }
    }
}