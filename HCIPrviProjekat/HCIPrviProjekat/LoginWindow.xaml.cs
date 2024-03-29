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
using System.Windows.Shapes;

using System.Collections.ObjectModel;
using Notification.Wpf;
using HCIPrviProjekat;

namespace HCIPrviProjekat
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public static LoginWindow loginWindow;
        private NotificationManager notificationManager;
        

        private DataIO serializer = new DataIO();
        public Account LoginAccount;

        public ObservableCollection<Account> Accounts;
        public LoginWindow()
        {
            InitializeComponent();
            loginWindow = this;

            TBUserName.Foreground = Brushes.White;

            notificationManager = new NotificationManager();

            Accounts = serializer.DeSerializeObject<ObservableCollection<Account>>(@"C:\Users\User\source\repos\HCIPrviProjekat\HCIPrviProjekat\XML\UserAdminAccounts.xml");

            //Accounts = new ObservableCollection<Account>();

            //Account accs = new Account("admin", "admin", TypeAccount.Admin);
            //Accounts.Add(accs);
            
            //Account accss = new Account("user", "user", TypeAccount.Visitor);
            //Accounts.Add(accss);
            //serializer.SerializeObject<ObservableCollection<Account>>(Accounts, "UserAdminAccounts.xml");

            if (Accounts == null)
            {
               // Console.WriteLine("NEMA NICEGAAAAAA");
            }
            //else
            //{
            //    foreach (Account acc in Accounts)
            //    {
            //        Console.WriteLine(acc.Username + " " + acc.Password + "");
            //    }
            //}

            TBUserName.Text = "Username";
            TBUserName.Foreground = Brushes.LightSlateGray;
            
        }

       private void ShowToastNotification(ToastNotification toastNotification)
        {
            notificationManager.Show(toastNotification.Title, toastNotification.Message, toastNotification.Type, "WindowNotificationArea");
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
           
            if (ValidateUsernameAndPassword())
            {
                if (ExistanceUserAndAdmin())
                {

                   
                    AdminMainWindow adminMainWindow = new AdminMainWindow();
                    adminMainWindow.Show();
                    adminMainWindow.ShowToastNotification(new ToastNotification("Success", "Successfully logged into account!", NotificationType.Success));
                    this.Hide();
                    

                    TBPassword.Password = string.Empty;
                    TBUserName.Text = string.Empty;

                    TBUserName.Text = "Username";
                    TBUserName.Foreground = Brushes.LightSlateGray;

                    TextBlockPassword.Text = "Password";
                    TextBlockPassword.Foreground = Brushes.LightSlateGray;

                }
                else
                {

                }
            }
        }

        private bool ValidateUsernameAndPassword()
        {
            bool isValid = true;
           

            if(TBUserName.Text.Trim().Equals(string.Empty) || TBUserName.Text.Trim().Equals("Username"))
            {
                isValid = false;
                lbErrorUsername.Content = "Username field cannot be left empty!";
                TBUserName.BorderBrush = Brushes.Red;
            }
            else
            {
                lbErrorUsername.Content = string.Empty;
                TBUserName.BorderBrush = Brushes.LightSlateGray;
            }

            if (TBPassword.Password.Trim().Equals(string.Empty))
            {
                isValid = false;
                lbErrorPassword.Content = "Password field cannot be left empty!";
                TBPassword.BorderBrush = Brushes.Red;
            }
            else
            {
                lbErrorPassword.Content = string.Empty;
                TBPassword.BorderBrush = Brushes.LightSlateGray;
            }
            
            return isValid;
        }

        private bool ExistanceUserAndAdmin()
        {

            bool isValid = true;
            bool exists = false;
            bool validUsername = false;

            Account loginAcc = new Account(TBUserName.Text, TBPassword.Password, TypeAccount.Visitor);
           
            foreach (Account acc in Accounts)
            {
               

                if (loginAcc.Username.Equals(acc.Username))
                {
                    validUsername = true;
                }

                if (loginAcc.Username.Equals(acc.Username) && loginAcc.Password.Equals(acc.Password))
                {
                    //Console.WriteLine(acc.Password + " " + LoginAccount.Password);
                    exists = true;
                    LoginAccount = acc;

                    break;
                }
            }

            if (exists)
            {
                isValid = true;
            }
            else if (!validUsername)
            {
                lbErrorUsername.Content = "Invalid Username. Please try again";
                lbErrorPassword.Content = "Invalid Password. Please try again";
                isValid = false;
            }
            else
            {
                lbErrorPassword.Content = "Invalid Password. Please try again";
                isValid = false;
            }
            return isValid;
        }

        private void TBUserName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TBUserName.Text.Trim().Equals("Username"))
            {
                TBUserName.Text = "";
                TBUserName.Foreground = Brushes.White;
            }
        }

        private void TBUserName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TBUserName.Text.Trim().Equals(string.Empty))
            {
                TBUserName.Text = "Username";
                TBUserName.Foreground = Brushes.LightSlateGray;
               
            }
        }

        


        private void Window_Closing_1(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {

            }
            else
            {
                e.Cancel = true;
            }
        }

        private void TBPassword_GotFocus(object sender, RoutedEventArgs e)
        {
           
            TextBlockPassword.Text = string.Empty;
        }

        private void TBPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TBPassword.Password.Trim().Equals(string.Empty))
            {
                TextBlockPassword.Text = "Password";
            }
        }

        private void TextBlockPassword_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TBPassword.Focus();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
