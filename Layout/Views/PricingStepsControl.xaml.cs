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
            this.Content = new StepsControl();
        }

        private void PlanningModuleButton_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new HomeVerticalControl();
        }

        private void RelatedAnalyticButton_Click(object sender, RoutedEventArgs e)
        {
            StepsControl view = new StepsControl();
            view.NameTextBox.Text = "XXXX";
            view.DescriptionTextBox.Text = "XXXX";
            view.StatusTextBox.Text = "XXXX";

            this.Content = view;
        }
	}
}