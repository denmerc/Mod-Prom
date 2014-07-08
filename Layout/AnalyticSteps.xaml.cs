﻿using MahApps.Metro.Controls;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AnalyticSteps : MetroWindow
    {
        public AnalyticSteps()
        {
            InitializeComponent();
        }

        private void MessageCenterButton_Click(object sender, RoutedEventArgs e)
        {
            var flyout = this.Flyouts.Items[0] as Flyout;
            if (flyout == null)
            {
                return;
            }

            flyout.IsOpen = !flyout.IsOpen;

            DetailContentScrollViewer.HorizontalAlignment=HorizontalAlignment.Stretch;
            CommandBarStackPanel.Width = 400;
        }

        private void Flyout_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        private void MessageCenter_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {

        }

        private void MessageCenter_IsOpenChanged(object sender, EventArgs e)
        {
            var f = sender as Flyout;
            if(f != null && f.IsOpen==false)
                CommandBarStackPanel.Width = 55;
        }

        private void PropertiesButton_Click(object sender, RoutedEventArgs e)
        {
            var flyout = this.Flyouts.Items[1] as Flyout;
            if (flyout == null)
            {
                return;
            }

            flyout.IsOpen = !flyout.IsOpen;

            DetailContentScrollViewer.HorizontalAlignment = HorizontalAlignment.Stretch;
            CommandBarStackPanel.Width = 400;
        }
    }
}
