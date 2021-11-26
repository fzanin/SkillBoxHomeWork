using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Homework_10_Task_MVVM.Model;

namespace Homework_10_Task_MVVM.ViewModel
{
    internal class HelloViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string helloString;

        public string HelloString
        {
            get { return helloString; }

            set 
            { 
                helloString = value;
                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));  
        }


        public HelloViewModel()
        {
            HelloModel helloModel = new HelloModel();
            helloString = helloModel.ImportantInfo;
        }


    }
}
