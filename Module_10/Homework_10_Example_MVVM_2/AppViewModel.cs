using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Homework_10_Example_MVVM_2
{
    public class AppViewModel : INotifyPropertyChanged
    {
        private string selectedName;

        public string SelectedName
        {
            get { return selectedName; }
            set 
            { 
                selectedName = value; 
                OnPropertyChanged("SelectedName");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


        public AppViewModel()
        {
            selectedName = "FirstName";
        }



    }
}
