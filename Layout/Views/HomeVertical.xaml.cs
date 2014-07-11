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
using System.Collections.ObjectModel;

namespace Layout
{
	/// <summary>
	/// Interaction logic for HomeControl.xaml
	/// </summary>
	public partial class HomeVerticalControl : UserControl
	{
        //ObservableCollection<UserControl> views;
		public HomeVerticalControl()
		{
			this.InitializeComponent();
            //views = new ObservableCollection<UserControl>();
            //var h = new HomeVerticalControl();

            //views.Add(new HomeVerticalControl());
            //views.Add(new StepsControl());

            //DataContext = views;

            //this.Content = views[0];
		}

        private void AddNewAnalyticButton_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new StepsControl();
        }

        private void PlanningModuleButton_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new HomeVerticalControl();
        }

        private void RelatedPriceRoutineButton_Click(object sender, RoutedEventArgs e)
        {
            PricingStepsControl view = new PricingStepsControl();
            this.Content = view;
        }
	}
}