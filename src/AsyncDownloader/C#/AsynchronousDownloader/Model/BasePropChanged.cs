using System.ComponentModel;
using System.Runtime.CompilerServices;
using PropertyChanged;

namespace AsynchronousDownloader.Model
{
    [DoNotNotify]
    public class BasePropChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
    }
}