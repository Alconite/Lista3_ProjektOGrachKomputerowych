using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista3_ProjektOGrachKomputerowych
{
    public class Gry
    {
        public int releaseDate { get; set; }
        public string projectName { get; set; }
        public string companyName { get; set; }
     
        public Gry()
        {

        }

        public Gry(Gry gry)
        {
            this.releaseDate = gry.releaseDate;
            this.projectName = gry.projectName;
            this.companyName = gry.companyName;
        }
        public Gry(int releaseDate, string projectName, string companyName)
        {
            this.releaseDate = releaseDate;
            this.projectName = projectName;
            this.companyName = companyName;
        }
    }
}
