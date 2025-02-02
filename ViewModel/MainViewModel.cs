
using System.Collections.ObjectModel;
using System.Windows;
using Todo_App.Model;
using Todo_App.MVVM;
using Task = Todo_App.Model.Task;

namespace Todo_App.ViewModel
{
    internal class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Task> Tasks { get; set; }



        public RelayCommand addTaskCommand => new RelayCommand(execute => AddTask(), canExecute => true);
        public RelayCommand deleteTaskCommand => new RelayCommand(execute => DeleteTask(), canExecute => (SelectedTask != null));
        public RelayCommand clearTaskCommand => new RelayCommand(execute => ClearTask(), canExecute => true);
        public RelayCommand updateTaskCommand => new RelayCommand(execute => UpdateTask(), canExecute => (SelectedTask != null));
        public RelayCommand MarkTaskCommand => new RelayCommand(execute => MarkTask(), canExecute => (SelectedTask != null));


        public MainViewModel()
        {
            Tasks = new ObservableCollection<Task>();

            Tasks.Add(new Task { eventHead = "Buy groceries", eventDescp = "Milk, Eggs, Bread", eventDate = DateTime.Now.AddDays(1) });
            Tasks.Add(new Task { eventHead = "Complete homework", eventDescp = "Math exercises", eventDate = DateTime.Now.AddDays(2) });
        }

        private Task _selectedTask;

        public Task SelectedTask
        {
            get { return _selectedTask; }
            set
            {
                _selectedTask = value;
                OnPropertyChanged();
            }
        }

        private bool _eventStaus;

        public bool EventStaus
        {
            get { return _eventStaus; }
            set
            {
                {
                    _eventStaus = value;
                    OnPropertyChanged(nameof(EventStaus));  // Notify UI about change
                }
            }
        }



        private void AddTask()
        {
            Tasks.Add(new Task()
            {
                eventHead = "New Task",
                eventDescp = "D1",
                eventDate = DateTime.Now
            });
        }

        private void DeleteTask()
        {
            Tasks.Remove(SelectedTask);
        }

        private void ClearTask()
        {
            Tasks.Clear();
        }

        private void UpdateTask()
        {
            MessageBox.Show("Update Task");
        }

        private void MarkTask()
        {
            if (SelectedTask != null)

            {
                SelectedTask.eventStatus = true;
                
                
            }


        }
    }
}
