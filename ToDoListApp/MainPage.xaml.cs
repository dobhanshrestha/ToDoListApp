using System.Collections.ObjectModel;

namespace ToDoListApp
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<TaskItem> Tasks { get; set; } = new ObservableCollection<TaskItem>();

        public MainPage()
        {
            InitializeComponent();
            TaskListView.ItemsSource = Tasks;
        }

        private void OnAddTaskClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NewTaskEntry.Text))
            {
                Tasks.Add(new TaskItem { Name = NewTaskEntry.Text, IsCompleted = false });
            }
            ClearEntries();
        }

        private void OnDeleteTaskClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var task = button?.BindingContext as TaskItem;

            if(task != null)
            {
                Tasks.Remove(task);
            }
        }

        private void ClearEntries()
        {
            NewTaskEntry.Text = string.Empty;
        }
    }

}
