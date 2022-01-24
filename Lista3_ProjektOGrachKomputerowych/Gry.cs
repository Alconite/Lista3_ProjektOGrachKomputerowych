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
        public string xprojectName { get; set; }
        public string xcompanyName { get; set; }

        public Gry()
        {

        }

        public Gry(Gry gry)
        {
            this.releaseDate = gry.releaseDate;
            this.xprojectName = gry.xprojectName;
            this.xcompanyName = gry.xcompanyName;
        }
        public Gry(int releaseDate, string projectName, string companyName)
        {
            this.releaseDate = releaseDate;
            this.xprojectName = xprojectName;
            this.xcompanyName = xcompanyName;
        }
    }
}
