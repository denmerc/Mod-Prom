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
using System.Linq;
using Layout.ViewModels.Events;

namespace Layout
{
	/// <summary>
	/// Interaction logic for HomeControl.xaml
	/// </summary>
	public partial class AdminControl : UserControl
	{
        Layout.ViewModels.Reactive.EventAggregator Publisher = ((Layout.ViewModels.Reactive.EventAggregator)App.Current.Resources["EventManager"]);
        public AdminControl()
		{
			this.InitializeComponent();
		}

        private void UserListItem_Selected(object sender, RoutedEventArgs e)
        {
            //UserListStack.Visibility = Visibility.Visible;
            //FilterStack.Visibility = Visibility.Collapsed;
        }

        private void UserListItem_Selected(object sender, SelectionChangedEventArgs e)
        {
            //RoleStack.Visibility = Visibility.Visible;
            //MarginStackPanel.Visibility = Visibility.Visible;
            //ProfileStack.Visibility = Visibility.Visible;
            //FilterStack.Visibility = Visibility.Collapsed;
        }

        private void RulesItem_Selected(object sender, RoutedEventArgs e)
        {
            //UserListStack.Visibility = Visibility.Collapsed;
            //FilterStack.Visibility = Visibility.Visible;
            //ProfileStack.Visibility = Visibility.Hidden;
            //RoleStack.Visibility = Visibility.Hidden;
            //MarginStackPanel.Visibility = Visibility.Hidden;
            //FilterList.ItemsSource = new[] { new { Name = "Optimization" }, new { Name = "Rounding" } }.ToList();
        }

        private void SectionListBox_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void SectionListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Publisher.Publish<SectionSelectionEvent>(
                new SectionSelectionEvent
                {
                    Section = Domain.SectionType.AdministrationFolders 

                });
        }
	}
}