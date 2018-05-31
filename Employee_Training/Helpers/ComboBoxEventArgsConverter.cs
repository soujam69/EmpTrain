using DevExpress.Mvvm.UI;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Employee_Training.Helpers
{
    public class ComboBoxEventArgsConverter : EventArgsConverterBase<MouseEventArgs>
    {
        protected override object Convert(object sender, MouseEventArgs args)
        {
            var element = LayoutTreeHelper.GetVisualParents((DependencyObject)args.OriginalSource, (DependencyObject)sender).OfType<ComboBoxItem>().FirstOrDefault();
            return element != null ? element.DataContext : null;
        }
    }
}
