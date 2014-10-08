using System;
using System.Collections.Generic;
using ReactiveUI;
using APLPX.UI.WPF.ViewModels.Events;
using APLPX.UI.WPF.Data;
using Domain;
using System.Windows;
using System.Linq;


namespace APLPX.UI.WPF.ViewModels
{
    public class PricingModuleViewModel : ViewModelBase
    {
        /**
         * SelectedPriceRoutine - contains selected filters, pricelists, valuedrivers
         * SelectedPricingStepType - enum
         * SelectedStepViewModel to bind to content control
         * 
         * */
        APLPX.UI.WPF.ViewModels.Reactive.EventAggregator EventManager = ((APLPX.UI.WPF.ViewModels.Reactive.EventAggregator)App.Current.Resources["EventManager"]);
        private Dictionary<Domain.SectionType, ViewModelBase> StepCache = new Dictionary<SectionType, ViewModelBase>();
        public PricingModuleViewModel(IPricingRepository pricingRepo, Session session, string name)
        {
            Name = name;

            EventManager.GetEvent<SaveEvent>()
                .Subscribe(evt =>
                {
                    Domain.PriceRoutine pricingToSave = null;
                    //ViewModelBase vm = null;
                    switch (evt.Section)
                    {
                        case SectionType.PlanningPricingIdentity:
                            var vmi = (ViewModels.Pricing.IdentityViewModel)(SelectedStepViewModel);
                            var tagsToSave = vmi.SelectedTags;
                            pricingToSave = vmi.SelectedPriceRoutine;
                            vmi.SelectedPriceRoutine.Tags = tagsToSave.Select(y => y.Value).ToList<string>();
                            pricingRepo.Save<Domain.PriceRoutine>(pricingToSave);
                            this.Navigate(new NavigateEvent
                            {
                                Module = Domain.ModuleType.Planning,
                                SubModule = SubModuleType.Everyday,
                                Section = SectionType.PlanningPricingFilters
                            }); //TODO: switch by pricingtype evryday, promo, kits
                            break;
                        case SectionType.PlanningAnalyticsFilters:
                            var vmf = (ViewModels.Pricing.FilterViewModel)(SelectedStepViewModel);
                            pricingToSave = vmf.SelectedPriceRoutine;
                            pricingRepo.Save<Domain.PriceRoutine>(pricingToSave);
                            this.Navigate(new NavigateEvent
                            {
                                Module = Domain.ModuleType.Planning,
                                SubModule = SubModuleType.Everyday,
                                Section = SectionType.PlanningPricingPriceLists
                            });
                            break;
                        default:
                            break;
                    }
                });

        }

        private ViewModelBase _SelectedStepViewModel;
        public ViewModelBase SelectedStepViewModel
        {
            get { return _SelectedStepViewModel; }
            set
            {
                this.RaiseAndSetIfChanged(ref _SelectedStepViewModel, value);
            }
        }

        public string Name { get; set; }
        void Save() { }
        public void Navigate(NavigateEvent navigator)
        {

            if (navigator.Entity != null) SelectedPriceRoutine = (Domain.PriceRoutine)navigator.Entity;
            Name = SelectedPriceRoutine.Name;

            if (!StepCache.ContainsKey(navigator.Section))
            {
                switch (navigator.Section)
                {
                    //case SectionType.PlanningPricingMyPricing:
                    //    break;
                    case SectionType.PlanningPricingIdentity:
                        SelectedStepViewModel = new Pricing.IdentityViewModel(SelectedPriceRoutine);
                        break;
                    case SectionType.PlanningPricingFilters:
                        SelectedStepViewModel = new Pricing.FilterViewModel(SelectedPriceRoutine);
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
                StepCache.Add(navigator.Section, _SelectedStepViewModel);
            }
            else //in cache
            {
                switch (navigator.Section)
                {
                    //case SectionType.PlanningPricingMyPricing:
                    //    break;
                    case SectionType.PlanningPricingIdentity:
                        SelectedStepViewModel = ((Pricing.IdentityViewModel)StepCache[navigator.Section]);
                        break;
                    case SectionType.PlanningPricingFilters:
                        SelectedStepViewModel = ((Pricing.FilterViewModel)StepCache[navigator.Section]);
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
                SelectedStepViewModel.LoadPriceRoutine(SelectedPriceRoutine);
            }

        }
    }   
}
