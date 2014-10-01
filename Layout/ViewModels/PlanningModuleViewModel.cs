using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layout.ViewModels
{
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

        public PlanningModuleViewModel(Data.ISearchRepository repository, Domain.Session session)
        {

            //load default submoduleVM
            //SelectedSubModule = new HomeSearchViewModel(repository);
        }

    }
}
