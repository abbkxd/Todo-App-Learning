

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Task = Todo_App.Model.Task;

namespace Todo_App.MVVM
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public ObservableCollection<Task> Tasks { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName]String propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
