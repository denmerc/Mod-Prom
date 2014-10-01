﻿using System;
using System.Collections.Generic;
using ReactiveUI;
using Layout.ViewModels.Events;
using Layout.Data;
using Domain;
using System.Windows;


namespace Layout.ViewModels
{

    public class AdminModuleViewModel : ViewModelBase
    {
        Layout.ViewModels.Reactive.EventAggregator EventManager = ((Layout.ViewModels.Reactive.EventAggregator)App.Current.Resources["EventManager"]);

        private Dictionary<Domain.SectionType, ViewModelBase> SectionCache = new Dictionary<SectionType, ViewModelBase>();
        //private static Domain.Analytic SelectedAnalytic { get; set; }
        private MainViewModel _parent;
        private ISearchRepository _repo;
        public AdminModuleViewModel()
        {

            _repo = MainViewModel.SearchRepo;

            EventManager.GetEvent<SectionSelectionEvent>()
                .Subscribe(evt =>
                {
                    this.Navigate(evt.Section);

                });
            //EventManager.GetEvent<FoldersSelectedVM>()
            //    .Subscribe(vm =>
            //    { 

            //    });

            EventManager.GetEvent<FolderSettingsUpdatedEvent>()
                .Subscribe(evt =>
                {
                    var vm = ((FolderSettingsViewModel)(SelectedSectionViewModel));
                    try
                    {
                        var folderSet = new FolderSet
                        {
                            SelectedAnalyticFolders = vm.AnalyticFolderSet,
                            SelectedEverydayFolders = vm.EverydayFolderSet,
                            SelectedPromotionFolders = vm.PromoFolderSet,
                            SelectedKitFolders = vm.KitFolderSet
                        };
                        _repo.SaveFolders(folderSet);
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                    //if saved update in memory so search screen is updated
                    var mainFolderSet = ((HomeSearchViewModel)MainViewModel.SubModuleCache[Domain.SubModuleType.Search]);

                    mainFolderSet.FolderSet.SelectedAnalyticFolders = vm.AnalyticFolderSet;
                    mainFolderSet.FolderSet.SelectedEverydayFolders = vm.EverydayFolderSet;
                    mainFolderSet.FolderSet.SelectedPromotionFolders = vm.PromoFolderSet;
                    mainFolderSet.FolderSet.SelectedKitFolders = vm.KitFolderSet;

                    EventManager.Publish<NavigateEvent>(
                        new NavigateEvent
                        {
                            Module = Domain.ModuleType.Planning,
                            SubModule = Domain.SubModuleType.Search,
                            Section = Domain.SectionType.PlanningHomeMyHomePage

                        });

                });

        }


        private ViewModelBase _SelectedSectionViewModel;
        public ViewModelBase SelectedSectionViewModel
        {
            get { return _SelectedSectionViewModel; }
            set
            {
                this.RaiseAndSetIfChanged(ref _SelectedSectionViewModel, value);
            }
        }



        public void Navigate(Domain.SectionType section)
        {
            if (!SectionCache.ContainsKey(section))
            {
                switch (section)
                {

                    case SectionType.AdministrationFolders:
                        SelectedSectionViewModel = new FolderSettingsViewModel();
                        break;
                    case SectionType.AdministrationUserMaintenance:

                        break;
                    case SectionType.AdministrationPricelists:
                        break;
                    case SectionType.AdministrationOptimization:
                        break;
                    case SectionType.AdministrationMarkuprules:
                        break;
                    case SectionType.AdministrationRoundingrules:
                        break;
                    case SectionType.AdministrationRollback:
                        break;
                    case SectionType.AdministrationProcesses:
                        break;
                }
                SectionCache.Add(section, SelectedSectionViewModel);
            }
            else //in cache
            {
                switch (section)
                {

                    case SectionType.AdministrationFolders:
                        SelectedSectionViewModel = ((FolderSettingsViewModel)SectionCache[section]);

                        break;
                    case SectionType.AdministrationUserMaintenance:

                        break;
                    case SectionType.AdministrationPricelists:
                        break;
                    case SectionType.AdministrationOptimization:
                        break;
                    case SectionType.AdministrationMarkuprules:
                        break;
                    case SectionType.AdministrationRoundingrules:
                        break;
                    case SectionType.AdministrationRollback:
                        break;
                    case SectionType.AdministrationProcesses:
                        break;
                }
            }
        }

    }
}
