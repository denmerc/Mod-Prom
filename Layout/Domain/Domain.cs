using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Domain
{


        public class Actions
        {
            [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
            public string Id { get; set; }
            public string Key { get; set; }
            public List<Action> Items{ get; set; }
        }

        public class Action
        {
            [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
            public string Id { get; set; }
            public int SortId { get; set; }
            public string Command { get; set; }
            public string CommandType { get; set; }
            public DisplayText DisplayText { get; set; }
            public List<string> Ancestors { get; set; }
            public List<string> Roles { get; set; }
            public Boolean IsEnabled { get; set; }
            public List<string> Parameters { get; set; }
        }

        public class DisplayText
        {
            public string Caption { get; set; }
            public string Header { get; set; }
            public string Tooltip { get; set; }
        }
        public class Tag
        {
            //[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
            //public string Id { get; set; }
            //public string Code { get; set; }
            //public string Description { get; set; }
            public string Value { get; set; }
            
        }

        public class Folder
        {
            public string Name { get; set; }
        }

        //public enum Module
        //{
        //    Planning,
        //    Tracking,
        //    Reporting,
        //    Administration
        //}

        public enum SubModuleType
        {
            
            Analytics,
            Everyday,
            Promotions,
            Kits,
            MySettings,
                Search
        }

        public enum SectionType
        {
            #region Common view types...

            #endregion

            [EnumMember]
            StartupLoginInitialization = 110, // Step 1) Initialization
            [EnumMember]
            StartupLoginAuthentication = 115, // Step 2) Authentication
            [EnumMember]
            StartupLoginChangePassword = 119, // Step 3) Change Password

            [EnumMember]
            PlanningHomeMyHomePage = 111, // Step 1) My Home Page
            [EnumMember]
            PlanningHomeMyOptimization = 177, // Step 2) My Optimization
            [EnumMember]
            PlanningHomeMyMarkuprules = 178, // Step 3) My Markup rules
            [EnumMember]
            PlanningHomeMyRoundingrules = 179, // Step 4) My Rounding rules

            [EnumMember]
            PlanningAnalyticsMyAnalytics = 112, // Step 1) My Analytics
            [EnumMember]
            PlanningAnalyticsIdentity = 116, // Step 2) Identity
            [EnumMember]
            PlanningAnalyticsFilters = 120, // Step 3) Filters
            [EnumMember]
            PlanningAnalyticsPriceLists = 123, // Step 4) Price Lists
            [EnumMember]
            PlanningAnalyticsValueDrivers = 126, // Step 5) Value Drivers
            [EnumMember]
            PlanningAnalyticsResults = 129, // Step 6) Results

            [EnumMember]
            PlanningPricingMyPricing = 113, // Step 1) My Pricing
            [EnumMember]
            PlanningPricingIdentity = 117, // Step 2) Identity
            [EnumMember]
            PlanningPricingFilters = 121, // Step 3) Filters
            [EnumMember]
            PlanningPricingPriceLists = 124, // Step 4) Price Lists
            [EnumMember]
            PlanningPricingRounding = 127, // Step 5) Rounding
            [EnumMember]
            PlanningPricingStrategy = 130, // Step 6) Strategy
            [EnumMember]
            PlanningPricingResults = 132, // Step 7) Results
            [EnumMember]
            PlanningPricingForecast = 134, // Step 8) Forecast
            [EnumMember]
            PlanningPricingApproval = 135, // Step 9) Approval

            [EnumMember]
            PlanningAdministrationUserMaintenance = 114, // Step 1) User Maintenance
            [EnumMember]
            PlanningAdministrationPricelists = 118, // Step 2) Price lists
            [EnumMember]
            PlanningAdministrationOptimization = 128, // Step 3) Optimization
            [EnumMember]
            PlanningAdministrationMarkuprules = 122, // Step 4) Markup rules
            [EnumMember]
            PlanningAdministrationRoundingrules = 125, // Step 5) Rounding rules
            [EnumMember]
            PlanningAdministrationRollback = 133, // Step 6) Rollback
            [EnumMember]
            PlanningAdministrationProcesses = 131, // Step 7) Processes
        }


        public enum AnalyticStepType
        {
            Identity,
            Filters,
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
            public List<Analytic> Analytics { get; set; } // TODO: last three?
            public List<PriceRoutine> PriceRoutines { get; set; }
            public List<string> Tags { get; set; }



        }

        public class User
        {
            public string Login { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public List<Role> Roles { get; set; }
            public Boolean IsAuthenticated { get; set; }

            public List<string> FavoriteTags { get; set; }
            //public List<Analytic> RecentAnalytics { get; set; }
            //public List<PriceRoutine> RecentPriceRoutines { get; set; }
            
            //public Dictionary<Action, EntityBase> RecentHistory { get; set; } //instead of ViewModelBase
            //public List<PriceRoutine> Folders { get; set; }
            //public class Role
            //{
            //    List<Action> Permissions { get; set; } //which actions can they execute
            //}

        }

        public enum Role
        {
            PricingAnalyst,
            Administrator,
            Reviewer
        }
        //[BsonKnownTypes(typeof(Filter))]
        public class Analytic : ReactiveUI.ReactiveObject //TODO: ReactiveValidatedEntity
        {
            [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
            public string Id { get; set; }
            
            public string Name { get; set; }
            
            public string Status { get; set; }
            
            public string Description { get; set; }
            public DateTime LastUpdated { get; set; }
            public string LastUserUpdated { get; set; }
            public string Comments { get; set; }
            //public string Group1 { get; set; }
            //public string Group2 { get; set; }
            //public string Folder { get; set; }
            public List<string> Tags { get; set; }
            public List<string> FavoriteTags { get; set; }
            //public IList<string> Drivers { get; set; }
            public bool Shared { get; set; }
            public List<FilterSet> Filters { get; set; }
            [BsonElement("Drivers")]
            public List<ValueDriver> Drivers { get; set; }
            public List<PriceScheme> PriceSchemes { get; set; }
            //public List<PriceRoutine> RelatedPriceRoutinesIdentities { get; set; }
            //public List<Action> Actions { get; set; } // usually navigates to step in module eg - for analytic->filters, price lists, rounding
        }

        public class PriceRoutine
        {
            public PriceRoutineType @Type { get; set; } //everyday, promo, kits
            public List<string> AssignedAnalytics { get; set; }
            public List<Action> Actions { get; set; }
            public List<RoundingScheme> RoundingSchemes { get; set; }
            public List<PriceList> PriceLists { get; set; }
        }

        public class PriceScheme
        {
            public PricingMode PricingMode { get; set; }
            public List<PriceList> PriceLists { get; set; }
        }


        public enum PriceListType
        {
            Cost,
            Sales,

        }

        public class PriceList
        {
            public int SortId { get; set; }
            public string Type { get; set; }
            public string Code { get; set; }
            public string Description { get; set; }
            public Boolean IsKey { get; set; }
        }

        public enum PricingMode
        {
            Single,
            Cascade,
            Global,
            GlobalPlus
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

        public enum ValueDriverType
        {
            Movement,
            Markup,
            DaysOnHand,
            DaysLeadTime,
            InStockRatio,
            SalesTrendRatio
        }

        public class ValueDriver
        {
            public ValueDriverType @Type { get; set; }
            public Mode Mode { get; set;}
            public List<Group> Groups { get; set; }
            
        }

        public enum Mode
	    {
	        Auto,
            Manual
	    }

        public class Group
        {
            public int LineItemId { get; set; }
            public string GroupName { get; set; }
            public int SkuCount { get; set; }
            public int Min { get; set; }
            public int Max { get; set; }
            public double SalesValue { get; set; }
        }


        public enum FilterType
        {
            VendorCode,
            IsKit,
            OnSale,
            Category,
            DiscountType,
            StatusType,
            ProductType,
            StockClass
        }

        

        public class Filter
        {
            [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
            public string Id { get; set; }
            //public Boolean IsSelected { get; set; } //TODO: should be in viewmodel
            [BsonElement("code")]
            public string Code { get; set; }
            [BsonElement("description")]
            public string Description { get; set; }
            public FilterType Type { get; set; }
        }

        public class FilterSet
        {
            public string Type { get; set; }
            public List<Filter> Items { get; set; }
        }

        public class EntityBase
        {
            
        }
    
}
