using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;

namespace ARWorlds.Model
{
    public class Model3D : INotifyPropertyChanged
    {
        public Model3D()
        {
            if (DesignMode.DesignModeEnabled)
            {
                this.Name = "heart";
                this.Author = "pluszak";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        private string author;

        public string Author
        {
            get { return author; }
            set
            {
                author = value;
                OnPropertyChanged("Author");
            }
        }

        private int likes;

        public int Likes
        {
            get { return likes; }
            set
            {
                likes = value;
                OnPropertyChanged("Likes");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

}
