using MizuFlow.Model;
using System.Linq;
using System.Windows;

namespace MizuFlow
{
    public partial class SelectTaskWindow : Window
    {
        public Tasks SelectedTask { get; private set; }

        public SelectTaskWindow()
        {
            InitializeComponent();
            PopulateTasks();
        }

        private void PopulateTasks()
        {
            // Здесь используйте ваш запрос к базе данных или другой источник данных
            var tasks = Registration.unit.Tasks.Get().ToList();

            listBoxTasks.ItemsSource = tasks;
        }

        private void Btn_SelectTask_Click( object sender, RoutedEventArgs e )
        {
            // Получите выбранную задачу из ListBox
            SelectedTask = listBoxTasks.SelectedItem as Tasks;

            if (SelectedTask != null)
            {
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Please select a task.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

