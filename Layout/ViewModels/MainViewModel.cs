using System;
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
        private static Dictionary<Domain.SubModuleType, ViewModelBase> SubModuleCache = new Dictionary<Domain.SubModuleType, ViewModelBase>();
        //private static Dictionary<Domain.SubModuleType, List<ViewModelBase>> SubModuleCacheHistory = new Dictionary<Domain.SubModuleType, List<ViewModelBase>>();

        public MainViewModel()
        {

            //Session = new Session<NullT>()
                //{
                                      //    AppOnline = true,
                //    Authenticated = true,
                //    ClientMessage = "",
                //    Data = null,
                //    ServerMessage = "",
                //    SessionOk = true,
                //    SqlAuthorization = true,
                //    SqlKey = "45f2ae12-1428-481e-8a87-43566914b91a",
                //    WinAuthorization = false,
                //    UserIdentity = new User.Identity()
                //    {
                                          //                                Active = false,
                //        Created = new DateTime(2012, 9, 10, 10, 31, 0),
                //        CreatedText = "Sep 10, 2012",
                //        Edited = new DateTime(0001, 1, 1, 12, 0, 0),
                //        EditedText = "Apr  4 2014  8:50AM",
                //        Editor = "APL Administrator",
                //        Email = "dave.jinkerson@aplpromoter.com",
                //        FirstName = "APL",
                //        Id = 0,
                //        LastLogin = new DateTime(0001, 1, 1, 12, 0, 0),
                //        LastLoginText = "Oct 23 2013  3:46PM",
                //        LastName = "Administrator",
                //        Login = "Administrator",
                //        Name = "APL Administrator",
                //        sqlKey = "45f2ae12-1428-481e-8a87-43566914b91a",
                //        Password = new User.Password() { New = null, Old = "password" },
                //        Role = new User.Role()
                //        {
                //            Description = "APL Master (create all, edit all, view all, delete all, approve all, schedule all, manage users, manage defaults)",
                //            Id = 24,
                //            Name = "APL Administrator",
                //            Planning = new  User.Role.Explorer
                //            {
                //                WorkflowGroup = WorkflowGroupType.Planning,
                //                Workflows = new List<Client.Entity.Workflow>
                //                {
                //                    new Workflow
                //                                                                    {
                //                                    Title = "User login & authentication",
                //                                    Steps = new List<Workflow.Step>()
                //                                    {
                //                                        new Workflow.Step()
                //                                        {
                //                                            Name = "1) Initialization",
                //                                            Caption = "Initialize client application and services",
                //                                            IsActive = false,
                //                                            IsValid = true,
                //                                            Advisors = new List<Workflow.Advisor>()
                //                                            {
                //                                                new Workflow.Advisor()
                //                                                {
                //                                                    Message = "Connect to APL services",
                //                                                    SortId = 1
                //                                                },
                //                                                new Workflow.Advisor()
                //                                                {
                //                                                    Message = "Validate client security",
                //                                                    SortId = 2
                //                                                }
                //                                            },
                //                                            Errors = new List<Workflow.Error>()
                //                                            {
                                
                //                                            }
                //                                        },
                //                                        new Workflow.Step()
                //                                        {
                //                                            Name = "2) Authentication",
                //                                            Caption = "Authenticate user login and password",
                //                                            IsActive = false,
                //                                            IsValid = true,
                //                                            Advisors = new List<Workflow.Advisor>()
                //                                            {
                //                                              new Workflow.Advisor()
                //                                                {
                //                                                    Message = "Connect to APL services",
                //                                                    SortId = 1
                //                                                },
                //                                                new Workflow.Advisor()
                //                                                {
                //                                                    Message = "Validate client security",
                //                                                    SortId = 2
                //                                                }
                //                                            },
                //                                            Errors = new List<Workflow.Error>(){}
                //                                        },
                //                                        new Workflow.Step()
                //                                        {
                //                                            Name = "3) Change Password",
                //                                            Caption = "Change your login password",
                //                                            IsActive = false,
                //                                            IsValid = true,
                //                                            Advisors = new List<Workflow.Advisor>()
                //                                            {
                //                                                new Workflow.Advisor()
                //                                                {
                //                                                    Message = "Connect to APL services",
                //                                                    SortId = 1
                //                                                },
                //                                                new Workflow.Advisor()
                //                                                {
                //                                                    Message = "Validate client security",
                //                                                    SortId = 2
                //                                                }
                //                                            },
                //                                            Errors = new List<Workflow.Error>(){}
                //                                        }
                //                                    }

                //                                }  
                //                },
                //                Navigators = 
                //                {

                //                    new Navigator()
                //                    {
                //                        EntityId = 0,
                //                        WorkflowReadonly = true,
                //                        NodeTitle = "Home page",
                //                        NodeCaption = "Promoter v4 user home page",
                //                        WorkflowGroup = WorkflowGroupType.Planning,
                //                        Workflow =  WorkflowType.PlanningHome,
                //                        WorkflowStep = WorkflowStepType.PlanningHomeMyHomePage,
                //                        Nodes = new List<Navigator>()
                //                        {
                                   
                //                        }
                //                    },
                //                    new Navigator()
                //                    {
                //                        EntityId = 0,
                //                        WorkflowReadonly = true,
                //                        NodeCaption = "Aggregate routines by user explorer view security",
                //                        NodeTitle = "Analytic routines",
                //                        WorkflowGroup = WorkflowGroupType.Planning,
                //                        Workflow =  WorkflowType.PlanningAnalytics,
                //                        WorkflowStep = WorkflowStepType.PlanningAnalyticsMyAnalytics,
                //                        Nodes = new List<Navigator>()
                //                        {
                //                            new Navigator() 
                //                            {
                //                                EntityId = 1,
                //                                WorkflowReadonly = true,
                //                                NodeCaption = "New edited description by admin...\n Refreshed on: Feb  3 2014  7:31PM",
                //                                WorkflowGroup = WorkflowGroupType.Planning,
                //                                Workflow =  WorkflowType.PlanningAnalytics,
            
                //                                WorkflowStep = WorkflowStepType.PlanningAnalyticsIdentity,
                //                                Nodes = new List<Navigator>(){},
                //                            }
                //                        }
                //                    },
                //                    new Navigator()
                //                    {
                //                        EntityId = 0,
                //                        WorkflowReadonly = true,
                //                        NodeCaption = "Price routines by user explorer view security",
                //                        NodeTitle = "Price Routines",
                //                        WorkflowGroup = WorkflowGroupType.Planning,
                //                        Workflow =  WorkflowType.PlanningPricing,
                //                        WorkflowStep = WorkflowStepType.PlanningPricingMyPricing,
                //                        Nodes = new List<Navigator>(){}
                //                    },
                //                    new Navigator()
                //                    {
                //                        EntityId = 0,
                //                        WorkflowReadonly = true,
                //                        NodeCaption = "Administration by user explorer view security",
                //                        NodeTitle = "Administration",
                //                        WorkflowGroup = WorkflowGroupType.Planning,
                //                        Workflow =  WorkflowType.PlanningAdministration,
                //                        WorkflowStep = WorkflowStepType.PlanningAdministrationUserMaintenance,
                //                        Nodes = new List<Navigator>()
                //                        {
                //                            new Navigator() 
                //                            {
                //                                EntityId = 0,
                //                                WorkflowReadonly = true,
                //                                NodeCaption = "Manage users and security",
                //                                NodeTitle = "Users",
                //                                WorkflowGroup = WorkflowGroupType.Planning,
                //                                Workflow =  WorkflowType.PlanningAdministration,
                //                                WorkflowStep = WorkflowStepType.PlanningAdministrationUserMaintenance,
                //                                Nodes = new List<Navigator>(){},
                //                            },
                //                            new Navigator() 
                //                            {
                //                                EntityId = 0,
                //                                WorkflowReadonly = true,
                //                                NodeCaption = "Manage rounding templates",
                //                                Nodes = new List<Navigator>(){},
                //                                NodeTitle = "Rounding",
                //                                WorkflowGroup = WorkflowGroupType.Planning,
                //                                Workflow =  WorkflowType.PlanningAdministration,
                //                                WorkflowStep = WorkflowStepType.PlanningAdministrationUserMaintenance,
                //                            },
                //                            new Navigator() 
                //                            {
                //                                EntityId = 0,
                //                                WorkflowReadonly = true,
                //                                NodeCaption = "Manage price change rollback",
                //                                Nodes = new List<Navigator>(){},
                //                                NodeTitle = "Rounding",
                //                                WorkflowGroup = WorkflowGroupType.Planning,
                //                                Workflow =  WorkflowType.PlanningAdministration,
                //                                WorkflowStep = WorkflowStepType.PlanningAdministrationUserMaintenance,
                //                            }                                
                //                        }
                //                    }
                //             }
                //            }

                //        }


                //    },
                //    Workflow = null

                //};
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
                    switch (navigator.SubModule)
                    {
                        case Domain.SubModuleType.Analytics: //static-singleton SubModuleVM with proxies with sections reloaded
                            //add if it doesnt exist otherwise navigate 
                            if(!SubModuleCache.ContainsKey(navigator.SubModule))
                            {
                                //populate name for header
                                var analytic = (Domain.Analytic)navigator.Entity;

                                SelectedSubModuleViewModel = new AnalyticViewModel(AnalyticRepo, Session, analytic.Name);
                                SubModuleCache.Add(navigator.SubModule, SelectedSubModuleViewModel);
                            }
                            else
                            {
                                SelectedSubModuleViewModel = SubModuleCache[Domain.SubModuleType.Analytics];
                                
                            }
                            //if(navigator.Entity != null)
                               ((AnalyticViewModel)SubModuleCache[navigator.SubModule]).Navigate(navigator);
                            
                            break;
                        case Domain.SubModuleType.Everyday:
                        case Domain.SubModuleType.Promotions:
                        case Domain.SubModuleType.Kits:
                            if (!SubModuleCache.ContainsKey(navigator.SubModule))
                            {
                                SelectedSubModuleViewModel = new PricingViewModel(PricingRepo, Session);
                            }
                            else
                            {
                                ((PricingViewModel)SubModuleCache[navigator.SubModule]).Navigate(navigator.Section);
                            }
                            break;
                        case Domain.SubModuleType.Search:
                            if(!SubModuleCache.ContainsKey(navigator.SubModule))
                            {
                                SelectedSubModuleViewModel = new HomeSearchViewModel(SearchRepo, Session, EventManager); 
                            }
                            else
                            {
                               
                                SelectedSubModuleViewModel = SubModuleCache[Domain.SubModuleType.Search]; this.RaisePropertyChanged("SelectedSubModuleViewModel");
                                ((HomeSearchViewModel)SelectedSubModuleViewModel).ToggleSearchPane(navigator.SubModule);

                            }
                            break;
                        case Domain.SubModuleType.MySettings:
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

        public ViewModels.Navigator Navigator { get; set; }
        public Reactive.EventAggregator EventManager { get; set; }

        public Data.ISearchRepository SearchRepo { get; set; }
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

    namespace Events
    {
        public class NavigateEvent
        {
            public Domain.ModuleType Module { get; set; }
            public Domain.SubModuleType SubModule { get; set; }
            public Domain.SectionType Section { get; set; }
            public Object Entity { get; set; }
        }

        public class SaveEvent
        {
            public Domain.ModuleType Module { get; set; }
            public Domain.SubModuleType SubModule { get; set; }
            public Domain.SectionType Section { get; set; }
            public Object Entity { get; set; }
        }

        public class TagSearchEvent
        {
            public Domain.ModuleType Module { get; set; }
            public Domain.SubModuleType SubModule { get; set; }
            public Domain.SectionType Section { get; set; }
            public List<Domain.Tag> Tags { get; set; }
        }

        public class SelectionEvent
        {
            public Domain.SubModuleType EntityType { get; set; }
            public Object Entity { get; set; }
        }

        public class DriverSelectedEvent
        {
            public Domain.Mode Mode { get; set; }
            public Domain.ValueDriverType DriverType {get; set;}
        }
    }

    namespace Reactive
    {

        public class EventAggregator : IEventAggregator
        {
            readonly ISubject<object> subject = new Subject<object>();

            public IObservable<TEvent> GetEvent<TEvent>()
            {
                return subject.OfType<TEvent>().AsObservable();
            }

            public void Publish<TEvent>(TEvent sampleEvent)
            {
                subject.OnNext(sampleEvent);
            }
        }

        public interface IEventAggregator
        {
            IObservable<TEvent> GetEvent<TEvent>();
            void Publish<TEvent>(TEvent sampleEvent);
        }
    }

    public class Navigator
	{
        //TODO: make this is own class so we can pass it to submodules or use event aggregator

        private static Dictionary<Domain.ModuleType, ViewModelBase> ModuleSearchCache = new Dictionary<Domain.ModuleType,ViewModelBase>();
        private static Dictionary<Domain.SubModuleType, List<ViewModelBase>> SubModuleCache = new Dictionary<Domain.SubModuleType, List<ViewModelBase>>();
        //private string EventAggregatorReceiver { get; set; } //receive navigation events from aggregator
        public ViewModelBase NavigateHomeByModuleType(Domain.ModuleType module) 
        { 
            //find HomeSearch for Planning Landing page only if one exists and reload
            if(ModuleSearchCache.ContainsKey(module))
            {
                return ModuleSearchCache[module];
            }
            return null;
        }
        public ViewModelBase NavigateSectionBySectionType(Domain.SubModuleType section) 
        { 
            //multiple analytic and pricing viewmodels can exist here TODO: determine cap to hold in cache
            if (SubModuleCache.ContainsKey(section))
            {
                var list = SubModuleCache[section];
                while (list.Count > 10)
                {
                    list.RemoveAt(0);  
                }
                return list.Last();
                //TODO: dispose of any eventagg related items
                
                
            }
            return null; //return approp SectionViewModel
        }
        public void AddModule(Domain.ModuleType moduleType, ViewModelBase viewModel)
        {
            
        }

        public void AddNewSection(Domain.SectionType sectionType, ViewModelBase viewModel )
        {
            //only on selection of analytic or price routine -> edit link clicked
        }


	}
    public class PlanningModuleViewModel : ViewModelBase
    {
        /**
         * Tag List By Selected Section by User with animation
         * Analytics by User By Group -or- PriceRoutines By User
         * Default is Home/Search current HomeVertical
         * 
         * 
         * 
         **/

        public PlanningModuleViewModel(Data.ISearchRepository repository, Domain.Session session){

            //load default submoduleVM
            //SelectedSubModule = new HomeSearchViewModel(repository);
        }

    }

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


            LoadTagsBySubModuleCommand = ReactiveCommand.Create();
            LoadTagsBySubModuleCommand.Subscribe(x =>
            {
                switch((Domain.SubModuleType) x)
                {
                    case Domain.SubModuleType.Analytics:
                        AnalyticTags = repo.AllTagsBySubModule(x.ToString());
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
                        FavoriteTags = repo.FindFavoriteTagsByUserAndSubModule(Session.User.Login, (Domain.SubModuleType)x);
                        break;
                    case Domain.SubModuleType.Everyday:
                    case Domain.SubModuleType.Promotions:
                    case Domain.SubModuleType.Kits:
                        FavoritePricingTags = repo.FindFavoriteTagsByUserAndSubModule(Session.User.Login, (Domain.SubModuleType)x);
                        break;
                }
            });


            LoadFavoritesBySubModuleCommand.Execute(Domain.SubModuleType.Analytics);
            LoadFavoritesBySubModuleCommand.Execute(Domain.SubModuleType.Everyday);
            LoadTagsBySubModuleCommand.Execute(Domain.SubModuleType.Analytics);
            LoadTagsBySubModuleCommand.Execute(Domain.SubModuleType.Everyday);

            EventManager.GetEvent<Domain.SubModuleType>()
                .Subscribe(submodule =>
                {
                    SelectedSubModule = submodule;
                    switch (submodule)
                    {
                        case SubModuleType.Analytics:
                            
                            if(FavoriteTags == null)
                                {LoadFavoritesBySubModuleCommand.Execute(submodule);}
                            if(Analytics == null)
                                { LoadTagsBySubModuleCommand.Execute(submodule); }
                            SelectedFavTags = FavoriteTags;
                            Tags = AnalyticTags;
                            ToggleResults("All");
                            break;
                        case SubModuleType.Everyday:
                        case SubModuleType.Promotions:
                        case SubModuleType.Kits:
                            if(FavoritePricingTags == null)
                                {LoadFavoritesBySubModuleCommand.Execute(submodule);}
                            if(PriceRoutines == null)
                                { LoadTagsBySubModuleCommand.Execute(submodule); }
                            SelectedFavTags = FavoritePricingTags;
                            Tags = PricingTags;

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

            LoadAnalyticsByTagCommand = ReactiveCommand.Create();
            LoadAnalyticsByTagCommand.Subscribe(x => 
            {
                var list = ((Events.TagSearchEvent)x).Tags.Select(y => y.Value).ToList();
                //Analytics = repo.FindByTag<Domain.Analytic>(new List<string> { ((Domain.Tag)x).Value });
                Analytics = repo.FindAnalyticsByTag(list);
            });


            LoadPricingByTagCommand = ReactiveCommand.Create();
            LoadPricingByTagCommand.Subscribe(x =>
            {
                var list = ((Events.TagSearchEvent)x).Tags.Select(y => y.Value).ToList();
                PriceRoutines = repo.FindPricingByTag(list);
            });

            EventManager.GetEvent<ViewModels.Events.TagSearchEvent>().Subscribe(evt =>
            {

                switch (evt.SubModule)
                {
                    case Domain.SubModuleType.Analytics:
                        LoadAnalyticsByTagCommand.Execute(evt);
                        ToggleResults("Analytics");
                        break;
                    case Domain.SubModuleType.Everyday:
                    case Domain.SubModuleType.Promotions:
                    case Domain.SubModuleType.Kits:
                        LoadPricingByTagCommand.Execute(evt);
                        ToggleResults("Pricing");
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
        protected ReactiveCommand<object> LoadAnalyticsByTagCommand;
        protected ReactiveCommand<object> LoadPricingByTagCommand;
        protected ReactiveCommand<object> LoadFavoritesBySubModuleCommand;




        public Data.ISearchRepository SearchRepository { get; set; }
        public Domain.Session Session { get; set; }

        public Navigator Navigator { get; set; } //TODO: needs to be handled globally on mainviewmodel but can be passed as ref

        //public AnalyticViewModel SelectedAnalyticViewModel { get; set; }
        //public PricingViewModel SelectedPricingViewModel { get; set; }




    }




    
    public class AdministrationModuleViewModel
    {
        /**
         * User mgmt
         * Global Defaults - PriceLists, Optimizations, Markup Rules, Rounding
         * Global functions, processes, alerts
         * 
         * */
        public AdministrationModuleViewModel()
        {
        
        }

    }


    //Planning sections
    public class AnalyticViewModel : ViewModelBase
    {
        /**
         * SelectedAnalytic - contains selected filters, pricelists, valuedrivers
         * SelectedAnalyticStepType - enum
         * static Dictionary of Steps / vm / selected
         * -OR-
         * List<Steps> and navigated vm's
         * SelectedStepViewModel to bind to content control with analytic state , actions
         * Services needed for analytic 
         * */
        //AnalyticViewModel(Domain.Analytic analytic)
        //{

        //}
        Layout.ViewModels.Reactive.EventAggregator EventManager = ((Layout.ViewModels.Reactive.EventAggregator)App.Current.Resources["EventManager"]);

        private Dictionary<Domain.SectionType, ViewModelBase> StepCache = new Dictionary<SectionType,ViewModelBase>();
        //private static Domain.Analytic SelectedAnalytic { get; set; }

        private ViewModelBase _SelectedStepViewModel;
        public ViewModelBase SelectedStepViewModel
        {
            get { return _SelectedStepViewModel; }
            set 
            {
                this.RaiseAndSetIfChanged(ref _SelectedStepViewModel, value);
            }
        }

        public void Navigate(NavigateEvent navigator)
        {
            if (navigator.Entity != null) SelectedAnalytic = (Domain.Analytic)navigator.Entity;
            Name = SelectedAnalytic.Name;
            
            if(!StepCache.ContainsKey(navigator.Section))
            {
                switch (navigator.Section)// switch action bar for each step
                {
                    //case SectionType.StartupLoginInitialization:
                    //    break;
                    //case SectionType.StartupLoginAuthentication:
                    //    break;
                    //case SectionType.StartupLoginChangePassword:
                    //    break;
                    //case SectionType.PlanningHomeMyHomePage:
                    //    break;
                    //case SectionType.PlanningHomeMyOptimization:
                    //    break;
                    //case SectionType.PlanningHomeMyMarkuprules:
                    //    break;
                    //case SectionType.PlanningHomeMyRoundingrules:
                    //    break;
                    case SectionType.PlanningAnalyticsMyAnalytics:
                        break;
                    case SectionType.PlanningAnalyticsIdentity:
                        SelectedStepViewModel = new ViewModels.Analytic.IdentityViewModel(SelectedAnalytic);
                       
                        break;
                    case SectionType.PlanningAnalyticsFilters:
                        SelectedStepViewModel = new ViewModels.Analytic.FilterViewModel(SelectedAnalytic);
                        break;
                    //case SectionType.PlanningAnalyticsPriceLists:
                    //    break;
                    case SectionType.PlanningAnalyticsValueDrivers:
                        SelectedStepViewModel = new ViewModels.Analytic.DriverViewModel(SelectedAnalytic);
                        break;
                    case SectionType.PlanningAnalyticsResults:
                        SelectedStepViewModel = new ViewModels.Analytic.ResultsViewModel(SelectedAnalytic);
                        break;
                    default:
                        break;

                }
                StepCache.Add(navigator.Section, _SelectedStepViewModel);
            }
                else // in cache
	            {
                    switch (navigator.Section)
	                {
                        case SectionType.PlanningAnalyticsIdentity:
                            SelectedStepViewModel = ((Analytic.IdentityViewModel)StepCache[navigator.Section]);
                            //SelectedStepViewModel.Load(navigator.Entity);
                            break;
                        case SectionType.PlanningAnalyticsFilters:
                            SelectedStepViewModel = ((Analytic.FilterViewModel)StepCache[navigator.Section]);
                            break;
                        case SectionType.PlanningAnalyticsValueDrivers:
                            SelectedStepViewModel = ((Analytic.DriverViewModel)StepCache[navigator.Section]);
                            break;
                        case SectionType.PlanningAnalyticsResults:
                            SelectedStepViewModel = ((Analytic.ResultsViewModel)StepCache[navigator.Section]);
                            break;
		                default:
                            break;
	                }
                    SelectedStepViewModel.Load(SelectedAnalytic);
                    
	            }
        }
        //public AnalyticViewModel()
        //{

        //}
        //public AnalyticViewModel(NavigateEvent navigator)
        //{

        //}
        //public AnalyticViewModel(Domain.Analytic analytic, Domain.SectionType step)
        //{
            
        //}
        public AnalyticViewModel(IAnalyticRepository repo, Session session, string name)
        {
            Name = name;

            EventManager.GetEvent<SaveEvent>()
                .Subscribe(evt =>
                {
                    switch (evt.Section)
                    {
                        case SectionType.PlanningHomeMyMarkuprules:
                            break;
                        case SectionType.PlanningHomeMyRoundingrules:
                            break;
                        case SectionType.PlanningAnalyticsMyAnalytics:
                            break;
                        case SectionType.PlanningAnalyticsIdentity:
                            var vm = (ViewModels.Analytic.IdentityViewModel)(SelectedStepViewModel);
                            var tagsToSave = vm.SelectedTags;
                            var analyticToSave = vm.SelectedAnalytic;
                            vm.SelectedAnalytic.Tags = tagsToSave.Select( y => y.Value).ToList<string>();
                            repo.Save<Domain.Analytic>(analyticToSave);
                            this.Navigate(new NavigateEvent { Module = Domain.ModuleType.Planning, SubModule = SubModuleType.Analytics, Section = SectionType.PlanningAnalyticsFilters });
                            break;
                        case SectionType.PlanningAnalyticsFilters:
                            break;
                        case SectionType.PlanningAnalyticsPriceLists:
                            break;
                        case SectionType.PlanningAnalyticsValueDrivers:
                            break;
                        case SectionType.PlanningAnalyticsResults:
                            break;
                        default:
                            break;
                    }
                });
        }

        public string Name { get; set; }
        void Save(){}
    }

    public class PricingViewModel : ViewModelBase
    {
        /**
         * SelectedPriceRoutine - contains selected filters, pricelists, valuedrivers
         * SelectedPricingStepType - enum
         * SelectedStepViewModel to bind to content control
         * 
         * */
        public PricingViewModel(IPricingRepository pricingRepo, Session session)
        {
        
        }
        //PricingViewModel(Domain.PriceRoutine routine)
        //{

        //}
        public void Navigate(SectionType section)
        {
            switch (section)
	        {
                    //case SectionType.PlanningPricingMyPricing:
                    //    break;
                    case SectionType.PlanningPricingIdentity:
                        //SelectedStepViewModel = new PricingIdentityViewModel();
                        break;
                    case SectionType.PlanningPricingFilters:
                        break;
                    case SectionType.PlanningPricingPriceLists:
                        break;
                    case SectionType.PlanningPricingRounding:
                        break;
                    case SectionType.PlanningPricingStrategy:
                        break;
                    case SectionType.PlanningPricingResults:
                        break;
                    case SectionType.PlanningPricingForecast:
                        break;
                    case SectionType.PlanningPricingApproval:
                        break;
		            default:
                        break;

	        }
        }
    }



    public class AdminViewModel : ViewModelBase
    {

        public  void Navigate(NavigateEvent navigator)
        {
            switch(navigator.Section)
            {

                case SectionType.PlanningAdministrationUserMaintenance:
                    break;
                case SectionType.PlanningAdministrationPricelists:
                    break;
                case SectionType.PlanningAdministrationOptimization:
                    break;
                case SectionType.PlanningAdministrationMarkuprules:
                    break;
                case SectionType.PlanningAdministrationRoundingrules:
                    break;
                case SectionType.PlanningAdministrationRollback:
                    break;
                case SectionType.PlanningAdministrationProcesses:
                    break;
            }
        }

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



                