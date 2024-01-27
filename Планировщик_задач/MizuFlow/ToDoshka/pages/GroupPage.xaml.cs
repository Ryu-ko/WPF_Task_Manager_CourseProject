using MizuFlow.model;
using MizuFlow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MizuFlow.pages;


namespace MizuFlow.pages
{

    public partial class GroupPage : Page
    {

        private Task_Group selectedGroup;
        public GroupPage()
        {
            InitializeComponent();
            ShowGroups();
        }

        private void TreeViewGroups_MouseRightButtonUp( object sender, MouseButtonEventArgs e )
        {
            TreeViewItem treeViewItem = GetTreeViewItemClicked(e.OriginalSource as DependencyObject);
            if (treeViewItem != null)
            {
                selectedGroup = treeViewItem.DataContext as Task_Group;
            }
            else
            {
                selectedGroup = null;
            }
        }



        private TreeViewItem GetTreeViewItemClicked( DependencyObject source )
        {
            while (source != null && !(source is TreeViewItem))
            {
                source = VisualTreeHelper.GetParent(source);
            }
            return source as TreeViewItem;
        }
        private void MenuItem_AddTaskToGroup_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                if (selectedGroup != null)
                {
                    // Откройте окно или панель для выбора задачи
                    SelectTaskWindow selectTaskWindow = new SelectTaskWindow();
                    if (selectTaskWindow.ShowDialog() == true)
                    {
                        // Получите выбранную задачу
                        Tasks selectedTask = selectTaskWindow.SelectedTask;

                        // Добавьте задачу к выбранной группе
                        selectedGroup.Tasks.Add(selectedTask);

                        // Сохраните изменения в базе данных
                        Registration.unit.Save();

                        // Обновите TreeView
                        ShowGroups();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        public void ShowGroups()
        {
            // Очистите существующие элементы управления для предотвращения дублирования
            //treeViewGroups.Items.Clear();

            try
            {
                // Получите все группы из базы данных
                var groups = Registration.unit.TaskGroup.Get().ToList();

                foreach (var group in groups)
                {
                    // Создайте элемент управления (например, TreeViewItem) для отображения группы
                    TreeViewItem groupItem = new TreeViewItem
                    {
                        Header = group.Group_Name
                        // Добавьте другие свойства или события, если это необходимо
                    };

                    // Добавьте этот элемент в ваш TreeView
                    treeViewGroups.Items.Add(groupItem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Btn_AddGroup_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                // Создаем новую группу
                Task_Group newGroup = new Task_Group
                {
                    Group_Name = txt_AddGroup.Text
                };

                // Добавляем группу в базу данных
                Registration.unit.TaskGroup.Create(newGroup);
                Registration.unit.Save();

                // Создаем новый узел в TreeView для отображения группы
                TreeViewItem groupNode = new TreeViewItem
                {
                    Header = newGroup.Group_Name
                };

                // Добавляем узел группы в TreeView
                treeViewGroups.Items.Add(groupNode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //private void Btn_AddTaskToGroup_Click( object sender, RoutedEventArgs e )
        //{
        //    try
        //    {
        //        // Получите выбранную группу
        //        TreeViewItem selectedGroupItem = treeViewGroups.SelectedItem as TreeViewItem;
        //        Task_Group selectedGroup = selectedGroupItem?.DataContext as Task_Group;

        //        if (selectedGroup != null)
        //        {
        //            // Откройте окно или панель для выбора задачи
        //            // Здесь предполагается, что у вас есть метод для выбора задачи

        //            // Пример:
        //            SelectTaskWindow selectTaskWindow = new SelectTaskWindow();
        //            if (selectTaskWindow.ShowDialog() == true)
        //            {
        //                // Получите выбранную задачу
        //                Tasks selectedTask = selectTaskWindow.SelectedTask;

        //                // Добавьте задачу к выбранной группе
        //                selectedGroup.Tasks.Add(selectedTask);

        //                // Сохраните изменения в базе данных
        //                Registration.unit.Save();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}



    }
}
