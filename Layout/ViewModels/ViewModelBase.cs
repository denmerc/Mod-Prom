using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Layout.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        public ViewModelBase Navigate(object entity)
        {
            return new ViewModels.Analytic.IdentityViewModel();
        }
    }
}
