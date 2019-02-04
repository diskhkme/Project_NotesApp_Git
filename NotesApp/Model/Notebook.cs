using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Model
{
    //Notebook Information(노트의 집합)
    public class Notebook : INotifyPropertyChanged
    {
        private int id;

        public int Id
        {
            get { return id; }
            set {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        private int userId;
        //자신이 속한 User의 ID
        public int UserId
        {
            get { return userId; }
            set {
                userId = value;
                OnPropertyChanged("UserId");
            }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
