using Microsoft.Win32;
using Notification.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HCIPrviProjekat
{
    /// <summary>
    /// Interaction logic for AddEditPlayer.xaml
    /// </summary>
    public partial class AddEditPlayer : Window,INotifyPropertyChanged
    {

        public Player playerInfo;

        private string _selfPicture;
        private string _name;
        private string _surname;
        private string _jerseyNumber;
        private string _basicInfo;
        private FlowDocument _details;
        private Color _selectedColor;
        private int _numberOfWords;

        public string rtfPath  = "C:\\Users\\User\\source\\repos\\HCIPrviProjekat\\HCIPrviProjekat\\bin\\Debug\\rtfs\\" ;


        public string FullName;

        public List<double> FontSizes;

        public NotificationManager notificationManager;



        public int NumberOfWords
        {
            get
            {
                return _numberOfWords;
            }
            set
            {
                if (_numberOfWords != value)
                {
                    _numberOfWords = value;
                    OnPropertyChanged("NumberOfWords");
                }
            }
        }

        public Color SelectedColor
        {
            get
            {
                return _selectedColor;
            }
            set
            {
                if (_selectedColor != value)
                {
                    _selectedColor = value;
                    OnPropertyChanged("SelectedColor");
                }
            }
        }

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
        public string PlayerName
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("PlayerName");
                }
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                if (_surname != value)
                {
                    _surname = value;
                    OnPropertyChanged("Surname");
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

        public FlowDocument Details
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


        public AddEditPlayer()
        {
            InitializeComponent();

            DataContext = this;
            
            SelfPicture = string.Empty;


            notificationManager = new NotificationManager();


            //RTBBasicInfoEdit.Document = BasicInfo;
            //RTBDetails.Document = Details;


            FontSizes = new List<double>();
            double[] lista  = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (double i in lista) {
                FontSizes.Add(i);
            }

            SelectedColor = Color.FromRgb(Brushes.Black.Color.R, Brushes.Black.Color.G, Brushes.Black.Color.B);

            FontFamilyComboBox.ItemsSource = Fonts.SystemFontFamilies;
            FontSizeComboBox.ItemsSource = FontSizes;

            FlowDocument fd = new FlowDocument();
            

            RTBDetails.Document = fd;

            NumberOfWords = 0;
            WordsNumber.Text = NumberOfWords.ToString();

            AdminMainWindow adminWindow = AdminMainWindow.adminMainWindow;
            playerInfo = AdminMainWindow.selectedPlayer;
            if(!adminWindow.isAddButton)
            {
                SelfPicture = playerInfo.SelfPicture;
                FullName = playerInfo.FullName;
                PlayerName = FullName.Trim().Split(' ')[0];
                
                Surname = FullName.Trim().Split(' ')[1];
               

                JerseyNumber = playerInfo.JerseyNumber.ToString();
                BasicInfo = playerInfo.BasicInfo;

                
                RTBDetails.Document = ReadFromRTF();


                WordCounter(RTBDetails.Document);




                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(SelfPicture, UriKind.RelativeOrAbsolute);
                bitmap.EndInit();
                
                PlayerImage.Source = bitmap;
            }

        }


        private void ShowToastNotification(ToastNotification toastNotification)
        {
            notificationManager.Show(toastNotification.Title, toastNotification.Message, toastNotification.Type, "WindowNotificationAreaAdd");
        }


        public event PropertyChangedEventHandler PropertyChanged;


        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        

        private void btnAddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                //PlayerImage.Source = new BitmapImage(new Uri(op.FileName));
                SelfPicture = new Uri(op.FileName).ToString();

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(SelfPicture, UriKind.RelativeOrAbsolute);
                bitmap.EndInit();
                
                PlayerImage.Source = bitmap;
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            AdminMainWindow.adminMainWindow.isAddButton = false;
            AdminMainWindow.adminMainWindow.Show();
            this.Close();
        }

        private void FontFamilyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(FontFamilyComboBox.SelectedItem != null && !RTBDetails.Selection.IsEmpty)
            {
                RTBDetails.Selection.ApplyPropertyValue(Inline.FontFamilyProperty,FontFamilyComboBox.SelectedItem);
            }
        }

        private void RTBDetails_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object fontBold = RTBDetails.Selection.GetPropertyValue(Inline.FontWeightProperty);
            BoldToggleButton.IsChecked = (fontBold != DependencyProperty.UnsetValue) && (fontBold.Equals(FontWeights.Bold));

            object fontItalic = RTBDetails.Selection.GetPropertyValue(Inline.FontStyleProperty);
            ItalicToggleButton.IsChecked = (fontItalic != DependencyProperty.UnsetValue) && (fontItalic.Equals(FontStyles.Italic));

            object fontUnderline = RTBDetails.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            UnderlineToggleButton.IsChecked = (fontUnderline != DependencyProperty.UnsetValue) && (fontUnderline.Equals(TextDecorations.Underline));

            object textColor = RTBDetails.Selection.GetPropertyValue(Inline.ForegroundProperty);
            if (textColor != DependencyProperty.UnsetValue && textColor is SolidColorBrush)
            {
                SolidColorBrush brush = (SolidColorBrush)textColor;
                SelectedColor = brush.Color;
            }
            else
            {
               
                SelectedColor = Colors.Black;
            }

            object fontSize = RTBDetails.Selection.GetPropertyValue(Inline.FontSizeProperty);
            
            if(fontSize != DependencyProperty.UnsetValue && fontSize is double){
                double selectedFontSize = (double)fontSize;
                if (FontSizes.Contains(selectedFontSize))
                {
                    FontSizeComboBox.SelectedItem = selectedFontSize;
                }
                else
                {
                    // Ako veličina fonta nije prisutna, možete dodati novu stavku u ComboBox
                    FontSizes.Add(selectedFontSize);
                    FontSizeComboBox.SelectedItem = selectedFontSize;
                }
            }

            object fontFamily = RTBDetails.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            FontFamilyComboBox.SelectedItem = fontFamily;

            WordCounter(RTBDetails.Document);

        }

        private void ColorSelection_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if(ColorSelection.SelectedColor != null && !RTBDetails.Selection.IsEmpty)
            {
                Color selectedColor = ColorSelection.SelectedColor.Value;

                // Formatiranje boje u RTF format (hexadecimalna vrednost)
                string rtfColor = string.Format("\\red{0}\\green{1}\\blue{2};", selectedColor.R, selectedColor.G, selectedColor.B);

                // Kreiranje Run objekta sa novim stilom (bojom)
                Run run = new Run();
                run.Text = RTBDetails.Selection.Text;
                run.Foreground = new SolidColorBrush(selectedColor);
                RTBDetails.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, run.Foreground);
            }
        }

        private void FontSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FontSizeComboBox.SelectedItem != null && !RTBDetails.Selection.IsEmpty)
            {
                RTBDetails.Selection.ApplyPropertyValue(Inline.FontSizeProperty, FontSizeComboBox.SelectedItem);
            }
        }

        private void RTBDetails_TextChanged(object sender, TextChangedEventArgs e)
        {
           
            WordCounter(RTBDetails.Document);
        }

        private void RTBDetails_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            

           WordCounter(RTBDetails.Document);
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInputData())
            {
                //try
                //{
                    int num = Int32.Parse(tbPlayerJerseyNumEdit.Text);
                    //lbErrorJerseyNumber.Text = string.Empty;
                    //tbPlayerJerseyNumEdit.BorderBrush = Brushes.LightSlateGray;
                    string fName = PlayerName + " " + Surname;

                    //WriteToRTF();
                    string fullPath = rtfPath + PlayerName + Surname + ".rtf";
                string firstName = "";
                string firstSurname = "";
                string firstfullPath = "";
                bool isAdd = AdminMainWindow.adminMainWindow.isAddButton;

                bool isValid = true;


                    Player player = new Player(fName, SelfPicture, num, DateOfBirthExtraction(), BasicInfo, fullPath);

                    List<Player> TempPlayers = AdminMainWindow.adminMainWindow.Players.ToList();

                    if (!AdminMainWindow.adminMainWindow.isAddButton) //ako je edit onda ovo
                    {

                     firstName = playerInfo.FullName.Trim().Split(' ')[0];
                     firstSurname = playerInfo.FullName.Trim().Split(' ')[1];
                     firstfullPath = rtfPath + firstName + firstSurname + ".rtf";
                    int cnt = 0;
                       // player.BirthDate = DateOfBirthExtraction();
                        foreach (Player pl in TempPlayers)
                        {
                            
                            if (pl.FullName.Equals(player.FullName) || pl.JerseyNumber == player.JerseyNumber)
                            {
                                cnt++;
                                
                            }
                        }

                        if (cnt == 1)
                        {
                            if (DateOfBirthExtraction() == new DateTime(1900, 1, 1))
                            {
                                this.ShowToastNotification(new ToastNotification("Information", "You need to write Date of Birth in BasicInfo field! FORMAT: (Datum rođenja: DD.MM.YYYY.)!", NotificationType.Information));
                            }
                            else
                            {
                                foreach (Player pl in TempPlayers)
                                {
                                    int index = AdminMainWindow.adminMainWindow.Players.IndexOf(pl);

                                    if (pl.FullName.Equals(player.FullName) || pl.JerseyNumber == player.JerseyNumber)
                                    {
                                        player.ObjectCreationDate = pl.ObjectCreationDate;

                                        AdminMainWindow.adminMainWindow.Players.Remove(pl);

                                        AdminMainWindow.adminMainWindow.Players.Insert(index, player);

                                    }
                                }
                            }
                        }
                        else
                        {
                            this.ShowToastNotification(new ToastNotification("Error", "Pay attention not to overlap FullName of player or Jersey Number!", NotificationType.Error));
                            isValid = false;
                        }

                    }
                    else
                    {
                        bool addValid = true;

                    {
                        foreach (Player pl in TempPlayers)
                        {

                            if (pl.FullName.Equals(player.FullName) || pl.JerseyNumber == player.JerseyNumber)
                            {
                                addValid = false;
                                isValid = false;
                            }
                        }
                        if (addValid)
                        {



                            AdminMainWindow.adminMainWindow.isAddButton = false;

                            AdminMainWindow.adminMainWindow.Players.Add(player);
                            


                        }
                        else
                        {
                            this.ShowToastNotification(new ToastNotification("Error", "Pay attention not to overlap FullName of player or Jersey Number!", NotificationType.Error));
                        }
                    }
                    }

                    if (isValid)
                    {

                    if (!isAdd)
                    {

                        if (firstName != player.FullName.Trim().Split(' ')[0] || firstSurname != player.FullName.Trim().Split(' ')[1])
                        {

                            Console.WriteLine("BRISIIII");

                            File.Delete(firstfullPath);


                        }
                    }
                    WriteToRTF(player.FullName.Trim().Split(' ')[0], player.FullName.Trim().Split(' ')[1]);

                    AdminMainWindow.adminMainWindow.Show();
                        AdminMainWindow.adminMainWindow.ShowToastNotification(new ToastNotification("Success", "Your change has completed successfully", NotificationType.Success));
                        this.Close();
                    }

                    
                //}
                //catch (Exception exc)
                //{
                //    Console.WriteLine(exc.Message);
                //    lbErrorJerseyNumber.Content = "Please enter just numbers!";
                //    tbPlayerJerseyNumEdit.BorderBrush = Brushes.Red;
                //}
            }
        }

        private bool ValidateInputData()
        {
            bool isValid = true;
            try
            {

               
                if (tbPlayerNameEdit.Text.Trim().Equals(string.Empty))
                {
                    isValid = false;
                    lbErrorName.Content = "Name field cannot be left empty!";
                    tbPlayerNameEdit.BorderBrush = Brushes.Red;

                }
                else
                {
                    lbErrorName.Content = string.Empty;
                    tbPlayerNameEdit.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#04273a"));
                }

                if (tbPlayerSurnameEdit.Text.Trim().Equals(string.Empty))
                {
                    isValid = false;
                    lbErrorSurname.Content = "Surname field cannot be left empty!";
                    tbPlayerSurnameEdit.BorderBrush = Brushes.Red;
                }
                else
                {
                    lbErrorSurname.Content = string.Empty;
                    tbPlayerSurnameEdit.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#04273a"));
                }

               

                if (TBBasicInfoEdit.Text.Trim().Equals(string.Empty))
                {
                    isValid = false;
                    lbErrorBasicInfo.Content = "BasicInfo field cannot be left empty!";
                    TBBasicInfoEdit.BorderBrush = Brushes.Red;
                }
                else
                {
                    lbErrorBasicInfo.Content = string.Empty;
                    TBBasicInfoEdit.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#04273a"));
                }

                if (tbPlayerJerseyNumEdit.Text.Trim().Equals(string.Empty))
                {
                    isValid = false;
                    lbErrorJerseyNumber.Text = "JerseyNumber field cannot be left empty!";
                    tbPlayerJerseyNumEdit.BorderBrush = Brushes.Red;
                }
                else
                {
                    lbErrorJerseyNumber.Text = string.Empty;
                    tbPlayerJerseyNumEdit.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#04273a"));
                }

                if (SelfPicture != string.Empty)
                {
                    lbImageError.Content = string.Empty;
                    RectangleImage.Visibility = Visibility.Hidden;

                }
                else
                {
                    isValid = false;
                    lbImageError.Content = "PlayerImage field cannot be left empty";
                    RectangleImage.Visibility = Visibility.Visible;

                }


                

                if (RTBDetails.Document.Blocks.Count == 0)
                {
                    isValid = false;
                    lbInformationError.Content = "Information field cannot be left empty";
                    RTBDetails.BorderBrush = Brushes.Red;

                }
                else
                {
                    lbInformationError.Content = string.Empty;
                    RTBDetails.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ac7725")); 
                }

                int num = Int32.Parse(tbPlayerJerseyNumEdit.Text);

                if(num < 0)
                {
                    isValid = false;
                    lbErrorJerseyNumber.Text = "JerseyNumber must be positive!";
                    tbPlayerJerseyNumEdit.BorderBrush = Brushes.Red;
                }
                else
                {
                    lbErrorJerseyNumber.Text = string.Empty;
                    tbPlayerJerseyNumEdit.BorderBrush = Brushes.LightSlateGray;
                    
                }

                if ((DateOfBirthExtraction() == new DateTime(1900, 1, 1)))
                {
                    this.ShowToastNotification(new ToastNotification("Information", "You need to write Date of Birth in BasicInfo field! FORMAT: (Datum rođenja: DD.MM.YYYY.)!", NotificationType.Information));
                    isValid = false;
                    Console.WriteLine(new DateTime(1900, 1, 1).ToString());
                   
                }
               

                TextRange txtRange = new TextRange(RTBDetails.Document.ContentStart, RTBDetails.Document.ContentEnd);
                string txt = txtRange.Text;

                if(RTBDetails.Document == null)
                {
                    isValid = false;
                    lbInformationError.Content = "Information field cannot be left empty";
                    lbInformationError.BorderBrush = Brushes.Red;
                    
                }
                else
                {
                    lbInformationError.Content = string.Empty;
                    lbInformationError.BorderBrush = Brushes.LightSlateGray;
                }

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                lbErrorJerseyNumber.Text = "Please enter just numbers!";
                tbPlayerJerseyNumEdit.BorderBrush = Brushes.Red;
                isValid = false;
            }

            return isValid;
        }

        private void WriteToRTF(string name,string surname)
        {
            TextRange range = new TextRange(RTBDetails.Document.ContentStart, RTBDetails.Document.ContentEnd);
            using (var stream = System.IO.File.Create(rtfPath + name + surname + ".rtf"))
            {
                range.Save(stream, DataFormats.Rtf);
            }
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

       private DateTime DateOfBirthExtraction()
        {
            try
            {

                string[] line = TBBasicInfoEdit.Text.Split('\n');

                string[] dvotacka = line[0].Split(':');

                //string[] samoDatum = dvotacka[1].Trim().Split(' ');

                string[] datum = dvotacka[1].Trim().Split('.');

                for(int i = 0; i < 3; i++)
                {
                    datum[i] = datum[i].Trim();
                }

                Console.WriteLine(datum[0] + datum[1] + datum[2]);

                return new DateTime(Int32.Parse(datum[2]), Int32.Parse(datum[1]), Int32.Parse(datum[0]));
            }
            catch(Exception excep)
            {
                Console.WriteLine(excep.Message);
                return new DateTime(1900,1,1);
            }

            Console.WriteLine(new DateTime(1900, 1, 1).ToString());
        }

        private void WordCounter(FlowDocument doc)
        {

            TextRange txtRange = new TextRange(doc.ContentStart,doc.ContentEnd);
            string txt = txtRange.Text;

            Regex regex = new Regex(@"\b\w+\b");

            // Brojač reči
            int wordCount = regex.Matches(txt).Count;
            WordsNumber.Text = wordCount.ToString();
            Console.WriteLine(wordCount.ToString());
            //return wordCount;
        }


    }
}
