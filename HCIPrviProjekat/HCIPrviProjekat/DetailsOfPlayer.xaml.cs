using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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

namespace HCIPrviProjekat
{
    /// <summary>
    /// Interaction logic for DetailsOfPlayer.xaml
    /// </summary>
    /// 
  
    public partial class DetailsOfPlayer : Window, INotifyPropertyChanged
    {

        public Player playerInfo;

        private string _selfPicture;
        private string _fullName;
        private string _jerseyNumber;
        private string _basicInfo;
        private string _details;
        public string rtfPath = "C:\\Users\\User\\source\\repos\\HCIPrviProjekat\\HCIPrviProjekat\\bin\\Debug\\rtfs\\";
        public string PlayerName;
        public string Surname;

        public FlowDocument PlayerInformations;



        public string SelfPicture
        {
            get
            {
                return _selfPicture;
            }
            set
            {
                if (_selfPicture != value)
                {
                    _selfPicture = value;
                    OnPropertyChanged("SelfPicture");
                }
            }
        }
        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;
                    OnPropertyChanged("FullName");
                }
            }
        }
        public string JerseyNumber
        {
            get
            {
                return _jerseyNumber;
            }
            set
            {
                if (_jerseyNumber != value)
                {
                    _jerseyNumber = value;
                    OnPropertyChanged("JerseyNumber");
                }
            }
        }
        public string BasicInfo
        {
            get
            {
                return _basicInfo;
            }
            set
            {
                if (_basicInfo != value)
                {
                    _basicInfo = value;
                    OnPropertyChanged("BasicInfo");
                }
            }
        }

        public string Details
        {
            get
            {
                return _details;
            }
            set
            {
                if (_details != value)
                {
                    _details = value;
                    OnPropertyChanged("Details");
                }
            }
        }

        public DetailsOfPlayer()
        {
            InitializeComponent();

            
            DataContext = this;

            playerInfo = AdminMainWindow.selectedPlayer;

            
            SelfPicture = playerInfo.SelfPicture;
            FullName = playerInfo.FullName;

            PlayerName = FullName.Trim().Split(' ')[0];
            Surname = FullName.Trim().Split(' ')[1];

            PlayerInformations = ReadFromRTF();

            RTBlAllInformations.Document = PlayerInformations;

            JerseyNumber = playerInfo.JerseyNumber.ToString();
            BasicInfo = playerInfo.BasicInfo;

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(SelfPicture, UriKind.RelativeOrAbsolute);
            bitmap.EndInit();

            PlayerImage.Source = bitmap;
            //tblFullName.Text = FullName;
            //tblJerseyNumber.Text = JerseyNumber.ToString();
            //tblBasicInformations.Text = playerInfo.BasicInfo;
            

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            AdminMainWindow.adminMainWindow.Show();
            this.Close();
        }

        private FlowDocument ReadFromRTF()
        {
            FlowDocument flowDocument = new FlowDocument();

            try
            {
                using (var stream = File.OpenRead(rtfPath + PlayerName + Surname + ".rtf"))
                {
                    TextRange range = new TextRange(flowDocument.ContentStart, flowDocument.ContentEnd);
                    range.Load(stream, DataFormats.Rtf);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading RTF file: {ex.Message}");
            }

            return flowDocument;
        }
    }
}
