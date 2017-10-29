using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skillist
{
    public class User
    {
        public string UserName { get; set; }
        public string CanSwedishE { get; set; }
        public string CanSwedishD { get; set; }
        public string CanGermanE { get; set; }
        public string CanGermanD { get; set; }
        public string CanNorwegianE { get; set; }
        public string CanNorwegianD { get; set; }
        public string CanReturnPost { get; set; }
        public string CanClubApplication { get; set; }
        public string CanClubChangeHere { get; set; }

        public User(string name, string canSwedishE, string canSwedishD, string canGermanE, string canGermanD, string canNorwegianE, string canNorwegianD, string canReturnPost, string canClubApplication, string canClubChangeHere)
        {
            UserName = name;
            CanSwedishE = canSwedishE;
            CanSwedishD = canSwedishD;
            CanGermanE = canGermanE;
            CanGermanD = canGermanD;
            CanNorwegianE = canNorwegianE;
            CanNorwegianD = canNorwegianD;
            CanReturnPost = canReturnPost;
            CanClubApplication = canClubApplication;
            CanClubChangeHere = canClubChangeHere;
        }
        public override string ToString()
        {
            return string.Format("{0} {1} ({2}), {3} , {4}, {5}, {6}, {7}, {8}, {9})",
                "Skills", CanSwedishE, CanSwedishD, CanGermanE, CanGermanD, CanNorwegianE, CanNorwegianD, CanReturnPost, CanClubApplication, CanClubChangeHere);
        }
    }
}
