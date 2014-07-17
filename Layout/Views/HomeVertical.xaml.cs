﻿using System;
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
using System.Linq;

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
            AnalyticStepsControl c = new AnalyticStepsControl();
            c.TitleTextBox.Text = "Analytic - New";
            this.Content = c;
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
            c.TitleTextBox.Text = (FilterListBox.SelectedItem as ListBoxItem).Name;
            c.AnalyticStepContentControl.Content = new FilterStepControl();
            c.StepListBox.SelectedItem = c.StepListBox.Items[1];
            this.Content = c;
            
        }
        private void PriceListButton_Click(object sender, RoutedEventArgs e)
        {
            AnalyticStepsControl c = new AnalyticStepsControl();
            c.TitleTextBox.Text = (FilterListBox.SelectedItem as ListBoxItem).Name;
            c.AnalyticStepContentControl.Content = new FilterStepControl();
            c.StepListBox.SelectedItem = c.StepListBox.Items[2];
            this.Content = c;    
        }
        private void ValueDriversButtons_Click(object sender, RoutedEventArgs e)
        {
            AnalyticStepsControl c = new AnalyticStepsControl();
            c.TitleTextBox.Text = (FilterListBox.SelectedItem as ListBoxItem).Name;
            c.AnalyticStepContentControl.Content = new AnalyticValueDriversStepControl();
            c.StepListBox.SelectedItem = c.StepListBox.Items[3];
            this.Content = c;            

        }

        private void Filters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var name = (e.AddedItems[0] as ListBoxItem).Name;
            if(name != null)
            {
                
                if(AnalyticTabDetail != null)
                { 

                    AnalyticTabDetail.Visibility = Visibility.Visible;
                    AnalyticTitle.Text = name;

                }
                if(MarginStackPanel != null) MarginStackPanel.Visibility = Visibility.Visible;
            }
        }


        private void RenameButton_Click(object sender, RoutedEventArgs e)
        {
            AnalyticStepsControl c = new AnalyticStepsControl();
            c.TitleTextBox.Text = (FilterListBox.SelectedItem as ListBoxItem).Name;
            AnalyticIdentityStepControl i = new AnalyticIdentityStepControl();
            i.NameTextBox.Text = (FilterListBox.SelectedItem as ListBoxItem).Name;
            c.AnalyticStepContentControl.Content = i;
            this.Content = c;
        }

        private void CopyAnalyticButton_Click(object sender, RoutedEventArgs e)
        {
            AnalyticStepsControl c = new AnalyticStepsControl();
            c.TitleTextBox.Text = "Analytic - Copy";
            this.Content = c;
        }

        private void ModuleListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Contains(ModuleListBox.Items[0])) 
            {
                FilterStackPanel.Visibility = Visibility.Visible;
            }
            else { FilterStackPanel.Visibility = Visibility.Collapsed; }
            
        }

        private void CreatePriceRoutineButton_Click(object sender, RoutedEventArgs e)
        {

            PricingStepsControl view = new PricingStepsControl();
            PricingIdentityStepControl subView = new PricingIdentityStepControl();
            subView.NameTextBox.Text = "Price Routine for " + (FilterListBox.SelectedItem as ListBoxItem).Name;
            subView.AnalyticTextBox.Text = (FilterListBox.SelectedItem as ListBoxItem).Name;
            view.StepContentControl.Content = subView;
            this.Content = view;

        }
	}
}