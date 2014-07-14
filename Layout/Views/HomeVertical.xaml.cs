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
            this.Content = new AnalyticStepsControl();
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

        private void AnalyticsListItem_Selected(object sender, RoutedEventArgs e)
        {
            FilterListBox.Visibility = Visibility.Visible;

        }

        private void BrakesItem_Selected(object sender, RoutedEventArgs e)
        {
            if(AnalyticTabDetail != null)
            { 
                AnalyticTabDetail.Visibility = Visibility.Visible;
            }
            if(MarginStackPanel != null) MarginStackPanel.Visibility = Visibility.Visible;
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            AnalyticStepsControl c = new AnalyticStepsControl();
            c.AnalyticStepContentControl.Content = new FilterStepControl();
            c.StepListBox.SelectedItem = c.StepListBox.Items[1];
            this.Content = c;
            
        }

        private void ValueDriversButtons_Click(object sender, RoutedEventArgs e)
        {
            AnalyticStepsControl c = new AnalyticStepsControl();
            c.AnalyticStepContentControl.Content = new AnalyticValueDriversStepControl();
            c.StepListBox.SelectedItem = c.StepListBox.Items[3];
            this.Content = c;            

        }
	}
}