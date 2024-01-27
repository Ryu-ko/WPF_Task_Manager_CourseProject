using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using MizuFlow.Model;
using System.Windows.Media.Imaging;
using MizuFlow.pages;
using System.Text;
using System.Collections.Generic;
using System.Net.Mail;


namespace MizuFlow
{
    public partial class MainWindow : Window
    {
        public static User User;

        public MainWindow( User user )
        {
            InitializeComponent();

            User = user;
            ShowAlert();
            MainFrame.Navigate(new MainPage(User));

            var tasks = GetTasksForUser(User);

            StringBuilder alertMessage = new StringBuilder("Информация о дедлайнах:\n");

            foreach (var task in tasks)
            {
                alertMessage.AppendLine($"<br></br> - Задача: {task.Task_Name}, Дедлайн: {Convert.ToDateTime(task.Deadline).ToShortDateString()}");
            }

            SendDeadlineInfoToUser(User.Email, alertMessage.ToString());

        }

        private List<Tasks> GetTasksForUser( User user )
        {
            return Registration.unit.Tasks.Get(t => t.Task_UserID == user.ID_User && t.isCheck != true && t.Deadline <= DateTime.Now).ToList();
        }

        private void SendDeadlineInfoToUser( string userEmail, string message )
        {
     
            string adminEmail = "tanyaandsidney@gmail.com";
            string adminPass = "keqgaxddpiuyctsy";

            var mail = Help.SMTP.CreateMail("MizuFlow", adminEmail, adminEmail, "Дедлайн уже близко!", message);

            Help.SMTP.SendMail("smtp.gmail.com", 587, adminEmail, adminPass, mail);

        }



        private void ShowAlert()
        {
            var tasks = Registration.unit.Tasks.Get(t => t.Task_UserID == User.ID_User && t.isCheck != true && t.Deadline <= DateTime.Now);

            if (tasks.Any())
            {
                StringBuilder alertMessage = new StringBuilder("Просроченные задачи:\n");

                foreach (Tasks t in tasks)
                {
                    if (t.CreationDateTime != null)
                    {
                        alertMessage.AppendLine($"- Задача: {t.Task_Name}, Дедлайн: {Convert.ToDateTime(t.Deadline).ToShortDateString()}");
                    }
                }

                MessageBox.Show(alertMessage.ToString(), "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        //private void Btn_Alert_Click( object sender, RoutedEventArgs e )
        //{
        //    cb_Alert.Items.Clear();
        //    AddAlert();

        //    // Make the ComboBox visible
        //    cb_Alert.Visibility = Visibility.Visible;
        //    cb_Alert.Width = double.NaN; // Use the desired width or set it to double.NaN for automatic width

        //    // Open the dropdown
        //    cb_Alert.IsDropDownOpen = true;
        //}


        //private void AddAlert()
        //{
        //    int count = 0;
        //    var tasks = Registration.unit.Tasks.Get(t => t.Task_UserID == User.ID_User && t.isCheck != true);
        //    foreach (Tasks t in tasks)
        //    {
        //        if (t.CreationDateTime != null)
        //        {
        //            count++;
        //            TextBlock text = new TextBlock { Text = "Task: " + t.Task_Name + "\nDeadline: " + Convert.ToDateTime(t.Deadline).ToShortDateString(), FontSize = 16 };
        //            if (t.Deadline <= DateTime.Now)
        //            {
        //                text.Foreground = Brushes.Red;
        //            }
        //            cb_Alert.Items.Add(text);
        //        }
        //    }

        //}

        private void Cb_Drop_MouseLeave( object sender, System.Windows.Input.MouseEventArgs e )
        {
            ComboBox comboBox = (ComboBox)sender;
            comboBox.IsDropDownOpen = false;
        }

        private void Txt_Search_TextChanged( object sender, TextChangedEventArgs e )
        {
            cb_Search.Items.Clear();
            var tasks = Registration.unit.Tasks.Get(t => t.Task_UserID == User.ID_User);
            Collection<string> taskList = new Collection<string>();

            foreach (Tasks task in tasks)
            {
                taskList.Add(task.Task_Name);
            }

            Regex regex = new Regex(@"(\w*)" + txt_Search.Text + @"(\w*)", RegexOptions.IgnoreCase);

            for (int i = 0; i < taskList.Count; i++)
            {
                Match match = regex.Match(taskList[i]);
                if (match.Success)
                {
                    var item = Registration.unit.Tasks.Get(t => t.Task_Name == taskList[i]).FirstOrDefault();
                    cb_Search.Items.Add(new ToDoItem(item.Task_Name, item.ID_Task) { Width = 450 });
                }
            }
            cb_Search.IsDropDownOpen = true;
        }

        private void Btn_Exit_Click( object sender, RoutedEventArgs e )
        {
            var x = MessageBox.Show("Do you really want to leave?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
            if (x.Equals(MessageBoxResult.Yes))
            {
                Registration registration = new Registration();
                registration.Show();
                MainWindow.GetWindow(this).Close();
            }
        }

        private void Btn_Profile_Click( object sender, RoutedEventArgs e )
        {

            try
            {
                MainFrame.Navigate(new ProfilePage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void Btn_GoMain_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                MainFrame.Navigate(new MainPage(User));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        private void Btn_Group_Click( object sender, RoutedEventArgs e )
        {
            try
            {
                MainFrame.Navigate(new GroupPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
