namespace SoCrm.Presentation.App.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Input;

    public abstract class WpfCommand : ICommand
    {
        private readonly string _verb;

        protected WpfCommand(string verb)
        {
            _verb = verb;
        }

        public string Verb
        {
            get { return _verb; }
        }

        public void Execute(object parameter)
        {
            RunCommand(parameter);
        }

        protected abstract void RunCommand(object parameter);
        protected abstract IEnumerable<string> GetPreconditions(object parameter);

        public bool CanExecute(object parameter)
        {
            return GetPreconditions(parameter).Count() < 1;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
