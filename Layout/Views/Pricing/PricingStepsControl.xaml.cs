using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace Layout
{
	/// <summary>
	/// Interaction logic for HomeControl.xaml
	/// </summary>
	public partial class PricingStepsControl : UserControl
	{
        public PricingStepsControl()
		{
			this.InitializeComponent();
		}

        private void AddNewPricingButton_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new PricingStepsControl();
        }

        private void PlanningModuleButton_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new HomeVerticalControl();
        }

        private void RelatedAnalyticButton_Click(object sender, RoutedEventArgs e)
        {
            AnalyticStepsControl view = new AnalyticStepsControl();
            //view.NameTextBox.Text = "XXXX";
            //view.DescriptionTextBox.Text = "XXXX";
            //view.StatusTextBox.Text = "XXXX";

            this.Content = view;
        }

        private void FilterStepListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            FilterStepControl view = new FilterStepControl();
            view.FilterGrid.Visibility = Visibility.Collapsed;
            StepContentControl.Content = view;
        }

        private void IdentityListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            if (StepContentControl != null)
            {
                PricingIdentityStepControl c = new PricingIdentityStepControl();
                this.StepContentControl.Content = c;
            }
        }

        private void PriceListItem_Selected(object sender, RoutedEventArgs e)
        {
            PriceListStepControl content = new PriceListStepControl();
            this.StepContentControl.Content = content;
        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            this.StepContentControl.Content = null;
        }

	}
}