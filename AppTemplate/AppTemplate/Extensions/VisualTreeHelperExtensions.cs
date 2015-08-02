namespace AppTemplate.Extensions
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Media;

    public static class VisualTreeHelperExtensions
    {
        /// <summary>
        /// Gets the parent of the given element by it's type.
        /// </summary>
        /// <param name="element">
        /// The element to find the parent from.
        /// </param>
        /// <typeparam name="T">
        /// The type of parent element to find
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public static T GetParentByType<T>(this FrameworkElement element) where T : FrameworkElement
        {
            var parent = VisualTreeHelper.GetParent(element);
            while (parent != null && !(parent is T))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }

            return parent as T;
        }
    }
}