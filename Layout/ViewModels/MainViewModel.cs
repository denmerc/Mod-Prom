using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Layout;
using Layout.ViewModels;


namespace Layout.ViewModels
{
    public class MainViewModel
    {
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
            Seed();
       }

        public Domain.Session Session { get; set; }
        public ViewModelBase SelectedPlanningViewModel { get; set; }
        public ViewModelBase SelectedTrackingViewModel { get; set; }
        public ViewModelBase SelectedAdminViewModel { get; set; } //preload
        

        //Screen sections
        public string MessageCenterViewModel { get; set; }
        public string StatusCenterViewModel { get; set; }


        //service references

        //Lookup lists?
        public List<Domain.Filter> SampleFilters { get; set; }
        public List<Domain.Folder> SampleFolders { get; set; }



        public void Seed()
        {
            Random r = new Random();

            //Mock lookups
            SampleFilters = new List<Domain.Filter>();
            SampleFolders = new List<Domain.Folder>();

            for (int i = 0; i < 100; i++)
            {
                SampleFilters.Add(new Domain.Filter());
                SampleFolders.Add(new Domain.Folder());
            }
            int j = 0;
            SampleFilters.ForEach(x => x.Id = ++j);
            SampleFilters.ForEach(x => x.Code +=  ++j);

            SampleFilters.ForEach(x => x.IsSelected = r.NextDouble() > 0.5);


            Session = new Layout.Domain.Session
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
                        Group1 = "Group!",
                        Group2 = "Group2",
                        Folder = "Folder1",
                        Filters = SampleFilters.Where(x => x.IsSelected == true).ToList()
                    },
                    new Domain.Analytic()
                    {
                        Id="2",
                        Name="Bed Mats & Tonneau Covers",
                        Description = "All Mats and Covers",
                        Status = "Active"
                        ,Group1 = "Group1",
                        Group2 = "Group2",
                        Folder = "Folder1",
                        Filters = SampleFilters.Where(x => x.IsSelected == false).ToList()
                    },
                    new Domain.Analytic()
                    {
                        Id="3",
                        Name="Books",
                        Description = "All Books",
                        Status = "Active"
                        ,Group1 = "Group@",
                        Group2 = "Group2"
                        ,Folder = "Folder1",
                        Filters = SampleFilters.Skip(r.Next()).Take(r.Next()).ToList()
                    },
                    new Domain.Analytic()
                    {
                        Id="4"
                        ,Name="Brake Systems"
                        ,Description = "All Brake Systems"
                        ,Status = "Active"
                        ,Group1 = "Group$"
                        ,Group2 = "Group2"
                        ,Folder = "Folder1"
                        ,Filters = SampleFilters.Skip(r.Next()).Take(r.Next()).ToList()
                    },
                    new Domain.Analytic()
                    {
                        Id="5",
                        Name="Bumpers & Hardware",
                        Description = "All Bumpers & Hardware",
                        Status = "Active"
                        ,Group1 = "Group$"
                        ,Group2 = "Group2"
                        ,Folder = "Folder1"
                        ,Filters = SampleFilters.Skip(r.Next()).Take(r.Next()).ToList()

                    },
                    new Domain.Analytic()
                    {
                        Id="6"
                        ,Name="Car Care & Paint"
                        ,Description = "All Car Care parts"
                        ,Status = "Active"
                        ,Group1 = "Group$"
                        ,Group2 = "Group2"
                        ,Folder = "Folder1"
                    },
                    new Domain.Analytic()
                    {
                        Id="7",
                        Name="Video & Software",
                        Description = "All Video & Software parts",
                        Status = "Active"
                        ,Group1 = "Group$"
                        ,Group2 = "Group2"
                        ,Folder = "Folder1"
                    },
                    new Domain.Analytic()
                    {
                        Id="8"
                        ,Name="Loyalty Points"                      
                        ,Description = "All Loyalty Points"
                        ,Status = "Active"
                        ,Group1 = "Group$"
                        ,Group2 = "Group2"
                        ,Folder = "Folder1"
                        ,Filters = SampleFilters.Skip(r.Next()).Take(r.Next()).ToList()
                    }
                }
                
            };


            
        }
    }
}


namespace Layout.ViewModels
{
    public class PlanningViewModel
    {
        /**
         * Folder List By Selected Module by User
         * Analytics by User By Group
         * Status
         * Messages
         * Services need for analytic 
         * 
         **/
        public AnalyticViewModel SelectedAnalyticViewModel { get; set; }
        public AnalyticViewModel SelectedPricingViewModel { get; set; }

    }

    //
    public class AdministrationViewModel
    {
        /**
         * User mgmt
         * Global Defaults - PriceLists, Optimizations, Markup Rules, Rounding
         * Global functions, processes, alerts
         * 
         * */
    }


    //Planning sections
    public class AnalyticViewModel
    {
        /**
         * SelectedAnalytic - contains selected filters, pricelists, valuedrivers
         * SelectedAnalyticStepType - enum
         * SelectedStepViewModel to bind to content control
         * 
         * */
        AnalyticViewModel(Domain.Analytic analytic)
        {

        }

        void Save(){}
    }

    public class PricingViewModel
    {
        /**
         * SelectedPriceRoutine - contains selected filters, pricelists, valuedrivers
         * SelectedPricingStepType - enum
         * SelectedStepViewModel to bind to content control
         * 
         * */
        PricingViewModel(Domain.PriceRoutine routine)
        {

        }

    }
}

//TODO: Navigate using an action - must map to a viewmodel & populate recent activity?
namespace Layout.Domain
{
    public class Folder
    {
        public string Name { get; set; }
    }

    public enum Module
    {
        Planning,
        Tracking,
        Reporting
    }

    public enum AnalyticStepType
    {
        Identity,
        Filters,
        PriceLists,
        ValueDrivers
    }

    public enum PricingStepType
    {
        Identity,
        Filters,
        PriceLists,
        Rounding,
        Strategy,
        Results,
        Forecasts,
        Approval
    }

   
    public class Session
    {
        public User User { get; set; }        
        public List<Analytic> Analytics { get; set; }
        public List<PriceRoutine> PriceRoutines { get; set; }
    }

    public class User
    {
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Dictionary<Action, ViewModelBase> RecentHistory { get; set; }
        public List<PriceRoutine> Folders { get; set; }
        public class Role
        {
            List<Action> Permissions { get; set; } //which actions can they execute
        }

    }

    public class Analytic
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
        public string Group1 { get; set; }
        public string Group2 { get; set; }
        public string Folder { get; set; }
        public bool Shared { get; set; }

        public List<Filter> Filters { get; set; }
        public List<ValueDriver> ValueDrivers { get; set; }
        public List<PriceRoutine> RelatedPriceRoutines { get; set; }
        public List<Action> Actions { get; set; } // usually navigates to step in module eg - for analytic->filters, price lists, rounding
    }

    public class PriceRoutine
    {
        public PriceRoutineType @Type { get; set; } //everyday, promo, kits
        public List<Analytic> RelatedAnalytics { get; set; }
        public List<Action> Actions { get; set; }
        public List<RoundingScheme> RoundingSchemes { get; set; }
        public List<PriceList> PriceLists { get; set; }
    }


    public class PriceList
    {
        
    }

    public enum PricingMode
	{
	    Single,
        Cascade,
        GlobalKey,
        GlobalKeyPlus
	}


    public class RoundingScheme
    {
        public string Lower { get; set; }
        public string Upper { get; set; }
        public int RoundTo { get; set; }
    }


    public enum PriceRoutineType
    {
        EveryDay,
        Promo,
        Kit
    }

    public enum ModuleType
    {
        Planning,
        Tracking,
        Reporting,
        Administration
    }


    public class ValueDriver
    {
        public int Group { get; set; }
        public ValueDriverType @Type { get; set; }
    }

    public enum ValueDriverType
    {
        
    }

    public class Filter
    {
        public int Id { get; set; }
        public Boolean IsSelected { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
    }
}



                