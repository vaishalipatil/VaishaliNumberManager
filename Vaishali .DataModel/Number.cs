using System;
using System.ComponentModel;

namespace Vaishali.DataModel
{
    public class Number : INotifyPropertyChanged, IDataErrorInfo
    {
        private int numberValue;

        public int NumberValue
        {
            get { return numberValue; }
            set
            {
                numberValue = value;
                RaisePropertyChanged("NumberValue");
            }
        }

        //private int numberIndex;
        //public int NumberIndex
        //{
        //    get { return numberIndex; }
        //    set
        //    {
        //        numberIndex = value;
        //        RaisePropertyChanged("NumberIndex");
        //    }
        //}

        public int NumberIndex { get; set; }

        public Number(int index, int value)
        {
            NumberIndex = index;
            NumberValue = value;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string this[string columnName]
        {
            get
            {
                var errorMessage = String.Empty;
                if (columnName == "NumberValue")
                {
                    if (IsNotNumber(NumberValue))
                    {
                        errorMessage = "Not a valid Number!!";
                    }
                }
                return errorMessage;
            }
        }

        private bool IsNotNumber(int value)
        {
            return false;
        }

        public string Error
        {
            get { return string.Empty; }
        }
    }


}
