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

namespace Skillist
{
    
    public partial class MainWindow : Window
    {

        List<User> users = new List<User>();

        public MainWindow()
        {
            InitializeComponent();
        }

        //CanSwedishE = canSwedishE;
        //CanSwedishD = canSwedishD;
        //CanGermanE = canGermanE;
        //CanGermanD = canGermanD;
        //CanNorwegianE = canNorwegianE;
        //CanNorwegianD = canNorwegianD;
        //CanReturnPost = canReturnPost;
        //CanClubApplication = canClubApplication;
        //CanClubApplication = canClubChangeHere;

        

        private void name_TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            name_TextBox.Clear();
            name_TextBox.Opacity = 100;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool swedishEQ, swedishDQ, germanEQ, germanDQ, norwegianEQ, norwegianDQ, returnP, clubAP, clubCH;

            if (Equeue_Checkbox.IsChecked == true) { swedishEQ = true; }
            else { swedishEQ = false;}
            if (Dqueue_Checkbox.IsChecked == true) { swedishDQ = true; }
            else { swedishDQ = false; }
            if (Equeue_De_Checkbox.IsChecked == true) { germanEQ = true; }
            else { germanEQ = false; }
            if (Dqueue_De_Checkbox.IsChecked == true) { germanDQ = true; }
            else { germanDQ = false; }
            if (Equeue_No_Checkbox.IsChecked == true) { norwegianEQ = true; }
            else { norwegianEQ = false; }
            if (Dqueue_No_Checkbox.IsChecked == true) { norwegianDQ = true; }
            else { norwegianDQ = false; }
            if (Returpost_checkbox.IsChecked == true) { returnP = true; }
            else { returnP = false; }
            if (Club_Checkbox.IsChecked == true) { clubAP = true; }
            else { clubAP = false; }
            if (ClubChangeHere_Checkbox.IsChecked == true) { clubCH = true; }
            else { clubCH = false; }



            //users.Add(new User(name_TextBox.Text, eq));
        }
    }
}
