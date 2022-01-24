using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista3_ProjektOGrachKomputerowych.model
{
    public class Game : INotifyPropertyChanged
    {
        private int _ReleaseDate;
        public int Release_Date
        {
            get { return this._ReleaseDate; }
            set
            {
                if (this._ReleaseDate != value)
                {
                    this._ReleaseDate = value;
                    this.NotifyPropertyChanged("Release_Date");
                }
            }
        }

        private string _ProjectName;
        public string Project_Name
        {
            get { return this._ProjectName; }
            set
            {
                if (this._ProjectName != value)
                {
                    this._ProjectName = value;
                    this.NotifyPropertyChanged("Project_Name");
                }
            }
        }

        private string _CompanyName;
        public string Company_Name
        {
            get { return this._CompanyName; }
            set
            {
                if (this._CompanyName != value)
                {
                    this._CompanyName = value;
                    this.NotifyPropertyChanged("Company_Name");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }


}
