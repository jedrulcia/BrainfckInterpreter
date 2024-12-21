using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BrainfckInterpreter
{
	class MainWindowViewModel : INotifyPropertyChanged
	{
		private readonly BrainfuckInterpreter brainfuckInterpreter;

		public ObservableCollection<int> Memory { get; private set; }

		private int _currentPointer;
		public int CurrentPointer
		{
			get => _currentPointer;
			set
			{
				_currentPointer = value;
				OnPropertyChanged();
			}
		}

		public string _code;
		public string Code
		{
			get => _code;
			set
			{
				_code = value;
				OnPropertyChanged();
			}
		}

		public MainWindowViewModel()
		{
			brainfuckInterpreter = new BrainfuckInterpreter();
			Memory = new ObservableCollection<int>(brainfuckInterpreter.Memory);
			CurrentPointer = brainfuckInterpreter.Pointer;
		}

		public void ExecuteCode()
		{
			brainfuckInterpreter.Run(Code);

			for (int i = 0; i < Memory.Count; i++)
			{
				Memory[i] = brainfuckInterpreter.Memory[i];
			}
			_currentPointer = brainfuckInterpreter.Pointer;
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
