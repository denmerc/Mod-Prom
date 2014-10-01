using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using System.Reactive.Linq;
using System.Reactive;

namespace Layout.ViewModels
{
    public class FolderSettingsViewModel : ViewModelBase
    {
        Layout.ViewModels.Reactive.EventAggregator Publisher = ((Layout.ViewModels.Reactive.EventAggregator)App.Current.Resources["EventManager"]);
        public FolderSettingsViewModel()
        {
            Reload(Domain.SubModuleType.Analytics);
            SubModuleKeys = Enum.GetValues(typeof(Domain.SubModuleType)).Cast<Domain.SubModuleType>().ToList();

            var selectedObservable = this.WhenAnyObservable(x => x.SelectedFolderList.ItemChanged)
                .Where(x => x.PropertyName == "IsSelected")
            //.Select(_ => FilterItems.Any(x => x.IsSelected));

            .Subscribe(x =>
            {
                    switch (SelectedModuleIndex)
	                {
                        case 0:
                            if (x.Sender.IsSelected)
	                        {
                                MasterFolderSet.SelectedAnalyticFolders.Add(x.Sender.Name);      
	                        }
                            else
                            {
                                MasterFolderSet.SelectedAnalyticFolders.Remove(x.Sender.Name);
                            }
                            break;
                        case 1:
                            if (x.Sender.IsSelected)
                            {
                                MasterFolderSet.SelectedEverydayFolders.Add(x.Sender.Name);
                            }
                            else
                            {
                                MasterFolderSet.SelectedEverydayFolders.Remove(x.Sender.Name);
                            }
                            break;

                        case 2:
                            if (x.Sender.IsSelected)
                            {
                                MasterFolderSet.SelectedPromotionFolders.Add(x.Sender.Name);
                            }
                            else
                            {
                                MasterFolderSet.SelectedPromotionFolders.Remove(x.Sender.Name);
                            }
                            break;

                        case 3:
                            if (x.Sender.IsSelected)
                            {
                                MasterFolderSet.SelectedKitFolders.Add(x.Sender.Name);
                            }
                            else
                            {
                                MasterFolderSet.SelectedKitFolders.Remove(x.Sender.Name);
                            }
                            break;


                      
	                }
                
                //Publisher.Publish<FoldersSelectedVM>(x.Sender);
                
                //Console.WriteLine("test");

            });

            var selectedO = this.WhenAnyValue(x => x.SelectedFolderList.ItemChanged);
            //.Where(x => x.PropertyName == "IsSelected");
            //.Select(_ => FilterItems.Any(x => x.IsSelected));

            selectedO.Subscribe(x =>
            {
                Console.WriteLine("test");
            });


            SelectedFolderList.ItemChanged.Subscribe(x =>
            {
                Console.WriteLine("t");
                
            });


            //var master =((HomeSearchViewModel)MainViewModel.SubModuleCache[Domain.SubModuleType.Search]).FolderSet;


            //SelectedAnalyticFolders = master.SelectedAnalyticFolders.Select(x => new FoldersSelectedVM { Name = x, IsSelected = true }).ToList(); 
            //MasterAnalyticFoldersVM = master.MasterAnalyticFolderList.Select( x=> new FoldersSelectedVM {Name = x, IsSelected = false}).ToList();

            //var unique = SelectedAnalyticFolders
            //    .Concat(MasterAnalyticFoldersVM)
            //    .GroupBy(item => item.Name)
            //    .Select(group => group.First()).ToList();

            //MasterEveryDayFolders = master.MasterEverydayFolderList;
            //MasterKitFolders = master.MasterKitFolderList;
            //MasterPromotionFolders = master.MasterPromotionFolderList;

            Publisher.GetEvent<Views.FolderModuleSelectedEvent>()
                .Subscribe(evt =>
                {
                    switch (evt.SelectedIndex)
                    {
                        case 0:

                            Reload(Domain.SubModuleType.Analytics);
                            break;
                        case 1:
                            Reload(Domain.SubModuleType.Everyday);
                            break;
                        case 2:
                            Reload(Domain.SubModuleType.Promotions);
                            break;
                        case 3:
                            Reload(Domain.SubModuleType.Kits);
                            break;
                        default:
                            break;
                    }

                });
        }

        public void Reload(Domain.SubModuleType submodule)
        {
            //save to in memory if folderList != null until flushed to db when user clicks save link
            

            MasterFolderSet = ((HomeSearchViewModel)MainViewModel.SubModuleCache[Domain.SubModuleType.Search]).FolderSet;
                 List<FoldersSelectedVM> selectedVMs = null; List<FoldersSelectedVM> masterVMs = null; 
            switch (submodule)
            {
                case Domain.SubModuleType.Analytics:

                    selectedVMs = MasterFolderSet.SelectedAnalyticFolders.Select(x => new FoldersSelectedVM { Name = x, IsSelected = true }).ToList();
                    masterVMs = MasterFolderSet.MasterAnalyticFolderList.Select(x => new FoldersSelectedVM { Name = x, IsSelected = false }).ToList();
                    Title = "Analytics";
                    SelectedModuleIndex = 0;
                    break;
                case Domain.SubModuleType.Everyday:
                    selectedVMs = MasterFolderSet.SelectedEverydayFolders.Select(x => new FoldersSelectedVM { Name = x, IsSelected = true }).ToList();
                    masterVMs = MasterFolderSet.MasterEverydayFolderList.Select(x => new FoldersSelectedVM { Name = x, IsSelected = false }).ToList();
                    Title = "Everyday";
                    SelectedModuleIndex = 1;
                    break;
                case Domain.SubModuleType.Promotions:
                    selectedVMs = MasterFolderSet.SelectedPromotionFolders.Select(x => new FoldersSelectedVM { Name = x, IsSelected = true }).ToList();
                    masterVMs = MasterFolderSet.MasterPromotionFolderList.Select(x => new FoldersSelectedVM { Name = x, IsSelected = false }).ToList();
                    Title = "Promotions";
                    SelectedModuleIndex = 2;break;
                case Domain.SubModuleType.Kits:
                    selectedVMs = MasterFolderSet.SelectedKitFolders.Select(x => new FoldersSelectedVM { Name = x, IsSelected = true }).ToList();
                    masterVMs = MasterFolderSet.MasterKitFolderList.Select(x => new FoldersSelectedVM { Name = x, IsSelected = false }).ToList();
                    Title = "Kits";                  
                    SelectedModuleIndex = 3;
                    break;

                default:
                    break;
            }

            var folderList = selectedVMs
                        .Concat(masterVMs)
                        .GroupBy(item => item.Name)
                        .Select(group => group.First()).ToList() ;

            SelectedFolderList.Clear();
            foreach (var item in folderList)
            {
                SelectedFolderList.Add(item);
            }

            //SelectedFolderList.AddRange(folderList);
        }

        private List<Domain.SubModuleType> _subModuleKeys;
        public List<Domain.SubModuleType> SubModuleKeys { get { return _subModuleKeys; } set { this.RaiseAndSetIfChanged(ref _subModuleKeys, value); } }

        private Domain.FolderSet _masterFolderSet;
        public Domain.FolderSet MasterFolderSet { get { return _masterFolderSet; } set { this.RaiseAndSetIfChanged(ref _masterFolderSet, value); } }


        private int _SelectedModuleIndex;
        public int SelectedModuleIndex { get { return _SelectedModuleIndex; } set { this.RaiseAndSetIfChanged(ref _SelectedModuleIndex, value); } }

        private string _title;
        public string Title { get { return _title; } set { this.RaiseAndSetIfChanged(ref _title, value); } }

        private ReactiveList<FoldersSelectedVM> _FolderList = new ReactiveList<FoldersSelectedVM>(){ChangeTrackingEnabled = true};
        public ReactiveList<FoldersSelectedVM> SelectedFolderList { get { return _FolderList; } set { this.RaiseAndSetIfChanged(ref _FolderList, value); } }


        //private List<FoldersSelectedVM> _MasterA;
        //public List<FoldersSelectedVM> MasterAnalyticFolders { get { return _MasterA; } set { this.RaiseAndSetIfChanged(ref _MasterA, value); } }

        //private List<FoldersSelectedVM> _MasterAVM;
        //public List<FoldersSelectedVM> MasterAnalyticFoldersVM { get { return _MasterAVM; } set { this.RaiseAndSetIfChanged(ref _MasterAVM, value); } }

        //private List<FoldersSelectedVM> _SelectedA;
        //public List<FoldersSelectedVM> SelectedAnalyticFolders { get { return _SelectedA; } set { this.RaiseAndSetIfChanged(ref _SelectedA, value); } }

        //private List<string> _MasterE;
        //public List<string> MasterEveryDayFolders { get { return _MasterE; } set { this.RaiseAndSetIfChanged(ref _MasterE, value); } }

        //private List<string> _SelectedE;
        //public List<string> SelecedEveryDayFolders { get { return _SelectedE; } set { this.RaiseAndSetIfChanged(ref _SelectedE, value); } }


        //private List<string> _MasterP;
        //public List<string> MasterPromotionFolders { get { return _MasterP; } set { this.RaiseAndSetIfChanged(ref _MasterP, value); } }
        //private List<string> _MasterK;
        //public List<string> MasterKitFolders { get { return _MasterK; } set { this.RaiseAndSetIfChanged(ref _MasterK, value); } }

    }   

    public class FoldersSelectedVM : ReactiveObject
    {

        public string Name { get; set; }
        private Boolean _isSelected;
        public Boolean IsSelected { get { return _isSelected; } set { this.RaiseAndSetIfChanged(ref _isSelected, value); } }
    }
}


