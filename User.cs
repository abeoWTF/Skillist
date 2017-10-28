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
        public bool CanSwedishE { get; set; }
        public bool CanSwedishD { get; set; }
        public bool CanGermanE { get; set; }
        public bool CanGermanD { get; set; }
        public bool CanNorwegianE { get; set; }
        public bool CanNorwegianD { get; set; }
        public bool CanReturnPost { get; set; }
        public bool CanClubApplication { get; set; }
        public bool CanClubChangeHere { get; set; }

        public User(string name, bool canSwedishE, bool canSwedishD, bool canGermanE, bool canGermanD, bool canNorwegianE, bool canNorwegianD, bool canReturnPost, bool canClubApplication, bool canClubChangeHere)
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

        public User(string name, bool canSwedishE)
        {
            UserName = name;
            CanSwedishE = canSwedishE;
        }


    }
}
