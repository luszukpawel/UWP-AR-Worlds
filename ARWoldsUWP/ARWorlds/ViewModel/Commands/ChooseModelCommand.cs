using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ARWorlds.ViewModel.Commands
{
    public class ChooseModelCommand : ICommand
    {

        public ViewModelBase ViewModel { get; set; }
        public ChooseModelCommand(ViewModelBase viewModel)
        {
            this.ViewModel = viewModel;
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            if(parameter != null)
            {
                var s = parameter as String;
                if(String.IsNullOrEmpty(s))
                {
                    return true;
                }
                return true;
            }
            return true;
        }

        public void Execute(object parameter)
        {
            this.ViewModel.ChoseModelMethod(parameter as String);
        }



    }
}
