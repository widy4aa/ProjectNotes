using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectNotes.ViewModels
{

    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _baseViewModel;

        public BaseViewModel SelectedViewModel
        {
            get { return _baseViewModel; }
            set {_baseViewModel = value; }
        }

        public ICommand UpdatedViewCommand {get; set;}
    }

}