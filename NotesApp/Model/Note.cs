using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Model
{
    //Note information
    public class Note : INotifyPropertyChanged
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

        private int notebookId;
        //자신이 속한 notebook의 ID
        public int NotebookId
        {
            get { return notebookId; }
            set {
                notebookId = value;
                OnPropertyChanged("NotebookId");
            }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        private DateTime updatedTime;

        public DateTime UpdatedTime
        {
            get { return updatedTime; }
            set {
                updatedTime = value;
                OnPropertyChanged("UpdatedTime");
            }
        }

        private string fileLocation;

        public string FileLocation
        {
            get { return fileLocation; }
            set {
                fileLocation = value;
                OnPropertyChanged("FileLocation");
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
