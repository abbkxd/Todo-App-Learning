
using System.Windows.Input;

namespace Todo_App.MVVM
{
    internal class RelayCommand : ICommand
    {
        private Action<object> _execute;
        private Func<object,bool> canExecute;

        public RelayCommand(Action<object> _execute,Func<object, bool> canExecute)
        {
            this._execute = _execute;
            this.canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
           return canExecute == null || canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }
    }
}
