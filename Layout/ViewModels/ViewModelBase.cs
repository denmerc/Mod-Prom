using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Layout.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {


        private Domain.Analytic _SelectedAnalytic;
        public Domain.Analytic SelectedAnalytic { get { return _SelectedAnalytic; } set { this.RaiseAndSetIfChanged(ref _SelectedAnalytic, value); } }
        public void Load(object entity)
        {
            SelectedAnalytic = (Domain.Analytic)entity;
        }
    }
}
