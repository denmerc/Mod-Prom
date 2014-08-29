using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Layout
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {


        protected override void OnStartup(StartupEventArgs e)
        {
            var eventManager = new Layout.ViewModels.Reactive.EventAggregator();
            App.Current.Resources.Add("EventManager", eventManager);
            base.OnStartup(e);
        }
    }
}
