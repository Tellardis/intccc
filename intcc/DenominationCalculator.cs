using System;
using intcc.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using intcc.Annotations;

namespace intcc
{
    public class DenominationCalculator : INotifyPropertyChanged
    {
        private int _m500, _m200, _m100, _m50, _m20, _m10, _m5, _m2, _m1;

        public int M500
        {
            get { return _m500; }
            set
            {
                _m500 = value;
                OnPropertyChanged(nameof(M500));
                OnPropertyChanged(nameof(Total));
                }
        }

        public int M200
        {
            get { return _m200; }
            set
            {
                _m200 = value;
                OnPropertyChanged(nameof(M200));
                OnPropertyChanged(nameof(Total));
            }
        }

        public int M100
        {
            get { return _m100; }
            set
            {
                _m100 = value;
                OnPropertyChanged(nameof(M100));
                OnPropertyChanged(nameof(Total));
            }
        }

        public int M50
        {
            get { return _m50; }
            set
            {
                _m50 = value;
                OnPropertyChanged(nameof(M50));
                OnPropertyChanged(nameof(Total));
            }
        }

        public int M20
        {
            get { return _m20; }
            set
            {
                _m20 = value;
                OnPropertyChanged(nameof(M20));
                OnPropertyChanged(nameof(Total));
            }
        }

        public int M10
        {
            get { return _m10; }
            set
            {
                _m10 = value;
                OnPropertyChanged(nameof(M10));
                OnPropertyChanged(nameof(Total));
            }
        }

        public int M5
        {
            get { return _m5; }
            set
            {
                _m5 = value;
                OnPropertyChanged(nameof(M5));
                OnPropertyChanged(nameof(Total));
            }
        }

        public int M2
        {
            get { return _m2; }
            set
            {
                _m2 = value;
                OnPropertyChanged(nameof(M2));
                OnPropertyChanged(nameof(Total));
            }
        }

        public int M1
        {
            get { return _m1; }
            set
            {
                _m1 = value;
                OnPropertyChanged(nameof(M1));
                OnPropertyChanged(nameof(Total));
            }
        }

        public int Total
        {
            get
            {
                Calculate.Clear();
                Calculate.Add(M500, 500);
                Calculate.Add(M200, 200);
                Calculate.Add(M100, 100);
                Calculate.Add(M50, 50);
                Calculate.Add(M20, 20);
                Calculate.Add(M10, 10);
                Calculate.Add(M5, 5);
                Calculate.Add(M2, 2);
                Calculate.Add(M1, 1);
                return Calculate.Total;
            }
        }

        public DenominationCalculator()
        {
            _clearClickCommand = new DelegateCommand<string>((s) =>
            {
                M500 = 0;
                M200 = 0;
                M100 = 0;
                M50 = 0;
                M20 = 0;
                M10 = 0;
                M5 = 0;
                M2 = 0;
                M1 = 0;
            });

            _saveCommand = new DelegateCommand<string>((s) => { MessageBox.Show(s); });
        }

        //(()=> {System.Windows.MessageBox.Show("Hello delegate binding");});

        private DelegateCommand<string> _clearClickCommand;
        public DelegateCommand<string> ClearClickCommand => _clearClickCommand;
        private DelegateCommand<string> _saveCommand;
        public DelegateCommand<string> SaveCommand => _saveCommand;


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

public class DelegateCommand<T> : ICommand where T : class
{
    private readonly Predicate<T> _canExecute;
    private readonly Action<T> _execute;

    public DelegateCommand(Action<T> execute): this(execute, null){}

    public DelegateCommand(Action<T> execute, Predicate<T> canExecute)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public bool CanExecute(object parameter)
    {
        if (_canExecute == null)
            return true;

        return _canExecute((T)parameter);
    }

    public void Execute(object parameter)
    {
        _execute((T)parameter);
    }

    public event EventHandler CanExecuteChanged;
    public void RaiseCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
