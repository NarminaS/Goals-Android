using Goals.ViewModels;
using System;
using System.Windows.Input;

namespace Goals.Commands
{
    public class OpenModalCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        MissionListViewModel viewModel;
        public OpenModalCommand(MissionListViewModel vm)
        {
            viewModel = vm;
        }

        public bool CanExecute(object parameter)
        {
            return !viewModel.Loading;
        }

        public async void Execute(object parameter)
        {
            if (CanExecute(parameter))
                await viewModel.OpenModal();
        }
    }
}
