using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfTestDemo.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {

        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string passWord;

        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; OnPropertyChanged(); }
        }

    }
}
