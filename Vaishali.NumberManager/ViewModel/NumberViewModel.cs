using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Vaishali.DataModel;
using Vaishali.Framework;
using Vaishali.NumberManager.Commands;
using Vaishali.NumberManager.Service;

namespace Vaishali.NumberManager.ViewModel
{
    public class NumberViewModel:INotifyPropertyChanged , INumberViewModel
    {
        private ObservableCollection<Number> _numbers;
        private NumberService _numberService;
        public ICommand ReadCommand { get; private set; }
        public ICommand WriteCommand { get; private set; }

        public ObservableCollection<Number> Numbers
        {
            get { return _numbers; }
            set
            {
                _numbers = value;
                
                RaisePropertyChanged("Numbers");
            }
        }
        

        public NumberViewModel(NumberService numberService)
        {
            _numberService = numberService;
            LoadNumbers();
            LoadCommands();
        }

        private void LoadCommands()
        {
            ReadCommand = new Command(Read,CanRead);
            WriteCommand = new  Command(Write,CanWrite);
        }

        private bool CanWrite(object obj)
        {
            return true;
        }

        private void Write(object obj)
        {
            _numberService.Write(_numbers.ToList());
        }

        private bool CanRead(object obj)
        {
            return true;
        }

        private void Read(object obj)
        {
            Numbers=_numberService.Read().ToObservableCollection();
        }


        private void LoadNumbers()
        {
            Numbers = _numberService.GetNumbers().ToObservableCollection();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
