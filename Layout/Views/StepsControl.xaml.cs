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
	public partial class StepsControl : UserControl
	{
		public StepsControl()
		{
			this.InitializeComponent();

		}
        private void AddNewAnalyticButton_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new StepsControl();
        }


        private void RelatedPriceRoutineButton_Click(object sender, RoutedEventArgs e)
        {
            PricingStepsControl view = new PricingStepsControl();
            view.NameTextBox.Text = "XXXX";
            view.DescriptionTextBox.Text = "XXXX";
            this.Content = view;
        }
	}
}