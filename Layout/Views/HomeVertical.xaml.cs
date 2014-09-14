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
using ReactiveUI;
using Layout.ViewModels;
using System.Linq;
using System.Reactive.Linq;
using Layout.ViewModels.Events;

namespace Layout
{
	/// <summary>
	/// Interaction logic for HomeControl.xaml
	/// </summary>
	public partial class HomeVerticalControl
	{
        //ObservableCollection<UserControl> views;
        //Domain.Analytic _SelectedAnalytic;
        Layout.ViewModels.Reactive.EventAggregator Publisher = ((Layout.ViewModels.Reactive.EventAggregator)App.Current.Resources["EventManager"]);
		public HomeVerticalControl()
		{
			this.InitializeComponent();
            //this.WhenAnyValue(x => x.ViewModel).BindTo(this, x => x.DataContext);

            //this.Bind(ViewModel, x => x.S, x => x.Filte);

            //views = new ObservableCollection<UserControl>();
            //var h = new HomeVerticalControl();

            //views.Add(new HomeVerticalControl());
            //views.Add(new StepsControl());

            //DataContext = views;

            //this.Content = views[0];

            this.WhenAnyValue(x => x.TagListBox.SelectedItem).Subscribe( x => 
            {
                if(x != null)
                { 
                    //Load analytics by Tag
                    Publisher.Publish<Domain.Tag>(new Domain.Tag { Value = x.ToString()});
                    //Console.WriteLine(x);
                    FilterStackPanel.Visibility = Visibility.Visible;
                    
                }
            }
            );

            this.WhenAnyValue(x => x.ModuleListBox.SelectedItem).Subscribe( x =>
                    {
                        //Load analytics by ModuleType
                        if (x != null)
                        {
                            Console.WriteLine((x as ListBoxItem).Tag);

                            switch ((x as ListBoxItem).Tag.ToString())
                            {
                                case "Analytics":
                                    Publisher.Publish<Domain.SubModuleType>(Domain.SubModuleType.Analytics);
                                    break;
                                default:
                                    TagStack.Visibility = Visibility.Hidden;
                                    break;
                            }
                        }
                    }
            );
		}

        private void AddNewAnalyticButton_Click(object sender, RoutedEventArgs e)
        {
            AnalyticStepsControl c = new AnalyticStepsControl();
            c.TitleTextBox.Text = "Analytic - New";
            this.Content = c;

            
        }

        //private void PlanningModuleButton_Click(object sender, RoutedEventArgs e)
        //{

            
        //    this.Content = this;
        //    FilterListBox.Visibility = Visibility.Visible;
            

        //}

        private void RelatedPriceRoutineButton_Click(object sender, RoutedEventArgs e)
        {
            PricingStepsControl view = new PricingStepsControl();
            this.Content = view;
        }

        private void AnalyticsListItem_Selected(object sender, RoutedEventArgs e)
        {
            FilterListBox.Visibility = Visibility.Visible;

            //ViewModel.LoadTagsBySubModule("Analytics");

            //Publisher.Publish<string>("Analytics");

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

            var analytic = (Domain.Analytic)FilterListBox.SelectedItem;
            Publisher.Publish<NavigateEvent>(new NavigateEvent
            {
                Module = Domain.ModuleType.Planning,
                SubModule = Domain.SubModuleType.Analytics,
                Section = Domain.SectionType.PlanningAnalyticsFilters,
                Entity = analytic
            });
            //AnalyticStepsControl c = new AnalyticStepsControl();
            //c.TitleTextBox.Text = (FilterListBox.SelectedItem as Domain.Analytic).Name;
            //c.AnalyticStepContentControl.Content = new FilterStepControl();
            //c.StepListBox.SelectedItem = c.StepListBox.Items[1];
            //this.Content = c;
            
        }
        //private void PriceListButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Publisher.Publish<Layout.ViewModels.Events.NavigateEvent>(
        //            new Layout.ViewModels.Events.NavigateEvent
        //            {
        //                Module = Domain.ModuleType.Planning,
        //                SubModule = Domain.SubModuleType.Analytics,
        //                Section = Domain.SectionType.PlanningAnalyticsIdentity,
        //                Entity = FilterListBox.SelectedItem
        //            }
                
                
        //        );
            //AnalyticStepsControl c = new AnalyticStepsControl();
            //c.TitleTextBox.Text = (FilterListBox.SelectedItem as Domain.Analytic).Name;
            //c.AnalyticStepContentControl.Content = new FilterStepControl();
            //c.StepListBox.SelectedItem = c.StepListBox.Items[2];
            //this.Content = c;    
        //}
        private void ValueDriversButtons_Click(object sender, RoutedEventArgs e)
        {

            var analytic = (Domain.Analytic)FilterListBox.SelectedItem;
            Publisher.Publish<NavigateEvent>(new NavigateEvent
            {
                Module = Domain.ModuleType.Planning,
                SubModule = Domain.SubModuleType.Analytics,
                Section = Domain.SectionType.PlanningAnalyticsValueDrivers,
                Entity = analytic
            });
            //AnalyticStepsControl c = new AnalyticStepsControl();
            //c.TitleTextBox.Text = (FilterListBox.SelectedItem as Domain.Analytic).Name;
            //c.AnalyticStepContentControl.Content = new AnalyticValueDriversStepControl();
            //c.StepListBox.SelectedItem = c.StepListBox.Items[3];
            //this.Content = c;            

        }

        private void Filters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (e.AddedItems.Count > 0)
            {
                //publish HomesearchVM.SelectedAnalytic    -- edit in margin navigates to identity
                Publisher.Publish<SelectionEvent>(
                    new SelectionEvent
                    {
                        Entity = e.AddedItems[0] as Domain.Analytic
                    }

                    );
            }

            //if (e.AddedItems.Count > 0)
            //{
            //    var analytic = e.AddedItems[0] as Domain.Analytic;
            //    if (analytic != null)
            //    {
            //        _SelectedAnalytic = analytic;
            //        //AnalyticTabDetail.DataContext = analytic;
            //    }
            if(FilterListBox.IsMouseCaptured)
               AnalyticTabDetail.Visibility = Visibility.Visible;
                if (MarginStackPanel != null) MarginStackPanel.Visibility = Visibility.Visible;
            //}
            


            //var name = (e.AddedItems[0] as ListBoxItem).Name;
            //if(name != null)
            //{
                
            //    if(AnalyticTabDetail != null)
            //    { 

            //        AnalyticTabDetail.Visibility = Visibility.Visible;
            //        AnalyticTitle.Text = name;

            //    }
            //    if(MarginStackPanel != null) MarginStackPanel.Visibility = Visibility.Visible;
            //}
        }


        private void RenameButton_Click(object sender, RoutedEventArgs e)
        {
            //AnalyticStepsControl c = new AnalyticStepsControl();
            //c.TitleTextBox.Text = (FilterListBox.SelectedItem as Domain.Analytic).Name;
            //AnalyticIdentityStepControl i = new AnalyticIdentityStepControl();
            //i.NameTextBox.Text = (FilterListBox.SelectedItem as Domain.Analytic).Name;
            //c.AnalyticStepContentControl.Content = i;
            //this.Content = c;
            if(FilterListBox.SelectedItem != null)
            { 
                Publisher.Publish<NavigateEvent>(new NavigateEvent { 
                    Module = Domain.ModuleType.Planning,
                    SubModule = Domain.SubModuleType.Analytics,
                    Section = Domain.SectionType.PlanningAnalyticsIdentity,
                    Entity = FilterListBox.SelectedItem
                });
            }
        }

        private void CopyAnalyticButton_Click(object sender, RoutedEventArgs e)
        {
            var analytic = (Domain.Analytic)FilterListBox.SelectedItem;
            analytic.Description += "-Copy";
            Publisher.Publish<NavigateEvent>(new NavigateEvent
            {
                Module = Domain.ModuleType.Planning,
                SubModule = Domain.SubModuleType.Analytics,
                Section = Domain.SectionType.PlanningAnalyticsIdentity,
                Entity = analytic
            });

            //AnalyticStepsControl c = new AnalyticStepsControl();
            //c.TitleTextBox.Text = "Analytic - Copy";
            //this.Content = c;
        }

        private void ModuleListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (e.AddedItems.Count >= 1)
            //if (e.AddedItems.Contains(ModuleListBox.Items[0])) 
            //{
                TagStack.Visibility = System.Windows.Visibility.Visible;
            //}
            //else { FilterStackPanel.Visibility = Visibility.Collapsed; AnalyticTabDetail.Visibility = Visibility.Collapsed; }
            
        }

        private void CreatePriceRoutineButton_Click(object sender, RoutedEventArgs e)
        {

            PricingStepsControl view = new PricingStepsControl();
            PricingIdentityStepControl subView = new PricingIdentityStepControl();
            subView.NameTextBox.Text = "Price Routine for " + (FilterListBox.SelectedItem as Domain.Analytic).Name;
            subView.AnalyticTextBox.Text = (FilterListBox.SelectedItem as Domain.Analytic).Name;
            view.StepContentControl.Content = subView;
            this.Content = view;

        }

        private void FilterTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            
        }

        private void GroupTree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            FilterStackPanel.Visibility = Visibility.Visible;
        }

        private void TagListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if(AnalyticTabDetail.Visibility == Visibility.Visible)
            
                 AnalyticTabDetail.Visibility = Visibility.Hidden;
                
        }






//        public HomeSearchViewModel ViewModel
//        {
//            get
//            {
//                return (HomeSearchViewModel)GetValue(ViewModelProperty);
//            }
//            set
//            {
//                SetValue(ViewModelProperty,
//                    value);
//            }
//        }

//        object IViewFor.ViewModel
//        {
//            get { return ViewModel; }
//            set { ViewModel = (HomeSearchViewModel)value; }
//        }

//        public static readonly DependencyProperty ViewModelProperty =
//DependencyProperty.Register("ViewModel", typeof(HomeSearchViewModel), typeof(HomeVerticalControl), new PropertyMetadata(null));
	}
}