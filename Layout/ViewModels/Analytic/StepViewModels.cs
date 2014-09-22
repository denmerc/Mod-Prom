using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layout.ViewModels.Analytic
{
    class IdentityViewModel : ViewModelBase
    {
        public IdentityViewModel(object entity)
        {
            SelectedAnalytic = (Domain.Analytic)entity;
            //Tags2 = SelectedAnalytic.Tags;
            Tags = new ReactiveList<Domain.Tag>(){
                new Domain.Tag{Value="tag-ut"}
            };
            TagsToSuggest = SelectedAnalytic.Tags.Select(t => new Domain.Tag { Value = t.ToString() }).ToList();
            SelectedTags.AddRange( SelectedAnalytic.Tags.Select(t => new Domain.Tag { Value = t.ToString() })); 
            //SelectedTags = SelectedAnalytic.Tags.Select(t => new Domain.Tag { Value = t.ToString() }).ToList();

        }

        private ReactiveList<Domain.Tag> _SelectedTags = new ReactiveList<Domain.Tag>();
        public ReactiveList<Domain.Tag> SelectedTags { get { return _SelectedTags; } set { this.RaiseAndSetIfChanged(ref _SelectedTags, value); } }
        private ReactiveList<Domain.Tag> _Tags;
        public ReactiveList<Domain.Tag> Tags { get { return _Tags; } set { this.RaiseAndSetIfChanged(ref _Tags, value); } }
        private List<Domain.Tag> _TagsToSuggest;
        public List<Domain.Tag> TagsToSuggest { get { return _TagsToSuggest; } set { this.RaiseAndSetIfChanged(ref _TagsToSuggest, value); } }

        //Selected Domain.Analytic
        //private Domain.Analytic _SelectedAnalytic;
        //public Domain.Analytic SelectedAnalytic
        //{
        //    get { return _SelectedAnalytic; }
        //    set { this.RaiseAndSetIfChanged(ref _SelectedAnalytic, value); }
        //}

        //public void Load(object entity)
        //{
        //    SelectedAnalytic = (Domain.Analytic)entity;
        //}
    }

    class FilterViewModel : ViewModelBase
    {
        Layout.ViewModels.Reactive.EventAggregator EventManager = ((Layout.ViewModels.Reactive.EventAggregator)App.Current.Resources["EventManager"]);

        public FilterViewModel(object entity)
        {
            SelectedAnalytic = (Domain.Analytic)entity;

            //List of filter types
            FilterTypes = Enum.GetValues(typeof(Domain.FilterType)).Cast<Domain.FilterType>().ToList();
            //FilterTypes = SelectedAnalytic.Filters.Select(x => x.Type).Distinct().ToList();

            //selected filter type default it on first load
            SelectedType = Domain.FilterType.VendorCode;

            //filtered list of filter items based on type

            EventManager.GetEvent<Domain.FilterType>()
                .Subscribe(ftype =>
                {
                    var type = Enum.GetName(typeof(Domain.FilterType), ftype);
                    FilterItems = SelectedAnalytic.Filters.Where( fs => fs.Type == type).SelectMany(x => x.Items.Where(t => t.Type == SelectedType) )
                                        .Select(f => new FilterItemViewModel { Code = f.Code, Description = f.Description, IsSelected = true}).ToList();
                    
                });

            
        }

        //public void Load(object entity)
        //{
        //    SelectedAnalytic = (Domain.Analytic)entity;
        //}
        
        //private Domain.Analytic _SelectedAnalytic;
        //public Domain.Analytic SelectedAnalytic
        //{
        //    get { return _SelectedAnalytic; }
        //    set { this.RaiseAndSetIfChanged(ref _SelectedAnalytic, value); }
        //}

        private List<FilterItemViewModel> _FilterItems;
        public List<FilterItemViewModel> FilterItems { get { return _FilterItems; } set { this.RaiseAndSetIfChanged(ref _FilterItems, value); } }

        private Domain.FilterType _SelectedType;
        public Domain.FilterType SelectedType { get { return _SelectedType; } set { this.RaiseAndSetIfChanged(ref _SelectedType, value); } }

        private List<Domain.FilterType> _FilterTypes;
        public List<Domain.FilterType> FilterTypes { get { return _FilterTypes; } set { this.RaiseAndSetIfChanged(ref _FilterTypes, value); } }
    }

    class FilterItemViewModel : ViewModelBase
    {
        private Boolean _IsSelected = false;
        public Boolean IsSelected { get { return _IsSelected; } set { this.RaiseAndSetIfChanged(ref _IsSelected, value); } }

        private string _Code;
        public string Code { get { return _Code; } set { this.RaiseAndSetIfChanged(ref _Code, value); } }

        private string _Description;
        public string Description { get { return _Description; } set { this.RaiseAndSetIfChanged(ref _Description, value); } }
    }

    class DriverViewModel : ViewModelBase
    {        
        
        Layout.ViewModels.Reactive.EventAggregator EventManager = ((Layout.ViewModels.Reactive.EventAggregator)App.Current.Resources["EventManager"]);
        public DriverViewModel(object entity)
        {
            SelectedAnalytic = (Domain.Analytic)entity;
            Groups = SelectedAnalytic.Drivers.SelectMany(d => d.Groups).ToList();
            ModeTypes = Enum.GetValues(typeof(Domain.Mode)).Cast<Domain.Mode>().ToList();
            DriverTypes = Enum.GetValues(typeof(Domain.ValueDriverType)).Cast<Domain.ValueDriverType>().ToList();
            SelectedDriverType = Domain.ValueDriverType.Markup; 
            SelectedMode = Domain.Mode.Auto;
            EventManager.GetEvent<ViewModels.Events.DriverSelectedEvent>()
                .Subscribe(evt =>
                {
                    SelectedDriverType = evt.DriverType;
                    SelectedMode = evt.Mode;
                    Groups = SelectedAnalytic.Drivers
                        .Where(d => d.Type == SelectedDriverType && d.Mode == SelectedMode)
                        .SelectMany(set => set.Groups).ToList();
                    this.RaisePropertyChanged("Groups");
                });

        }

        public List<Domain.Mode> ModeTypes { get; set; }
        public List<Domain.ValueDriverType> DriverTypes { get; set; }

        private List<Domain.Group> _Groups;
        public List<Domain.Group> Groups { get { return _Groups; } set { this.RaiseAndSetIfChanged(ref _Groups, value); } }
        public Domain.ValueDriverType SelectedDriverType { get; set; }
        private Domain.Mode _SelectedMode;
        public Domain.Mode SelectedMode { get { return _SelectedMode; } set { this.RaiseAndSetIfChanged(ref _SelectedMode, value); } }
    }

    class ResultsViewModel : ViewModelBase
    {
        public ResultsViewModel(object entity)
        {
            SelectedAnalytic = (Domain.Analytic)entity;
        }


    }
}
