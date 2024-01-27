using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MizuFlow.Model;

namespace MizuFlow
{
    public partial class ToDoItem : UserControl
    {
        Tasks task;
        int id;
        public ToDoItem(string text, int Id)
        {
            InitializeComponent();
            txt_Task.Text = text;
            id = Id;
            //InitializeGroupsComboBox();
            LoadItem();
        }

        //private void InitializeGroupsComboBox()
        //{
        //    // Получите список групп из базы данных
        //    var groups = Registration.unit.TaskGroup.Get().ToList();

        //    // Назначьте список групп свойству ItemsSource ComboBox
        //    cb_Groups.ItemsSource = groups;

        //    // Установите свойство отображаемого текста
        //    cb_Groups.DisplayMemberPath = "Group_Name";
        //}



        private void LoadItem()
        {
            task = Registration.unit.Tasks.Get(t => t.ID_Task == id).Single();
            var subtasks = Registration.unit.Subtasks.Get(s => s.TaskID == id);

            if (subtasks != null && task.isCheck == true)
            {
                foreach (Subtasks s in subtasks)
                {
                    if (s.isCheck != true)
                    {
                        s.isCheck = true;
                        Registration.unit.Subtasks.Update(s);
                        Registration.unit.Save();
                    }
                }
            }
            if (task.Priority != null)
            {
                BasicRatingBar.Value = Convert.ToInt32(task.Priority);
            }
            if (task.isCheck != null)
            {
                btn_TaskSolved.IsChecked = task.isCheck;
            }
            if (task.CreationDateTime != null)
            {
                CreatingDateToolTip(Convert.ToDateTime(task.CreationDateTime));

            }
            if (task.Deadline != null)
            {
                DeadlineToolTip(Convert.ToDateTime(task.Deadline));

            }
            if (task.CheckTime != null)
            {
                DateCheckToolTip(Convert.ToDateTime(task.CheckTime));
                
            }
        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            MainPage.ToDoItem_Delete(this, id);
        }
        
        private void Btn_AddSubtask_Click(object sender, RoutedEventArgs e)
        {
            if (this != null)  // Убедитесь, что объект не является null
            {
                MainPage.ToDoSubItem_Add(this, id);
            }
            else MessageBox.Show("NULL");
        }

        bool checkEdit = true;
        private void Btn_EditTask_Click(object sender, RoutedEventArgs e)
        {
            if (checkEdit)
            {
                txt_Task.IsReadOnly = false;
                md_EditTask.Foreground = Brushes.Black;
                checkEdit = false;
            }
            else
            {
                try
                {
                    task.Task_Name = txt_Task.Text;
                    Registration.unit.Tasks.Update(task);
                    Registration.unit.Save();

                    txt_Task.IsReadOnly = true;
                    md_EditTask.Foreground = Brushes.White;
                    checkEdit = true;
                }
                catch(Exception ex){
                    MessageBox.Show(ex.Message);
                }


            }
        }

        private void Btn_TaskSolved_Click(object sender, RoutedEventArgs e)
        {
            if (btn_TaskSolved.IsChecked==true)
            {
                task.isCheck = true;
                task.CheckTime = DateTime.Now;
            }
            else
            {
                task.isCheck = false;
                task.CheckTime = null;
            }

            Registration.unit.Tasks.Update(task);
            Registration.unit.Save();
        }

        private void BasicRatingBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<int> e)
        {
            task.Priority = BasicRatingBar.Value;

            Registration.unit.Tasks.Update(task);
            Registration.unit.Save();

            if (task.Priority == 3)
            {
                cb_Importance.Background = Brushes.Crimson;
            }
            if (task.Priority == 2)
            {
                cb_Importance.Background = Brushes.Gold;
            }
            if (task.Priority == 1)
            {
                cb_Importance.Background = Brushes.Silver;
            }
           

        }

        private void Dp_CreatingDate_SelectedDateChanged( object sender, SelectionChangedEventArgs e )
        {
            try
            {
                DatePicker datePicker = sender as DatePicker;

                if (datePicker.SelectedDate.HasValue && datePicker.SelectedDate > DateTime.Now)
                {
                    MessageBox.Show("Нельзя выбирать дату больше сегодняшней. Установлена текущая дата", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    datePicker.SelectedDate = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            DateTime date = new DateTime();
            date = Convert.ToDateTime(_dp_CreationDate.SelectedDate);
            CreatingDateToolTip(date);


            task.CreationDateTime = date;
            Registration.unit.Tasks.Update(task);
            Registration.unit.Save();
        }

        private void CreatingDateToolTip( DateTime date )
        {
            ToolTip toolTip = new ToolTip
            {
                HasDropShadow = true,
                Foreground = Brushes.Black,
                Background = Brushes.White,
                HorizontalOffset = 40,
                VerticalOffset = -20,
                Content = new TextBlock { Text = date.ToShortDateString(), FontSize = 16, Foreground = Brushes.Gray }
            };
            _dp_CreationDate.ToolTip = toolTip;
            _dp_CreationDate.BorderBrush = Brushes.Black;
        }
        private void Dp_Deadline_SelectedDateChanged( object sender, SelectionChangedEventArgs e )
        {
            try
            {
                DatePicker datePicker = sender as DatePicker;

                if (datePicker.SelectedDate.HasValue && datePicker.SelectedDate < DateTime.Now)
                {
                    MessageBox.Show("Нельзя выбирать дату меньше сегодняшней. Установлена текущая дата", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    datePicker.SelectedDate = DateTime.Now.AddHours(1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            DateTime date = new DateTime();
            date = Convert.ToDateTime(dp_Deadline.SelectedDate);
            DeadlineToolTip(date);

            task.Deadline = date;
            Registration.unit.Tasks.Update(task);
            Registration.unit.Save();
        }

        private void DeadlineToolTip( DateTime date )
        {
            ToolTip toolTip = new ToolTip
            {
                HasDropShadow = true,
                Foreground = Brushes.Black,
                Background = Brushes.White,
                HorizontalOffset = 40,
                VerticalOffset = -20,
                Content = new TextBlock { Text = date.ToShortDateString(), FontSize = 16, Foreground = Brushes.Gray }
            };
            dp_Deadline.ToolTip = toolTip;
            dp_Deadline.BorderBrush = Brushes.Black;
        }
    private void Dp_DateCheck_SelectedDateChanged( object sender, SelectionChangedEventArgs e )
        {
            try
            {
                DatePicker datePicker = sender as DatePicker;

                if (datePicker.SelectedDate.HasValue && datePicker.SelectedDate > DateTime.Now)
                {
                    MessageBox.Show("Нельзя выбирать дату больше сегодняшней. Установлена текущая дата", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    datePicker.SelectedDate = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }



            DateTime date = new DateTime();
            date = Convert.ToDateTime(dp_DateCheck.SelectedDate);
            DateCheckToolTip(date);

            task.CheckTime = date;
            Registration.unit.Tasks.Update(task);
            Registration.unit.Save();
        }

        private void DateCheckToolTip( DateTime date )
        {
            ToolTip toolTip = new ToolTip
            {
                HasDropShadow = true,
                Foreground = Brushes.Black,
                Background = Brushes.White,
                HorizontalOffset = 40,
                VerticalOffset = -20,
                Content = new TextBlock { Text = date.ToShortDateString(), FontSize = 16, Foreground = Brushes.Gray }
            };
            dp_DateCheck.ToolTip = toolTip;
            dp_DateCheck.BorderBrush = Brushes.Black;
        }
        private void ShowTaskInfo()
        {
            try
            {
          
                // Получите информацию о задаче
                Tasks task = Registration.unit.Tasks.Get(t => t.ID_Task == id).SingleOrDefault();

                if (task != null)
                {
                    // Загрузка данных о группах
                    var groups = Registration.unit.TaskGroup.Get().ToList();
                    //cb_Groups.ItemsSource = groups;

                    //// Установка выбранной группы
                    //cb_Groups.SelectedValue = task.Task_ID_Group;

                    txtTaskInfo.Text = $"Task Name: {task.Task_Name}\n" +
                                       $"Priority: {task.Priority}\n" +
                                       $"Creation Date: {task.CreationDateTime}\n" +
                                       $"Deadline: {task.Deadline}\n" +
                                       $"Is Work: {task.isWork}\n" +
                                       $"Is Checked: {task.isCheck}\n" +
                                       $"Check Time: {task.CheckTime}\n" +
                                       $"Group: {task.Groups?.Group_Name}\n"; // Выводим имя группы


                    taskInfoPopup.PlacementTarget = Btn_Inf;
                    taskInfoPopup.IsOpen = true;
                }
                else
                {
                    MessageBox.Show("Task not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void Btn_Inf_Click( object sender, RoutedEventArgs e )
        {
            ShowTaskInfo(); // Показать информацию о задаче
        }



        private void Btn_MoreFunk_Click( object sender, RoutedEventArgs e )
        {
            moreFunctionsPopup.PlacementTarget = Btn_MoreFunk;
            moreFunctionsPopup.IsOpen = true;
        }

        private void Btn_ClosePopup_Click( object sender, RoutedEventArgs e )
        {
            moreFunctionsPopup.IsOpen = false;
        }




    }
}
