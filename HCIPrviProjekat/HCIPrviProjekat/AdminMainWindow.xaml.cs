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
using System.Collections.ObjectModel;
using Notification.Wpf;
using HCIPrviProjekat;
using System.ComponentModel;
using System.IO;

namespace HCIPrviProjekat
{
    /// <summary>
    /// Interaction logic for AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window,INotifyPropertyChanged
    {

        public  ObservableCollection<Player> Players;

        public static AdminMainWindow adminMainWindow;

        public static Player selectedPlayer;
        public Account UserAccount;
        public bool isAddButton;
        private bool _isReadOnlyDataGrid;

        public bool IsReadOnlyDataGrid
        {
            get { return _isReadOnlyDataGrid; }
            set
            {
                if(_isReadOnlyDataGrid != value)
                {
                    _isReadOnlyDataGrid = value;
                    OnPropertyChanged("IsReadOnlyDataGrid");
                }
            }
        }




        public NotificationManager notificationManager;
        

        private DataIO serializer = new DataIO();

        public event PropertyChangedEventHandler PropertyChanged;

        public AdminMainWindow()
        {
            InitializeComponent();

            

            UserAccount = LoginWindow.loginWindow.LoginAccount;
            if(UserAccount.AccType == TypeAccount.Visitor)
            {
                BtnAdd.Visibility = Visibility.Hidden;
                BtnEdit.Visibility = Visibility.Hidden;
                BtnDelete.Visibility = Visibility.Hidden;
                CheckBoxDataGrid.Visibility = Visibility.Hidden;
                
            }
            isAddButton = false;

            ChangeEditDataGrid();


            DataContext = this;

            adminMainWindow = this;

            notificationManager = new NotificationManager();

            Players = serializer.DeSerializeObject<ObservableCollection<Player>>(@"C:\Users\User\source\repos\HCIPrviProjekat\HCIPrviProjekat\XML\Players.xml");

            if(Players == null)
            {
                Players = new ObservableCollection<Player>();
            }

            PlayersDataGrid.ItemsSource = Players;

            selectedPlayer = null;

        }

        private void ChangeEditDataGrid()
        {
            if(UserAccount.AccType == TypeAccount.Admin)
            {
                IsReadOnlyDataGrid = false;
            }
            else
            {
                IsReadOnlyDataGrid = true;
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void ShowToastNotification(ToastNotification toastNotification)
        {
            notificationManager.Show(toastNotification.Title, toastNotification.Message, toastNotification.Type, "WindowNotificationAreaAdmin");
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            isAddButton = true;
            AddEditPlayer aep = new AddEditPlayer();
            this.Hide();
            aep.Show();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (selectedPlayer != null)
            {
                isAddButton = false;
                AddEditPlayer aep = new AddEditPlayer();
                this.Hide();
                aep.Show();
            }
            else
            {
                adminMainWindow.ShowToastNotification(new ToastNotification("Error", "Please select player to edit", NotificationType.Error));
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {

                int count = 0;
                foreach(Player p in Players)
                {
                    if (p.IsChecked)
                    {
                        count++;
                    }
                }

                if(count == 0)
                {
                    adminMainWindow.ShowToastNotification(new ToastNotification("Error", "Please check player to delete", NotificationType.Error));
                }

                List<Player> TempPlayers = Players.ToList();
                foreach(Player ap in TempPlayers)
                {
                    if (ap.IsChecked)
                    {
                        this.Players.Remove(ap);
                    
                        string filePath = "C:\\Users\\User\\source\\repos\\HCIPrviProjekat\\HCIPrviProjekat\\bin\\Debug\\rtfs\\" + ap.FullName.Trim().Split(' ')[0] + ap.FullName.Trim().Split(' ')[1] + ".rtf";
                        if (File.Exists(filePath))
                        {
                        
                            File.Delete(filePath);
                        
                        }
                    }
                }
            }
            

        }

        private void BtnLogOut_Click(object sender, RoutedEventArgs e)
        {
            foreach (Player ap in Players)
            {
                ap.IsChecked = false;
            }


            LoginWindow loginWindow = LoginWindow.loginWindow;
            this.Close();
            loginWindow.Show();
            serializer.SerializeObject<ObservableCollection<Player>>(Players, @"C:\Users\User\source\repos\HCIPrviProjekat\HCIPrviProjekat\XML\Players.xml");
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            if (UserAccount.AccType == TypeAccount.Admin)
            {

                AddEditPlayer aep = new AddEditPlayer();
                aep.Show();
                this.Hide();
            }else if(UserAccount.AccType == TypeAccount.Visitor)
            {
                DetailsOfPlayer dop = new DetailsOfPlayer();
                dop.Show();
                this.Hide();
            }

        }

        private void PlayersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(PlayersDataGrid.SelectedIndex.ToString());
            try
            {
                selectedPlayer = (Player)PlayersDataGrid.SelectedItem;
            }
            catch
            {
                selectedPlayer = null;
            }

        }
    }
}
