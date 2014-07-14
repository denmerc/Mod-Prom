using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Layout
{
    /// <summary>
    /// Interaction logic for FilterStepControl.xaml
    /// </summary>
    public partial class FilterStepControl : UserControl
    {
        public FilterStepControl()
        {
            InitializeComponent();
        }

        private void VendorSelectedListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            
            FilterGrid.DataContext = new List<Filter>()
            {
                new Filter{IsSelected=true, Code="Code1", Value="Vendor1"}
            };
            FilterGrid.Visibility = Visibility.Visible;
        }   
    }

    class Filter
    {
        public Boolean IsSelected { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
    }
}
