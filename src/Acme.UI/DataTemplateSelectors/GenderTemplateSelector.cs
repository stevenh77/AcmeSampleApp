using System.Windows;
using System.Windows.Controls;
using Acme.DTOs;

namespace Acme.UI.DataTemplateSelectors
{
    public class GenderTemplateSelector : DataTemplateSelector
    {
        public DataTemplate FemaleGenderTemplate { get; set; }
        public DataTemplate MaleGenderTemplate { get; set; }
        public DataTemplate UnknownGenderTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var gender = item as Gender;
            if (gender == null) return null;

            if (gender.Id == 1) return FemaleGenderTemplate;
            if (gender.Id == 2) return MaleGenderTemplate;
            if (gender.Id == 3) return UnknownGenderTemplate;

            return null;
        }
    }
}
