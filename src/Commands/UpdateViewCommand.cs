using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjectNotes.ViewModels;
using ProjectNotes.ViewModels;

namespace ProjectNotes.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private BaseViewModel ViewModel;

        // private MainViewModel ViewModel;


        public UpdateViewCommand(MainViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Home")
            {
                ViewModel = new HomeViewModel();
            }
        }
    }
}
