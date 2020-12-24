using System;
using System.Windows.Input;

namespace SqlPackageGui.WPF
{
	public class BasicCommand : ICommand
	{
		private readonly Action Action = null;
		//private readonly Func<bool> Condition = null;
		private readonly Predicate<object> CanExecuteDelegate = null;
		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public BasicCommand(Action action) : this(action, (a) => { return true; })
		{
		}

		public BasicCommand(Action action, Predicate<object> canExecute)
		{
			this.Action = action;
			this.CanExecuteDelegate = canExecute;
		}

		public void RaiseCanExecuteChanged()
		{
			CommandManager.InvalidateRequerySuggested();
		}

		public bool CanExecute(object parameter)
		{
			//return _canExecute != null ? _canExecute(parameter) : true;
			if (CanExecuteDelegate is null)
				return true;
			else
				return CanExecuteDelegate.Invoke(parameter);
		}

		public void Execute(object parameter)
		{
			this.Action();
		}
	}
}