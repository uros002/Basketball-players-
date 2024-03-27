using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIPrviProjekat
{
    public class Player
    {
        private bool isChecked;
        private string fullName;
        private string selfPicture;
        private int jerseyNumber;
        private string rtfDat;
        private DateTime birthDate;
        private string playerInformation;
        private DateTime objectCreationDate;

        public bool IsChecked { get { return isChecked; } set { isChecked = value; } }
        public string FullName { get { return fullName; } set { fullName = value; } }
        public string SelfPicture { get { return selfPicture; } set { selfPicture = value; } }

        public int JerseyNumber { get { return jerseyNumber; } set { jerseyNumber = value; } }
        public string RTFDat { get { return rtfDat; } set { rtfDat = value; } }

        public DateTime BirthDate { get { return birthDate; }
            set { birthDate = value;
                BirthDateToDisplay = birthDate.ToShortDateString();                
            } 
        }

        public DateTime ObjectCreationDate { get { return objectCreationDate; } set { objectCreationDate = value; } }

        public string BirthDateToDisplay { get; set; }

        public string BasicInfo { get; set; }

        public string PlayerInformation { get { return playerInformation; } set { playerInformation = value; } }
        
        public Player()
        {
            
        }

        public Player(string fullName, string selfPicture, int jerNo, DateTime date,string basicInfo,string playerInfo)
        {
            IsChecked = false;
            FullName = fullName;
            SelfPicture = selfPicture;
            JerseyNumber = jerNo;
            BirthDate = date;
            BirthDateToDisplay = date.ToShortDateString();
            BasicInfo = basicInfo;
            PlayerInformation = playerInfo;
            ObjectCreationDate = DateTime.Now;
        }
    }
}
