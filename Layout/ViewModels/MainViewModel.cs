﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Layout;
using Layout.ViewModels;
using ReactiveUI;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Layout.ViewModels.Events;
using Layout.Data;
using Domain;
using System.Windows;


namespace Layout.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public static Dictionary<Domain.SubModuleType, ViewModelBase> SubModuleCache = new Dictionary<Domain.SubModuleType, ViewModelBase>();
        //private static Dictionary<Domain.SubModuleType, List<ViewModelBase>> SubModuleCacheHistory = new Dictionary<Domain.SubModuleType, List<ViewModelBase>>();

        public MainViewModel()
        {
            //Seed();
            EventManager = ((Reactive.EventAggregator)App.Current.Resources["EventManager"]);
            SearchRepo = new Data.MockSearchRepository();
            AnalyticRepo = new Data.MockAnalyticRepository();
            PricingRepo = new Data.MockPricingRepository();

            //initialize session --> login mock User.IsAuthenticated = true
            //load session module list and tags
            Session = new Domain.Session
            {
                User = new Domain.User { Login = "dennism", FirstName = "Dennis", LastName = "Mercado", IsAuthenticated  = true }

            };


            //var loadTags = ReactiveCommand.Create();
            //loadTags.Subscribe(_ => {

            //    Session.Tags = SearchRepo.AllTags();
            //    Console.WriteLine(Session.Tags);
            //});

            //loadTags.Execute(null);

            //EventManager.GetEvent<Domain.ModuleType>()
            //    .Subscribe(module =>
            //    {
            //        var moduleType = (Domain.ModuleType)module;
            //        if(SubModuleCache.ContainsKey(moduleType))
            //        {
            //             SelectedSubModuleViewModel = SubModuleCache[moduleType];
            //        }
            //        else
            //        {
            //             SelectedSubModuleViewModel = new HomeSearchViewModel(SearchRepo, Session, EventManager);
            //        }
            //    });

            EventManager.GetEvent<NavigateEvent>()
                .Subscribe(navigator =>
                {
                    switch (navigator.Module)
                    {
                        case ModuleType.Planning:
                            switch (navigator.SubModule)
                            {
                                case Domain.SubModuleType.Analytics: //static-singleton SubModuleVM with proxies with sections reloaded
                                    //add if it doesnt exist otherwise navigate 
                                    if(!SubModuleCache.ContainsKey(navigator.SubModule))
                                    {
                                        //populate name for header
                                        var analytic = (Domain.Analytic)navigator.Entity;

                                        SelectedSubModuleViewModel = new AnalyticModuleViewModel(AnalyticRepo, Session, analytic.Name);
                                        SubModuleCache.Add(navigator.SubModule, SelectedSubModuleViewModel);
                                    }
                                    else
                                    {
                                        SelectedSubModuleViewModel = SubModuleCache[Domain.SubModuleType.Analytics];
                                
                                    }
                                    //if(navigator.Entity != null)
                                       ((AnalyticModuleViewModel)SubModuleCache[navigator.SubModule]).Navigate(navigator);
                                       //load tags from home search here todo:
                                
                                    break;
                                case Domain.SubModuleType.Everyday:
                                case Domain.SubModuleType.Promotions:
                                case Domain.SubModuleType.Kits:
                                    if (!SubModuleCache.ContainsKey(navigator.SubModule))
                                    {
                                        SelectedSubModuleViewModel = new PricingModuleViewModel(PricingRepo, Session);
                                    }
                                    else
                                    {
                                        ((PricingModuleViewModel)SubModuleCache[navigator.SubModule]).Navigate(navigator.Section);
                                    }
                                    break;
                                case Domain.SubModuleType.Search:
                                    if(!SubModuleCache.ContainsKey(navigator.SubModule))
                                    {
                                        SelectedSubModuleViewModel = new HomeSearchViewModel(SearchRepo, Session, EventManager); 
                                    }
                                    else
                                    {
                               
                                        SelectedSubModuleViewModel = SubModuleCache[Domain.SubModuleType.Search];
                                        this.RaisePropertyChanged("SelectedSubModuleViewModel");
                                        ((HomeSearchViewModel)SelectedSubModuleViewModel).ToggleSearchPane(navigator.SubModule);

                                    }
                                    break;
                                case Domain.SubModuleType.MySettings:
                                    //if(!SubModuleCache.ContainsKey(navigator.SubModule))
                                    //{
                                    //    SelectedSubModuleViewModel = new FolderSettingsViewModel(); 
                                    //}
                                    //else
                                    //{
                               
                                    //    SelectedSubModuleViewModel = SubModuleCache[Domain.SubModuleType.Search];
                               

                                    //}
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case ModuleType.Tracking:
                            break;
                        case ModuleType.Reporting:
                            break;
                        case ModuleType.Administration:


                            if (!SubModuleCache.ContainsKey(navigator.SubModule))
                            {
                                SelectedSubModuleViewModel = new AdminModuleViewModel();
                                SubModuleCache.Add(navigator.SubModule, SelectedSubModuleViewModel);
                            }
                            else
                            {
                                SelectedSubModuleViewModel = ((AdminModuleViewModel)SubModuleCache[navigator.SubModule]);
                            }


                            //((AdminViewModel)SelectedSubModuleViewModel).Navigate(navigator.Section);

                            //switch (navigator.SubModule)
                            //{

                            //    case Domain.SubModuleType.AdminDefault: //change SelectedSectionViewModel to FolderSettingsViewModel
                            //        ((AdminViewModel)SelectedSubModuleViewModel).Navigate(navigator.Section);
                            //        break;
                                
                            //    default:
                            //        break;
                                
                            //}
                            break;
                        default:
                            break;
                    }
                    
                    //if (!SubModuleCache.ContainsKey(navigator.SubModule))
                    //{
                    //    SubModuleCache.Add(navigator.SubModule, SelectedSubModuleViewModel);
                    //}
                    //SelectedSubModuleViewModel = Navigator.NavigateSectionBySectionType((Domain.SubModuleType)section);
                    
                });
            //SubModuleKeys = new[] { Domain.SubModuleType.Analytics, Domain.SubModuleType.Everyday, Domain.SubModuleType.Promotions, Domain.SubModuleType.Kits, Domain.SubModuleType.MySettings }.ToList();


            
           //default
           SelectedSubModuleViewModel = new HomeSearchViewModel(SearchRepo, Session, EventManager); 
           SubModuleCache.Add(Domain.SubModuleType.Search, SelectedSubModuleViewModel);


            //Commands
            //search by tags -> session.analytics
            //ReadAnalytic(id) find in session.analytics and show detail in panel inline
            //EditAnalytic(id) SelectedModuleViewModel == EditAnalyticVM(analytic)
            //navigate module -- change SelectedModuleVM
            //navigate by submodule -- change SelectedSubModuleVM
            //navigate by section -- change SelectedSectionVM
            

       
            //load lookups - filters  Filters_GetDistinctFilterTypeList()
            
            
       }
        private FolderSet _FolderSet;
        public FolderSet FolderSet { get { return _FolderSet; } set { this.RaiseAndSetIfChanged(ref _FolderSet, value); } }
        //public ViewModels.Navigator Navigator { get; set; }
        public Reactive.EventAggregator EventManager { get; set; }

        public static Data.ISearchRepository SearchRepo { get; set; }
        public Data.IAnalyticRepository AnalyticRepo { get; set; }
        public Data.IPricingRepository PricingRepo { get; set; }

        public Domain.Session Session { get; set; } //contains user history
        
        private ViewModelBase _SelectedSubViewModel;
        public ViewModelBase SelectedSubModuleViewModel { 
            get
            {
                return _SelectedSubViewModel;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _SelectedSubViewModel, value);

            }
        
        } //eg. 1) Home/SearchVM or 2) AnalyticEditVM 3) PricingEditVM  4) MySettings VM
                                                                  //Admin - 1) UsersVM 2) RulesVM etc..

        //public ViewModelBase SelectedPlanningViewModel { get; set; }
        //public ViewModelBase SelectedTrackingViewModel { get; set; }
        //public ViewModelBase SelectedAdminViewModel { get; set; } //preload


        //Screen sections
        public string MessageCenterViewModel { get; set; }
        public string StatusCenterViewModel { get; set; }


        //service references

        //Lookup lists?
        public List<Domain.Filter> SampleFilters { get; set; }
        //public List<Domain.Folder> SampleFolders { get; set; }

        //public List<Domain.SubModuleType> SubModuleKeys { get; set; }

        public void Seed()
        {
            Random r = new Random();

            //Mock lookups
            SampleFilters = new List<Domain.Filter>();
            //SampleFolders = new List<Domain.Folder>();

            for (int i = 0; i < 100; i++)
            {
                SampleFilters.Add(new Domain.Filter());
                //SampleFolders.Add(new Domain.Folder());
            }
            int j = 0;
            //SampleFilters.ForEach(x => x.Id = ++j);
            SampleFilters.ForEach(x => x.Code +=  ++j);

            //SampleFilters.ForEach(x => x.IsSelected = r.NextDouble() > 0.5);


            Session = new Domain.Session
            {
                User = new Domain.User { Login="dennism", FirstName = "Dennis", LastName="Mercado"},
                Analytics = new List<Domain.Analytic>
                {
                    new Domain.Analytic()
                    {
                        Id="1",
                        Name="Air & Fuel Delivery",
                        Description = "All Air & Fuel Delivery parts",
                        Status = "Active",
                        //Group1 = "Group!",
                        //Group2 = "Group2",
                        //Folder = "Folder1",
                        //Filters = SampleFilters.Where(x => x.IsSelected == true).ToList()
                    },
                    new Domain.Analytic()
                    {
                        Id="2",
                        Name="Bed Mats & Tonneau Covers",
                        Description = "All Mats and Covers",
                        Status = "Active"
                        //,Group1 = "Group1",
                        //Group2 = "Group2",
                        //Folder = "Folder1",
                        //,Filters = SampleFilters.Where(x => x.IsSelected == false).ToList()
                    },
                    new Domain.Analytic()
                    {
                        Id="3",
                        Name="Books",
                        Description = "All Books",
                        Status = "Active"
                        //,Group1 = "Group@",
                        //Group2 = "Group2"
                        //,Folder = "Folder1",
                        //,Filters = SampleFilters.Skip(r.Next()).Take(r.Next()).ToList()
                    },
                    new Domain.Analytic()
                    {
                        Id="4"
                        ,Name="Brake Systems"
                        ,Description = "All Brake Systems"
                        ,Status = "Active"
                        //,Group1 = "Group$"
                        //,Group2 = "Group2"
                        //,Folder = "Folder1"
                        //,Filters = SampleFilters.Skip(r.Next()).Take(r.Next()).ToList()
                    },
                    new Domain.Analytic()
                    {
                        Id="5",
                        Name="Bumpers & Hardware",
                        Description = "All Bumpers & Hardware",
                        Status = "Active"
                        //,Group1 = "Group$"
                        //,Group2 = "Group2"
                        //,Folder = "Folder1"
                        //,Filters = SampleFilters.Skip(r.Next()).Take(r.Next()).ToList()

                    },
                    new Domain.Analytic()
                    {
                        Id="6"
                        ,Name="Car Care & Paint"
                        ,Description = "All Car Care parts"
                        ,Status = "Active"
                        //,Group1 = "Group$"
                        //,Group2 = "Group2"
                        //,Folder = "Folder1"
                    },
                    new Domain.Analytic()
                    {
                        Id="7",
                        Name="Video & Software",
                        Description = "All Video & Software parts",
                        Status = "Active"
                        //,Group1 = "Group$"
                        //,Group2 = "Group2"
                        //,Folder = "Folder1"
                    },
                    new Domain.Analytic()
                    {
                        Id="8"
                        ,Name="Loyalty Points"                      
                        ,Description = "All Loyalty Points"
                        ,Status = "Active"
                        //,Group1 = "Group$"
                        //,Group2 = "Group2"
                        //,Folder = "Folder1"
                        //,Filters = SampleFilters.Skip(r.Next()).Take(r.Next()).ToList()
                    }
                }
                
            };


            
        }//original seed
    }
}


namespace Layout.ViewModels
{




    //Default SubModule for plannning
    public class HomeSearchViewModel : ViewModelBase
    {
        /*
         * Bindings List submodules, List of tags, List of results, selected entityVM -- set of actions eg. copy, edit, add
         * 
         * command that switches object type to search (analytics or price routines) & gets tags by submodule type
         * command that set detail to specfic object in searched list
         * */
        public HomeSearchViewModel(Data.ISearchRepository repo, Domain.Session session, Reactive.EventAggregator eventManager)
        {

            Session = session;
            EventManager = eventManager;



            //SubModuleKeys = new[] { Domain.SubModuleTypke.Analytics, Domain.SubModuleType.Everyday, Domain.SubModuleType.Promotions, Domain.SubModuleType.Kits, Domain.SubModuleType.MySettings }.ToList();
            SubModuleKeys = Enum.GetValues(typeof(Domain.SubModuleType)).Cast<Domain.SubModuleType>().ToList();

            LoadFolderSetCommand = ReactiveCommand.CreateAsyncTask(async _ =>
                await Task.Run(() =>
                {

                    FolderSet = repo.AllFolderSets();


                }));

            


            LoadTagsBySubModuleCommand = ReactiveCommand.Create();
            LoadTagsBySubModuleCommand.Subscribe(x =>
            {
                switch((Domain.SubModuleType) x)
                {
                    case Domain.SubModuleType.Analytics:
                        AnalyticTags = FolderSet.SelectedAnalyticFolders;
                        //AnalyticTags = repo.AllTagsBySubModule(x.ToString());
                        break;
                    case Domain.SubModuleType.Everyday:
                    case Domain.SubModuleType.Promotions:
                    case Domain.SubModuleType.Kits:
                        PricingTags = repo.AllTagsBySubModule(x.ToString());
                        break;
                }
            });

            LoadFavoritesBySubModuleCommand = ReactiveCommand.Create();
            LoadFavoritesBySubModuleCommand.Subscribe(x =>
            {
                switch((Domain.SubModuleType) x)
                {
                    case Domain.SubModuleType.Analytics:
                        FavoriteTags = repo.AllFoldersBySubModule(x.ToString());

                        //FavoriteTags = repo.FindFavoriteTagsByUserAndSubModule(Session.User.Login, (Domain.SubModuleType)x);
                        break;
                    case Domain.SubModuleType.Everyday:
                    case Domain.SubModuleType.Promotions:
                    case Domain.SubModuleType.Kits:
                        FavoritePricingTags = repo.AllFoldersBySubModule(x.ToString());
                        //FavoritePricingTags = repo.FindFavoriteTagsByUserAndSubModule(Session.User.Login, (Domain.SubModuleType)x);
                        break;
                }
            });


            LoadFolderSetCommand.ExecuteAsync().Subscribe(x =>
            {
                Console.WriteLine("test");

            });
            ;
            //LoadFavoritesBySubModuleCommand.Execute(Domain.SubModuleType.Analytics);
            //LoadFavoritesBySubModuleCommand.Execute(Domain.SubModuleType.Everyday);
            //LoadTagsBySubModuleCommand.Execute(Domain.SubModuleType.Analytics);
            //LoadTagsBySubModuleCommand.Execute(Domain.SubModuleType.Everyday);

            EventManager.GetEvent<Domain.SubModuleType>()
                .Subscribe(submodule =>
                {
                    SelectedSubModule = submodule;
                    
                    switch (submodule)
                    {
                        case SubModuleType.Analytics:
                            SelectedSubModuleIndex = 0;
                            if (FolderSet != null)
                            {
                                SelectedFavTags = FolderSet.SelectedAnalyticFolders; //TODO: move to main
                                Tags = FolderSet.MasterAnalyticFolderList;
                            }
                            //Tags = AnalyticTags.Union(SelectedFavTags).ToList();
                            //if(FavoriteTags == null)
                            //{
                            //LoadFavoritesBySubModuleCommand.ExecuteAsync(submodule).Subscribe( x => {
                            //    SelectedFavTags = FavoriteTags;
                            //    Tags = AnalyticTags.Union(SelectedFavTags).ToList();
                            //});
                            
                            //}
                            //if(Analytics == null)
                            //    { LoadTagsBySubModuleCommand.Execute(submodule); }

                            ToggleResults("All");
                            break;
                        case SubModuleType.Everyday:
                            if(FolderSet != null)
                            {
                                SelectedFavTags = FolderSet.SelectedEverydayFolders;
                                Tags = FolderSet.MasterEverydayFolderList;
                            }
                            SelectedSubModuleIndex = 1;
                            ToggleResults("All");
                            break;
                        case SubModuleType.Promotions:
                            if (FolderSet != null)
                            {
                                SelectedFavTags = FolderSet.SelectedPromotionFolders;
                                Tags = FolderSet.MasterPromotionFolderList;
                            }
                            SelectedSubModuleIndex = 2;
                            ToggleResults("All");
                            break;
                        case SubModuleType.Kits:
                            if (FolderSet != null)
                            {
                                SelectedFavTags = FolderSet.SelectedKitFolders;
                                Tags = FolderSet.MasterKitFolderList;
                            }
                            SelectedSubModuleIndex = 3;
                            //Tags = AnalyticTags.Union(SelectedFavTags).ToList();
                            //LoadFavoritesBySubModuleCommand.ExecuteAsync(submodule).Subscribe( x => {
                            //    SelectedFavTags = FavoritePricingTags;
                            //    Tags = PricingTags.Union(SelectedFavTags).ToList();
                            //});
                            //if(PriceRoutines == null)
                            //    { LoadTagsBySubModuleCommand.Execute(submodule); }
                            

                            ToggleResults("All");
                            break;
                        case SubModuleType.MySettings:
                            break;
                        case SubModuleType.Search:
                            break;
                        default:
                            break;
                    }
                });


            

            LoadAnalyticsByTagCommand = ReactiveCommand.CreateAsyncTask( async evt =>
                await Task.Run( () =>
                {
                    var list = ((Events.TagSearchEvent) evt).Tags.Select(y => y.Value).ToList();
                     Analytics = repo.FindAnalyticsByTag(list);


                }));
                //Analytics = repo.FindByTag<Domain.Analytic>(new List<string> { ((Domain.Tag)x).Value });

            //loadAnalyticsByTagCommand.ToProperty(this, x => x.Analytics);

            //LoadAnalyticsByTagCommand = ReactiveCommand.Create();
            //LoadAnalyticsByTagCommand.Subscribe(x => 
            //{
            //    var list = ((Events.TagSearchEvent)x).Tags.Select(y => y.Value).ToList();
            //    //Analytics = repo.FindByTag<Domain.Analytic>(new List<string> { ((Domain.Tag)x).Value });
            //    Analytics = repo.FindAnalyticsByTag(list);
            //});


            LoadPricingByTagCommand = ReactiveCommand.CreateAsyncTask( async evt => 
                await Task.Run( () => {
                    var list = ((Events.TagSearchEvent) evt).Tags.Select(y => y.Value).ToList();
                    PriceRoutines = repo.FindPricingByTag(list);
            }));
            //LoadPricingByTagCommand.Subscribe(x =>
            //{
            //    var list = ((Events.TagSearchEvent)x).Tags.Select(y => y.Value).ToList();
            //    PriceRoutines = repo.FindPricingByTag(list);
            //});

            EventManager.GetEvent<ViewModels.Events.TagSearchEvent>().Subscribe(async evt =>
            {

                switch (evt.SubModule)
                {
                    case Domain.SubModuleType.Analytics:
                        ToggleResults("Analytics");
                        await LoadAnalyticsByTagCommand.ExecuteAsync(evt);
                        break;
                    case Domain.SubModuleType.Everyday:
                    case Domain.SubModuleType.Promotions:
                    case Domain.SubModuleType.Kits:
                        ToggleResults("Pricing");
                        await LoadPricingByTagCommand.ExecuteAsync(evt);
                        break;
                    case Domain.SubModuleType.MySettings:
                        break;
                    case Domain.SubModuleType.Search:
                        break;
                    default:
                        break;
                }
            });

            //watch for changed selected analytic & populate selectedAnalytic prop on this vm to capture state
            EventManager.GetEvent<SelectionEvent>().Subscribe(selection =>
            {
                switch (selection.EntityType)
                {
                    case SubModuleType.Analytics:
                        SelectedAnalytic = selection.Entity as Domain.Analytic;
                        //IsDetailDisplayed = Visibility.Hidden;this.RaisePropertyChanged("IsDetailDisplayed");
                        //IsDetailDisplayed = Visibility.Visible; this.RaisePropertyChanged("IsDetailDisplayed");
                        IsActionBarOn = Visibility.Visible;
                        break;
                    case SubModuleType.Everyday:
                    case SubModuleType.Promotions:
                    case SubModuleType.Kits:
                        //IsPDetailDisplayed = Visibility.Hidden;this.RaisePropertyChanged("IsPDetailDisplayed");
                        //IsPDetailDisplayed = Visibility.Visible; this.RaisePropertyChanged("IsPDetailDisplayed");

                        SelectedPriceRoutine = selection.Entity as Domain.PriceRoutine;
                        break;
                    case SubModuleType.MySettings:
                        break;
                    case SubModuleType.Search:
                        break;
                    default:
                        break;
                }
            });
        }


        public void LoadFolders(SubModuleType submodule)
        {
            switch (submodule)
            {
                case SubModuleType.Analytics:

                    SelectedFavTags = FolderSet.SelectedAnalyticFolders;
                    Tags = FolderSet.MasterAnalyticFolderList;
                    //Tags = AnalyticTags.Union(SelectedFavTags).ToList();
                    //if(FavoriteTags == null)
                    //{
                    //LoadFavoritesBySubModuleCommand.ExecuteAsync(submodule).Subscribe( x => {
                    //    SelectedFavTags = FavoriteTags;
                    //    Tags = AnalyticTags.Union(SelectedFavTags).ToList();
                    //});

                    //}
                    if (Analytics == null)
                    { LoadTagsBySubModuleCommand.Execute(submodule); }

                    ToggleResults("All");
                    break;
                case SubModuleType.Everyday:
                case SubModuleType.Promotions:
                case SubModuleType.Kits:
                    SelectedFavTags = FolderSet.SelectedEverydayFolders;
                    Tags = FolderSet.MasterEverydayFolderList;
                    //Tags = AnalyticTags.Union(SelectedFavTags).ToList();
                    //LoadFavoritesBySubModuleCommand.ExecuteAsync(submodule).Subscribe( x => {
                    //    SelectedFavTags = FavoritePricingTags;
                    //    Tags = PricingTags.Union(SelectedFavTags).ToList();
                    //});
                    if (PriceRoutines == null)
                    { LoadTagsBySubModuleCommand.Execute(submodule); }


                    ToggleResults("All");
                    break;
                case SubModuleType.MySettings:
                    break;
                case SubModuleType.Search:
                    break;
                default:
                    break;
            }
        }
        private FolderSet _FolderSet;
        public FolderSet FolderSet { get { return _FolderSet; } set { this.RaiseAndSetIfChanged(ref _FolderSet, value); } }

        private List<string> _favoritePricingTags;
        public List<string> FavoritePricingTags
        {
            get
            {
                return _favoritePricingTags;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _favoritePricingTags, value.ToList());
            }
        }
        private List<string> _pricingTags;
        public List<string> PricingTags
        {
            get
            {
                return _pricingTags;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _pricingTags, value.ToList());
            }
        }

        private List<string> _analyticTags;
        public List<string> AnalyticTags
        {
            get
            {
                return _analyticTags;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _analyticTags, value.ToList());
            }
        }

        private List<string> _selectedFavTags;
        public List<string> SelectedFavTags
        {
            get
            {
                return _selectedFavTags;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedFavTags, value.ToList());
            }
        }

        private List<string> _favoriteTags;
        public List<string> FavoriteTags
        {
            get
            {
                return _favoriteTags;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _favoriteTags, value.ToList());
            }
        }
        private List<string> _tags;
        public List<string> Tags 
        { 
            get 
            {
                return _tags;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _tags, value.ToList()); 
            }            
        }
        private Domain.Analytic _SelectedAnalytic;
        public Domain.Analytic SelectedAnalytic
        {
            get
            {
                return _SelectedAnalytic;
            }

            set
            {
                this.RaiseAndSetIfChanged(ref _SelectedAnalytic, value);
            }
        }

        private Domain.PriceRoutine _SelectedPriceRoutine;
        public Domain.PriceRoutine SelectedPriceRoutine
        {
            get
            {
                return _SelectedPriceRoutine;
            }

            set
            {
                this.RaiseAndSetIfChanged(ref _SelectedPriceRoutine, value);
            }
        }

        private List<Domain.Analytic> _analytics;
        public List<Domain.Analytic> Analytics
        {
            get
            {
                return _analytics;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _analytics, value);
            }
        }


        private List<Domain.PriceRoutine> _PriceRoutines;
        public List<Domain.PriceRoutine> PriceRoutines
        {
            get
            {
                return _PriceRoutines;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _PriceRoutines, value);
            }
        }
        public Reactive.EventAggregator EventManager { get; set; }
        public List<Domain.SubModuleType> SubModuleKeys { get; set; }

        private Domain.SubModuleType _selectedSubModule = Domain.SubModuleType.Search;
        public Domain.SubModuleType SelectedSubModule { get { return _selectedSubModule; } set {this.RaiseAndSetIfChanged(ref _selectedSubModule,value); } }

        private int _selectedSubModuleIndex = 100;
        public int SelectedSubModuleIndex { get { return _selectedSubModuleIndex; } set { this.RaiseAndSetIfChanged(ref _selectedSubModuleIndex, value); } }



        public List<String> SelectedTagItems { get; set; }

        private System.Windows.Visibility _IsTagsDisplayed = System.Windows.Visibility.Hidden;
        public System.Windows.Visibility IsTagsDisplayed 
        {
            get { return _IsTagsDisplayed; }
            set { this.RaiseAndSetIfChanged(ref _IsTagsDisplayed, value); }
        }

        public void ToggleSearchPane(Domain.SubModuleType type) //TODO: only tags needed
        {
            switch (type)
            {
                case SubModuleType.Analytics:

                    break;
                case SubModuleType.Everyday:
                case SubModuleType.Promotions:
                case SubModuleType.Kits:
                    break;
                case SubModuleType.MySettings:
                    break;
                case SubModuleType.Search:
                    IsTagsDisplayed = System.Windows.Visibility.Visible;
                    switch (SelectedSubModule)
	                {
                        case SubModuleType.Analytics:
                            //IsFiltersDisplayed = Visibility.Visible;
                            //IsFiltersPDisplayed = Visibility.Collapsed;
                            IsTagsDisplayed = Visibility.Visible;
                            //IsPDetailDisplayed = Visibility.Collapsed;this.RaisePropertyChanged("IsPDetailDisplayed");
                            //IsDetailDisplayed = Visibility.Visible;
                            //IsProgressBarAOn = Visibility.Hidden;
                            //IsProgressBarPOn = Visibility.Hidden;
                            break;
                        case SubModuleType.Everyday:
                        case SubModuleType.Promotions:
                        case SubModuleType.Kits:
                            //IsFiltersDisplayed = Visibility.Collapsed;
                            //IsFiltersPDisplayed = Visibility.Visible;
                            IsTagsDisplayed = Visibility.Visible;
                            //IsDetailDisplayed = Visibility.Collapsed;
                            //IsPDetailDisplayed = Visibility.Visible;
                            //IsProgressBarAOn = Visibility.Hidden;
                            //IsProgressBarPOn = Visibility.Hidden;
                            break;
                        
                        default:
                            //IsFiltersDisplayed = Visibility.Collapsed;
                            //IsFiltersPDisplayed = Visibility.Collapsed;   
                            IsTagsDisplayed = Visibility.Collapsed;
                            //IsDetailDisplayed = Visibility.Collapsed;
                            //IsPDetailDisplayed = Visibility.Collapsed;
                            //IsProgressBarAOn = Visibility.Collapsed;
                            //IsProgressBarPOn = Visibility.Collapsed;
                            break;
	                }
                    
                    break;
                default:
                    break;
            }
            //if (on)
            //{
            //    IsFiltersDisplayed = System.Windows.Visibility.Visible ;
            //    IsDetailDisplayed = System.Windows.Visibility.Visible;
            //    IsTagsDisplayed = System.Windows.Visibility.Visible;
            //}
            //else
            //{
            //    IsFiltersDisplayed = System.Windows.Visibility.Hidden;
            //    IsDetailDisplayed = System.Windows.Visibility.Collapsed;
            //    IsPDetailDisplayed = System.Windows.Visibility.Collapsed;
              
            //    IsTagsDisplayed = System.Windows.Visibility.Hidden;
            //}
        }

        public void ToggleResults(string type)
        {
            if (type == "Pricing") { IsFiltersDisplayed = Visibility.Collapsed; IsFiltersPDisplayed = Visibility.Visible; IsDetailDisplayed = Visibility.Collapsed; IsPDetailDisplayed = Visibility.Collapsed; IsActionBarOn = Visibility.Collapsed; }
            else if (type == "Analytics") { IsFiltersDisplayed = Visibility.Visible; IsFiltersPDisplayed = Visibility.Collapsed; IsDetailDisplayed = Visibility.Collapsed; IsPDetailDisplayed = Visibility.Collapsed; IsActionBarOn = Visibility.Collapsed; }
            else if (type == "All") { 
                IsFiltersDisplayed = Visibility.Collapsed; IsFiltersPDisplayed = Visibility.Collapsed; 
                IsDetailDisplayed = Visibility.Collapsed; IsPDetailDisplayed = Visibility.Collapsed; 
                IsActionBarOn = Visibility.Collapsed; 
                
            }
            
        }

        private System.Windows.Visibility _IsFiltersDisplayed = System.Windows.Visibility.Collapsed;
        public System.Windows.Visibility IsFiltersDisplayed
        {
            get { return _IsFiltersDisplayed; }
            set { this.RaiseAndSetIfChanged(ref _IsFiltersDisplayed, value); }
        }

        private System.Windows.Visibility _IsFiltersPDisplayed = System.Windows.Visibility.Collapsed;
        public System.Windows.Visibility IsFiltersPDisplayed
        {
            get { return _IsFiltersPDisplayed; }
            set { this.RaiseAndSetIfChanged(ref _IsFiltersPDisplayed, value); }
        }

        private System.Windows.Visibility _IsDetailDisplayed = System.Windows.Visibility.Collapsed;
        public System.Windows.Visibility IsDetailDisplayed
        {
            get { return _IsDetailDisplayed; }
            set { this.RaiseAndSetIfChanged(ref _IsDetailDisplayed, value); }
        }
        private System.Windows.Visibility _IsPDetailDisplayed = System.Windows.Visibility.Collapsed;
        public System.Windows.Visibility IsPDetailDisplayed
        {
            get { return _IsPDetailDisplayed; }
            set { this.RaiseAndSetIfChanged(ref _IsPDetailDisplayed, value); }
        }

        private System.Windows.Visibility _IsActionBarOn = System.Windows.Visibility.Collapsed;
        public System.Windows.Visibility IsActionBarOn
        {
            get { return _IsActionBarOn; }
            set { this.RaiseAndSetIfChanged(ref _IsActionBarOn, value); }
        }

        private System.Windows.Visibility _IsProgressBarAOn = System.Windows.Visibility.Collapsed;
        public System.Windows.Visibility IsProgressBarAOn
        {
            get { return _IsProgressBarAOn; }
            set { this.RaiseAndSetIfChanged(ref _IsProgressBarAOn, value); }
        }

        private System.Windows.Visibility _IsProgressBarPOn = System.Windows.Visibility.Collapsed;
        public System.Windows.Visibility IsProgressBarPOn
        {
            get { return _IsProgressBarAOn; }
            set { this.RaiseAndSetIfChanged(ref _IsProgressBarAOn, value); }
        }
        protected ReactiveCommand<object> LoadTagsBySubModuleCommand;
        protected ReactiveCommand<System.Reactive.Unit> LoadAnalyticsByTagCommand;
        //protected ReactiveCommand<object> LoadAnalyticsByTagCommand;
        protected ReactiveCommand<System.Reactive.Unit> LoadPricingByTagCommand;
        protected ReactiveCommand<object> LoadFavoritesBySubModuleCommand;
        protected ReactiveCommand<System.Reactive.Unit> LoadFolderSetCommand;





        public Data.ISearchRepository SearchRepository { get; set; }
        public Domain.Session Session { get; set; }

        //public Navigator Navigator { get; set; } //TODO: needs to be handled globally on mainviewmodel but can be passed as ref

        //public AnalyticViewModel SelectedAnalyticViewModel { get; set; }
        //public PricingViewModel SelectedPricingViewModel { get; set; }




    }




  





}


//TODO: Navigate using an action - must map to a viewmodel & populate recent activity?
//namespace Layout.Domain
//{

//    public class Folder
//    {
//        public string Name { get; set; }
//    }

//    public enum Module
//    {
//        Planning,
//        Tracking,
//        Reporting
//    }

//    public enum Sections
//    {
//        Analytics,
//        Everyday,
//        Promotions,
//        Kits,
//        MySettings,
//        Settings,
//        Rules,
//        PriceLists,

//    }

//    public enum AnalyticStepType
//    {
//        Identity,
//        Filters,
//        PriceLists,
//        ValueDrivers
//    }



//    public enum PricingStepType
//    {
//        Identity,
//        Filters,
//        PriceLists,
//        Rounding,
//        Strategy,
//        Results,
//        Forecasts,
//        Approval
//    }

//    public enum PricingType
//    {
//        Everyday,
//        Promotion,
//        Kits
//    }
//    public class Session
//    {
//        public User User { get; set; }        
//        public List<Analytic> Analytics { get; set; }
//        public List<PriceRoutine> PriceRoutines { get; set; }
//        public List<Tag> Tags { get; set; }


//    }

//    public class User
//    {
//        public string Login { get; set; }
//        public string FirstName { get; set; }
//        public string LastName { get; set; }
//        public Boolean IsAuthenticated { get; set; }
//        public Dictionary<Action, ViewModelBase> RecentHistory { get; set; }
//        //public List<Folder> Folders { get; set; } // Deprecated for tags defined on analytic
//        public class Role
//        {
//            List<Action> Permissions { get; set; } //which actions can they execute
//        }

//    }

//    public class Analytic
//    {
//        public string Id { get; set; }
//        public string Name { get; set; }
//        public string Status { get; set; }
//        public string Description { get; set; }
//        public string Comments { get; set; }
//        public string Group1 { get; set; }
//        public string Group2 { get; set; }
//        public string Folder { get; set; }
//        public bool Shared { get; set; }

//        public List<Filter> Filters { get; set; }
//        public List<ValueDriver> ValueDrivers { get; set; }
//        public List<PriceRoutine> RelatedPriceRoutines { get; set; }
//        public List<Action> Actions { get; set; } // TODO: seperate into own logic // usually navigates to step in module eg - for analytic->filters, price lists, rounding
//    }

//    public class PriceRoutine
//    {
//        public PriceRoutineType @Type { get; set; } //everyday, promo, kits
//        public List<string> AssignedAnalytics { get; set; } // list of ids
//        public List<Action> Actions { get; set; }
//        public List<RoundingScheme> RoundingSchemes { get; set; }
//        public List<PriceList> PriceLists { get; set; }
//    }


//    public class PriceList
//    {
        
//    }

//    public enum PricingMode
//    {
//        Single,
//        Cascade,
//        GlobalKey,
//        GlobalKeyPlus
//    }


//    public class RoundingScheme
//    {
//        public string Lower { get; set; }
//        public string Upper { get; set; }
//        public int RoundTo { get; set; }
//    }


//    public enum PriceRoutineType
//    {
//        EveryDay,
//        Promo,
//        Kit
//    }

//    public enum ModuleType
//    {
//        Planning,
//        Tracking,
//        Reporting,
//        Administration
//    }


//    public class ValueDriver
//    {
//        public int Group { get; set; }
//        public ValueDriverType @Type { get; set; }
//    }

//    public enum ValueDriverType
//    {
        
//    }

//    public class Filter
//    {
//        public int Id { get; set; }
//        public Boolean IsSelected { get; set; }
//        public string Code { get; set; }
//        public string Value { get; set; }
//    }

//    public class EntityBase
//    {

//    }
//}



                