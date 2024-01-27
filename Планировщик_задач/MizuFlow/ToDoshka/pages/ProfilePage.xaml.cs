using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using MizuFlow.Model;
using System.Text.RegularExpressions;


namespace MizuFlow
{
    public partial class ProfilePage : Page
    {
        User user = new User();
        Task_Attachments attach = new Task_Attachments();
        public ProfilePage()
        {
            InitializeComponent();

            user = MainWindow.User;
            FillInfo();
            CheckAttach();
            List<string> langs = new List<string> { "English", "Russian" };
            cb_Langs.SelectionChanged += SelectLangs;
            cb_Langs.ItemsSource = langs;
   
        }

        private void FillInfo()
        {
            UserName.Content = user.User_Surname + " " + user.User_Name;
            if (user.Description != null)
            {
                ProfLoc.Content= user.Description;
                tb_Desc.Text = user.Description;
            }
            lbl_Email.Text = user.Email;
            if (user.Phone != null)
            {

                lbl_Phone.Text = user.Phone;
            }
            if (user.Contact != null)
            {
                lbl_Contacts.Text = user.Contact;
            }
        }

        private void Btn_EditPhone_Click(object sender, RoutedEventArgs e)
        {
            string pattern = @"^(\+375|80)(29|25|44|33|17)([0-9]{3}([0-9]{2}){2})$";
            Regex reg = new Regex(pattern);
            if (checkPhone)
            {

                lbl_Phone.IsReadOnly = false;
                btn_EditPhone.BorderBrush = Brushes.White;
                checkPhone = false;
            }
            else
            {
                Match match = reg.Match(lbl_Phone.Text);
                if (!match.Success)
                {
                    MessageBox.Show("Invalid data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    user.Phone = lbl_Phone.Text;
                    Registration.unit.Users.Update(user);
                    Registration.unit.Save();
                    lbl_Phone.IsReadOnly = true;
                    btn_EditPhone.BorderBrush = Brushes.Transparent;
                    checkPhone = true;
                }
            }
        }

        bool checkContact = true;
        private void Btn_EditContact_Click(object sender, RoutedEventArgs e)
        {
            if (checkContact)
            {
                lbl_Contacts.IsReadOnly = false;
                btn_EditContact.BorderBrush = Brushes.White;
                checkContact = false;
            }
            else
            {
                user.Contact = lbl_Contacts.Text;
                Registration.unit.Users.Update(user);
                Registration.unit.Save();
                lbl_Contacts.IsReadOnly = true;
                btn_EditContact.BorderBrush = Brushes.Transparent;
                checkContact = true;
            }
        }

        private void SelectLangs(object sender, SelectionChangedEventArgs e)
        {
            string lang = cb_Langs.SelectedItem as string;
            Uri uri = null;
            switch (lang)
            {
                case "English":
                    {
                        uri = new Uri("resources/langs/lang_EN.xaml", UriKind.Relative);
                        break;
                    }
                case "Russian":
                    {
                        uri = new Uri("resources/langs/lang_RU.xaml", UriKind.Relative);
                        break;
                    }
            }
            
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);

 
        }

        private byte[] _imageBytes = null;

        //---------------------------------------------------------------------------------------------------------------------------------

        private void Btn_UploadPhoto_Click( object sender, RoutedEventArgs e )
        {
            var dialog = new OpenFileDialog
            {
                CheckFileExists = true,
                Multiselect = false,
                Filter = "Images (*.jpg,*.png)|*.jpg;*.png|All Files(*.*)|*.*"
            };
            if (dialog.ShowDialog() != true) { return; }

            lbl_PhotoPath.Content = dialog.FileName;
            img_ProfilePhoto.ImageSource = new BitmapImage(new Uri(lbl_PhotoPath.Content.ToString()));

            using (var fs = new FileStream(lbl_PhotoPath.Content.ToString(), FileMode.Open, FileAccess.Read))
            {
                _imageBytes = new byte[fs.Length];
                fs.Read(_imageBytes, 0, System.Convert.ToInt32(fs.Length));
            }

            // Обновляем attach перед сохранением
            attach = Registration.unit.Attachments.Get(a => a.TA_UserID == user.ID_User).FirstOrDefault();
            SaveImage();
        }

        private void SaveImage()
        {
            if (!String.IsNullOrEmpty(lbl_PhotoPath.Content.ToString()) && attach != null)
            {
                attach.ImagePath = lbl_PhotoPath.Content.ToString();
                attach.Image = _imageBytes;
                Registration.unit.Attachments.Update(attach);
                Registration.unit.Save();
            }
        }


        //---------------------------------------------------------------------------------------------------------------------------------

        private void LoadImage()
        {
            
            try
            {
                attach = Registration.unit.Attachments.Get(a => a.TA_UserID == user.ID_User).FirstOrDefault();
                if (attach != null && attach.Image != null && attach.ImagePath != null)
                {
                    img_ProfilePhoto.ImageSource = new BitmapImage(new Uri(attach.ImagePath));
                }
            }
            catch
            {
                MessageBox.Show("Photo path " + attach.ImagePath + " is not found");
            }
        }

        private void Btn_ChangeDesc_Click(object sender, RoutedEventArgs e)
        {
            ProfLoc.Content = tb_Desc.Text;
            user.Description = tb_Desc.Text;
            Registration.unit.Users.Update(user);
            Registration.unit.Save();
        }

        bool checkEmail = true;
        private void Btn_EditEmail_Click(object sender, RoutedEventArgs e)
        {
            if (checkEmail)
            {
                lbl_Email.IsReadOnly = false;
                btn_EditEmail.BorderBrush = Brushes.White;
                checkEmail = false;
            }
            else
            {
                user.Email = lbl_Email.Text;
                Registration.unit.Users.Update(user);
                Registration.unit.Save();
                lbl_Email.IsReadOnly = true;
                btn_EditEmail.BorderBrush = Brushes.Transparent;
                checkEmail = true;
            }
        }
        private void CheckAttach()
        {
            if (Registration.unit.Attachments.Get(a => a.TA_UserID == user.ID_User && a.TA_TaskID == null).Count() != 0)
            {
                attach = Registration.unit.Attachments.Get(a => a.TA_UserID == user.ID_User).FirstOrDefault();
                LoadImage();
            }
            else
            {
                attach.TA_UserID = user.ID_User;
                Registration.unit.Attachments.Create(attach);
                Registration.unit.Save();
            }
        }
        bool checkPhone = true;

    }
}