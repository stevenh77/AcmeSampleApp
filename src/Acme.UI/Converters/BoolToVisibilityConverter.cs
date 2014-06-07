using System.Windows;

namespace Acme.UI.Converters
{
    public sealed class BoolToVisibilityConverter : BooleanConverter<Visibility>
    {
        public BoolToVisibilityConverter() :
            base(Visibility.Visible, Visibility.Collapsed) { }
    }
}
