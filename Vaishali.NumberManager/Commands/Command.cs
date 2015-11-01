using System;
using System.Windows.Input;

namespace Vaishali.NumberManager.Commands
{
    public class Command : ICommand
    {
        private Action<object> _action;
        private Predicate<object> _canExcutePredicate;

        public Command(Action<object> action, Predicate<object> canExcutePredicate)
        {
            _action = action;
            _canExcutePredicate = canExcutePredicate;
        }

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return _canExcutePredicate != null ? true : _canExcutePredicate(parameter);

        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (parameter != null)
            {
                _action(parameter);
            }
            else
            {
                _action("Error: No parameters to execute command.");
            }
        }

        #endregion
    }
}
