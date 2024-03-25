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
using System.Diagnostics;

namespace HCIPrviProjekat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class UserMainWindow : Window
    {

        private NotificationManager notificationManager;

        public ObservableCollection<Player> Players;

        private DataIO serializer = new DataIO();

        //public Uri DetailsLink;

        public static Player playerToShow;

        public static UserMainWindow thisWindow;

        public UserMainWindow()
        {
            InitializeComponent();

            thisWindow = this;

            DataContext = this;

           // DetailsLink = new Uri("DetailsOfPlayer.xaml", UriKind.RelativeOrAbsolute);

            notificationManager = new NotificationManager();

           

            Players = serializer.DeSerializeObject<ObservableCollection<Player>>(@"C:\Users\User\source\repos\HCIPrviProjekat\HCIPrviProjekat\XML\Players.xml");

            PlayersDataGrid.ItemsSource = Players;

            //Player ply = new Player("Milos Teodosic", "C:\\Users\\User\\source\\repos\\HCIPrviProjekat\\HCIPrviProjekat\\bin\\Debug\\Images\\MilosTeodosic.jpeg", 4, new DateTime(1987, 03, 21));

            //Players = new ObservableCollection<Player>();
            //Players.Add(ply);
            //Player plys = new Player("Milossssssssssssss Teodosicccccccccccccccc", "C:\\Users\\User\\source\\repos\\HCIPrviProjekat\\HCIPrviProjekat\\bin\\Debug\\Images\\MilosTeodosic.jpeg", 42, new DateTime(1987, 03, 21));
            //Players.Add(plys);
            //serializer.SerializeObject<ObservableCollection<Player>>(Players, @"C:\Users\User\source\repos\HCIPrviProjekat\HCIPrviProjekat\XML\Players.xml");
            foreach (Player pl in Players)
            {
                Console.WriteLine(pl.FullName);
            }

            

        }

        public void ShowToastNotification(ToastNotification toastNotification)
        {
            notificationManager.Show(toastNotification.Title, toastNotification.Message, toastNotification.Type, "WindowNotificationAreaUser");
        }

        private void BtnLogOut_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = LoginWindow.loginWindow;
            this.Close();
            loginWindow.Show();
            
        }

        private void PlayersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            playerToShow = (Player)PlayersDataGrid.SelectedItem;
        }

        private void PlayersDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DetailsOfPlayer dop = new DetailsOfPlayer();
            dop.Show();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            DetailsOfPlayer dop = new DetailsOfPlayer();
            dop.Show();
        }
    }
}
