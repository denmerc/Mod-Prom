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
	public partial class AdminControl : UserControl
	{
        public AdminControl()
		{
			this.InitializeComponent();
		}

        private void UserListItem_Selected(object sender, RoutedEventArgs e)
        {
            UserListStack.Visibility = Visibility.Visible;
        }

        private void UserListItem_Selected(object sender, SelectionChangedEventArgs e)
        {
            RoleStack.Visibility = Visibility.Visible;
            MarginStackPanel.Visibility = Visibility.Visible;
            ProfileStack.Visibility = Visibility.Visible;
        }
	}
}