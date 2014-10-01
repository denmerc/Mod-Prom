using Layout.Data;
using Domain;

namespace Layout.ViewModels
{

    //Planning sections

    public class PricingModuleViewModel : ViewModelBase
    {
        /**
         * SelectedPriceRoutine - contains selected filters, pricelists, valuedrivers
         * SelectedPricingStepType - enum
         * SelectedStepViewModel to bind to content control
         * 
         * */
        public PricingModuleViewModel(IPricingRepository pricingRepo, Session session)
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
}
