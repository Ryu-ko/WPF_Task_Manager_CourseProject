using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using MizuFlow.Model;

namespace MizuFlow
{
    public partial class MainPage : Page
    {
        static User user = new User();

        static StackPanel sp_Person;
        static StackPanel sp_Work;
        public MainPage()
        {
            InitializeComponent();
        }
        public MainPage( User user )
        {
            InitializeComponent();

            MainPage.user = user;
            FillFields();
            ShowTasks();
        }



        private void FillFields()
        {
            sp_Person = pnl_TasksP;
            sp_Work = pnl_TasksW;

            lbl_Scheduled.Content += " " + Registration.unit.Tasks.Get(t => t.Task_UserID == user.ID_User && t.isCheck != true).Count();
            lbl_Completed.Content += " " + Registration.unit.Tasks.Get(t => t.Task_UserID == user.ID_User && t.isCheck == true).Count();
            
            sp_Statistics.Children.Add(new StatisticsControl(user));
        }



        private void Filter_Checked( object sender, RoutedEventArgs e )
        {
            RefreshTasksWithFilters();
        }

        private void Filter_Unchecked( object sender, RoutedEventArgs e )
        {
            RefreshTasksWithFilters();
        }

        private void Btn_ResetFilter_Click( object sender, RoutedEventArgs e )
        {
            // Сбросить все чекбоксы
            FiltChecked.IsChecked = false;
            FiltUncheked.IsChecked = false;
            FiltHighPrior.IsChecked = false;
            FiltMidlPrior.IsChecked = false;
            FiltLowPrior.IsChecked = false;
            FiltGroupStudy.IsChecked = false;
            FiltGroupHome.IsChecked = false;
            // Обновить задачи
            RefreshTasks();
        }
        public void RefreshTasks()
        {
            ShowTasks();
        }
        public void RefreshTasksWithFilters()
        {
            // Получите значения выбранных фильтров
            bool showCompleted = FiltChecked.IsChecked ?? false;
            bool showUncompleted = FiltUncheked.IsChecked ?? false;
            bool showHighPriority = FiltHighPrior.IsChecked ?? false;
            bool showMidPriority = FiltMidlPrior.IsChecked ?? false;
            bool showLowPriority = FiltLowPrior.IsChecked ?? false;
            bool showGroupStudy = FiltGroupStudy.IsChecked ?? false;
            bool showGroupHome = FiltGroupHome.IsChecked ?? false;


            // Если ни один фильтр не выбран, покажите все задачи
            if (!showCompleted && !showUncompleted && !showHighPriority && !showMidPriority && !showLowPriority && !showGroupStudy && !showGroupHome)
            {
                ShowTasks();
                return;
            }
            else{
                ShowTasks( showGroupStudy, showGroupHome);
            }
        }

        public void ShowTasks()
        {
            pnl_TasksP.Children.Clear();
            pnl_TasksW.Children.Clear();

            var tasks = Registration.unit.Tasks.Get(t => t.Task_UserID == user.ID_User).OrderByDescending(o => o.Priority);
            if (tasks != null)
            {
                foreach (Tasks task in tasks)
                {
                    if (task.CheckTime != null && task.CheckTime < DateTime.Now.AddDays(-1)) { }
                    else
                    {
                        var item = AddTaskItem(task.Task_Name, task.ID_Task, Convert.ToBoolean(task.isWork));
                        var subtasks = Registration.unit.Subtasks.Get(s => s.TaskID == task.ID_Task);
                        if (subtasks != null)
                        {
                            foreach (Subtasks subtask in subtasks)
                            {
                                AddSubTaskItem(subtask.ID_Subtask, Convert.ToBoolean(task.isWork), item, subtask.Subtask_Name);
                            }
                        }
                    }
                }
            }
        }
        public void ShowTasks( bool showGroupStudy, bool showGroupHome )
        {
            pnl_TasksP.Children.Clear();
            pnl_TasksW.Children.Clear();

            var tasks = Registration.unit.Tasks.Get(t => t.Task_UserID == user.ID_User).OrderByDescending(o => o.Priority);
            if (tasks != null)
            {
                foreach (Tasks task in tasks)
                {
                    if (task.CheckTime != null && task.CheckTime < DateTime.Now.AddDays(-1)) { }
                    else
                    {
                        // Добавленные переменные для фильтрации по группам
                        bool showByGroupStudy = showGroupStudy && task.Task_ID_Group == 1;
                        bool showByGroupHome = showGroupHome && task.Task_ID_Group == 2;

                        // Фильтрация по группам
                        if (showByGroupStudy || showByGroupHome)
                        {
                            var item = AddTaskItem(task.Task_Name, task.ID_Task, Convert.ToBoolean(task.isWork));
                            var subtasks = Registration.unit.Subtasks.Get(s => s.TaskID == task.ID_Task);
                            // Дополнительная логика для подзадач, если необходимо
                        }
                    }
                }
            }
        }


        //public void ShowTasks(  bool showGroupStudy, bool showGroupHome )
        //{
        //    pnl_TasksP.Children.Clear();
        //    pnl_TasksW.Children.Clear();

        //    var tasks = Registration.unit.Tasks.Get(t => t.Task_UserID == user.ID_User).OrderByDescending(o => o.Priority);
        //    if (tasks != null)
        //    {
        //        foreach (Tasks task in tasks)
        //        {
        //            if (task.CheckTime != null && task.CheckTime < DateTime.Now.AddDays(-1)) { }
        //            else
        //            {
        //                //bool showByCompleted = (showCompleted && Convert.ToBoolean(task.isCheck)) || (showUncompleted && !Convert.ToBoolean(task.isCheck));
        //                //bool showByPriority = (showHighPriority && task.Priority == 3) ||
        //                //                      (showMidPriority && task.Priority == 2) ||
        //                //                      (showLowPriority && task.Priority == 1);

        //                // Добавленные переменные для фильтрации по группам
        //                bool showByGroupStudy = showGroupStudy && task.Task_ID_Group == 1;
        //                bool showByGroupHome = showGroupHome && task.Task_ID_Group == 2;

        //                // Фильтрация по выполненности и приоритету
        //                if (!showByGroupStudy || showByGroupHome)
        //                {
        //                    var item = AddTaskItem(task.Task_Name, task.ID_Task, Convert.ToBoolean(task.isWork));
        //                    var subtasks = Registration.unit.Subtasks.Get(s => s.TaskID == task.ID_Task);
        //                }
        //                if (showByGroupStudy || !showByGroupHome)
        //                {
        //                    var item = AddTaskItem(task.Task_Name, task.ID_Task, Convert.ToBoolean(task.isWork));
        //                    var subtasks = Registration.unit.Subtasks.Get(s => s.TaskID == task.ID_Task);
        //                }
        //            }
        //        }
        //    }
        //}

        //public void ShowTasks( bool showCompleted, bool showUncompleted, bool showHighPriority, bool showMidPriority, bool showLowPriority, bool showGroupStudy, bool showGroupHome )
        //{
        //    pnl_TasksP.Children.Clear();
        //    pnl_TasksW.Children.Clear();

        //    var tasks = Registration.unit.Tasks.Get(t => t.Task_UserID == user.ID_User).OrderByDescending(o => o.Priority);
        //    if (tasks != null)
        //    {
        //        foreach (Tasks task in tasks)
        //        {
        //            if (task.CheckTime != null && task.CheckTime < DateTime.Now.AddDays(-1)) { }
        //            else
        //            {
        //                bool showByCompleted = (showCompleted && Convert.ToBoolean(task.isCheck)) || (showUncompleted && !Convert.ToBoolean(task.isCheck));
        //                bool showByPriority = (showHighPriority && task.Priority == 3) ||
        //                                      (showMidPriority && task.Priority == 2) ||
        //                                      (showLowPriority && task.Priority == 1);
        //                //bool showbyGroupStudy= (showGroupStudy && Convert.ToBoolean(task.isCheck)) || (showGroupHome && !Convert.ToBoolean(task.isCheck));
        //                //Фильтрация по выполненности и приоритету
        //                bool showByGroup = (showGroupStudy && task.Task_ID_Group == 1) ||
        //                          (showGroupHome && task.Task_ID_Group == 2);
        //                // Фильтрация по выполненности, приоритету и группам
        //                if ( !showByPriority && showByGroup)
        //                {
        //                    var item = AddTaskItem(task.Task_Name, task.ID_Task, Convert.ToBoolean(task.isWork));
        //                    var subtasks = Registration.unit.Subtasks.Get(s => s.TaskID == task.ID_Task);
        //                    if (subtasks != null)
        //                    {
        //                        foreach (Subtasks subtask in subtasks)
        //                        {
        //                            AddSubTaskItem(subtask.ID_Subtask, Convert.ToBoolean(task.isWork), item, subtask.Subtask_Name);
        //                        }
        //                    }
        //                }
        //                //if (showByCompleted && !showByPriority)
        //                //{
        //                //    var item = AddTaskItem(task.Task_Name, task.ID_Task, Convert.ToBoolean(task.isWork));
        //                //    var subtasks = Registration.unit.Subtasks.Get(s => s.TaskID == task.ID_Task);
        //                //}
        //                //if (!showByCompleted && showByPriority)
        //                //{
        //                //    var item = AddTaskItem(task.Task_Name, task.ID_Task, Convert.ToBoolean(task.isWork));
        //                //    var subtasks = Registration.unit.Subtasks.Get(s => s.TaskID == task.ID_Task);
        //                //}


        //                //if (showByCompleted && !showByPriority)
        //                //{
        //                //    var item = AddTaskItem(task.Task_Name, task.ID_Task, Convert.ToBoolean(task.isWork));
        //                //    var subtasks = Registration.unit.Subtasks.Get(s => s.TaskID == task.ID_Task);
        //                //}
        //                //if (!showByCompleted && showByPriority)
        //                //{
        //                //    var item = AddTaskItem(task.Task_Name, task.ID_Task, Convert.ToBoolean(task.isWork));
        //                //    var subtasks = Registration.unit.Subtasks.Get(s => s.TaskID == task.ID_Task);
        //                //}
        //            }
        //        }
        //    }
        //}
        public static ToDoItem AddTaskItem( string text, int id, bool isWork )
        {
            ToDoItem item = new ToDoItem(text, id)
            {
                Margin = new Thickness(15, 10, 10, 0),
                HorizontalAlignment = HorizontalAlignment.Center
            };
            if (isWork == true)
            {
                sp_Work.Children.Add(item);
            }
            else
            {
                sp_Person.Children.Add(item);
            }
            return item;
        }

        public static void AddSubTaskItem( int id, bool isWork, ToDoItem item, string text = null )
        {
            ToDoSubItem subitem = new ToDoSubItem(id, text)
            {
                Margin = new Thickness(20, 10, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Center
            };

            if (isWork == true)
            {
                int i = sp_Work.Children.IndexOf(item);
                sp_Work.Children.Insert(i + 1, subitem);
            }
            else
            {
                int i = sp_Person.Children.IndexOf(item);
                sp_Person.Children.Insert(i + 1, subitem);
            }
        }

        public static void CreateTaskItem( string text, bool isWork )/*, int? task_id_group*/
        {
            try
            {
                Tasks task;

                if (isWork)
                {
                    task = new Tasks
                    {
                        Task_UserID = user.ID_User,
                        Task_Name = text,
                        isWork = true,
                        isCheck = false,
                        CreationDateTime = DateTime.Now, // Устанавливаем текущую дату
                        Deadline = DateTime.Now.Date
                    };
                }
                else
                {
                    task = new Tasks
                    {
                        Task_UserID = user.ID_User,
                        Task_Name = text,
                        isWork = false,
                        isCheck = false,
                        CreationDateTime = DateTime.Now, // Устанавливаем текущую дату
                        Deadline = DateTime.Now.Date

                    };
                }
                Registration.unit.Tasks.Create(task);
                Registration.unit.Save();

                int id = Registration.unit.Tasks.Get(t => t.Task_Name == text).FirstOrDefault().ID_Task;
                AddTaskItem(text, id, isWork);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btn_AddTaskP_Click( object sender, RoutedEventArgs e )
        {
            string task = txt_AddTaskP.Text;
           
            if (task.Length != 0)
            {
                CreateTaskItem(task, false);
                txt_AddTaskP.Text = "";
            }
            else
            {
                MessageBox.Show("You are trying to create an empty task", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Btn_AddTaskW_Click( object sender, RoutedEventArgs e )
        {
            string task = txt_AddTaskW.Text;

            if (task.Length != 0)
            {
                CreateTaskItem(task, true);
                txt_AddTaskW.Text = "";
            }
            else
            {
                MessageBox.Show("You are trying to create an empty task", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        public static void ToDoItem_Delete( UIElement item, int id )
        {
            try
            {
                var task = Registration.unit.Tasks.Get(t => t.Task_UserID == user.ID_User && t.ID_Task == id).Single();
                var subtasks = Registration.unit.Subtasks.Get(s => s.TaskID == id);
                int count = subtasks.Count();
                if (task.isWork == true)
                {
                    int i = sp_Work.Children.IndexOf(item);
                    for (int j = 0; j < count; j++)
                        sp_Work.Children.RemoveAt(i + 1);
                    sp_Work.Children.Remove(item);
                }
                else
                {
                    int i = sp_Person.Children.IndexOf(item);
                    for (int j = 0; j < count; j++)
                        sp_Person.Children.RemoveAt(i + 1);
                    sp_Person.Children.Remove(item);
                }
                Registration.unit.Tasks.Update(task);
                Registration.unit.Tasks.Remove(task);
                Registration.unit.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
  public static void ToDoSubItem_Add( UIElement item, int id )
        {
            try
            {
                Tasks task = Registration.unit.Tasks.Get(t => t.ID_Task == id).FirstOrDefault();
                Subtasks subtask = new Subtasks
                {
                    TaskID = id,
                    isCheck = false,
                    Subtask_Name = "Название подзадачи" // Задайте конкретное название подзадачи здесь
                };
                Registration.unit.Subtasks.Create(subtask);
                Registration.unit.Save();

                int Id = Registration.unit.Subtasks.Get(s => s.TaskID == id).LastOrDefault().ID_Subtask;
                AddSubTaskItem(Id, Convert.ToBoolean(task.isWork), (ToDoItem)item);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    public static void ToDoSubItem_Delete( UIElement item, int id )
        {
            try
            {
                var subtask = Registration.unit.Subtasks.Get(s => s.ID_Subtask == id).Single();
                Tasks task = Registration.unit.Tasks.Get(t => t.ID_Task == subtask.TaskID).FirstOrDefault();
                Registration.unit.Subtasks.Update(subtask);
                Registration.unit.Subtasks.Remove(subtask);
                Registration.unit.Save();
                if (task.isWork == true)
                {
                    sp_Work.Children.Remove(item);
                }
                else
                {
                    sp_Person.Children.Remove(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btn_Statistics_Click( object sender, RoutedEventArgs e )
        {
            AttachWindow window = new AttachWindow(3, "", user)
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            window.ShowDialog();
        }



    }
}

