using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARWorlds.Model;
using ARWorlds.ViewModel.Commands;

namespace ARWorlds.ViewModel
{
    public class ViewModelBase : INotifyCollectionChanged
    {
        public MailCommand MailCommand { get; set; }

        private List<Model3D> _list;
        private Model3D _selected;
        public ViewModelBase()
        {
            this.MailCommand = new MailCommand(this);
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public Model3D SelectedModel3D
        {
            get { return _selected; }
            set
            {
                // _selected = value;
                //  RaisePropertyChanged(() => SelectedStation);
                //  showAirStatus(value);
            }
        }

        public List<Model3D> List
        {
            get { return _list; }
            set
            {
                _list = value;
              //  RaisePropertyChanged(() => List);
            }
        }


        public void MailMethod()
        {
            Debug.WriteLine("Send Mail not implemented yet");
        }
    }
}
