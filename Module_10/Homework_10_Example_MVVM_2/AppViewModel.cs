using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Homework_10_Example_MVVM_2
{
    public class AppViewModel : INotifyPropertyChanged
    {
        private Nekto selectedName;

        public string SelectedName
        {
            get { return selectedName.Name; }
            set 
            { 
                selectedName.Name = value; 
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
            selectedName = new Nekto { Name = "FirstName" };
        }



    }
}
