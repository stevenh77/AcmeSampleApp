using System.Windows;
using System.Windows.Controls;
using Acme.DTOs;

namespace Acme.UI.DataTemplateSelectors
{
    public class CategoryTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ACategoryTemplate { get; set; }
        public DataTemplate BCategoryTemplate { get; set; }
        public DataTemplate CCategoryTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var category = item as Category;
            if (category == null) return null;

            if (category.Id == 1) return ACategoryTemplate;
            if (category.Id == 2) return BCategoryTemplate;
            if (category.Id == 3) return CCategoryTemplate;

            return null;
        }
    }
}
