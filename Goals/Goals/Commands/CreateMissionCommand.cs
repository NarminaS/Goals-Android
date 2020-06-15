using Goals.ViewModels;
using System;
using System.Windows.Input;

namespace Goals.Commands
{
    class CreateMissionCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private MissionCreateViewModel viewModel;

        public CreateMissionCommand(MissionCreateViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return !string.IsNullOrWhiteSpace(parameter as string);
        }

        public async void Execute(object parameter)
        {
            if (CanExecute(parameter))
                await viewModel.Create();
        }
    }
}
