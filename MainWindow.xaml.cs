using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using String = System.String;

namespace Skillist
{
    
    public partial class MainWindow : Window
    {

        List<User> users = new List<User>();

        public MainWindow()
        {
            InitializeComponent();
            DisableCheckBox();
        }
        
       private void name_TextBox_GotFocus(object sender, RoutedEventArgs e)
       {
            name_TextBox.Clear();
            name_TextBox.Opacity = 100;
            EnableCheckBox();
            
       }
        //Create user.
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

            if (name_TextBox.Text != "")
            {
                
                users.Add(new User(name_TextBox.Text, swedishEQ, swedishDQ, germanEQ, germanDQ, norwegianEQ,
                    norwegianDQ, returnP, clubAP, clubCH));
                Users_Listbox.Items.Add(users.LastOrDefault());

                

                var list = Users_Listbox.Items.Cast<User>().OrderBy(item => item.UserName).ToList();
                Users_Listbox.Items.Clear();

                foreach (User listItem in list)
                {
                    Users_Listbox.Items.Add(listItem);
                }
                UncheckClearAll();
                DisableCheckBox();
                
            }

            else
            {
                MessageBox.Show("Please enter a valid name.", "No name entered.");
            }
        }

        //Disables the checkboxes.
        public void DisableCheckBox()
        {
            Equeue_Checkbox.IsEnabled = false;
            Dqueue_Checkbox.IsEnabled = false;
            Dqueue_De_Checkbox.IsEnabled = false;
            Equeue_De_Checkbox.IsEnabled = false;
            Equeue_No_Checkbox.IsEnabled = false;
            Dqueue_No_Checkbox.IsEnabled = false;
            Returpost_checkbox.IsEnabled = false;
            Club_Checkbox.IsEnabled = false;
            ClubChangeHere_Checkbox.IsEnabled = false;
            
        }
        //Enables the checkboxes.
        public void EnableCheckBox()
        {
            Equeue_Checkbox.IsEnabled = true;
            Dqueue_Checkbox.IsEnabled = true;
            Dqueue_De_Checkbox.IsEnabled = true;
            Equeue_De_Checkbox.IsEnabled = true;
            Equeue_No_Checkbox.IsEnabled = true;
            Dqueue_No_Checkbox.IsEnabled = true;
            Returpost_checkbox.IsEnabled = true;
            Club_Checkbox.IsEnabled = true;
            ClubChangeHere_Checkbox.IsEnabled = true;
        }
        //Unchecks the checkboxes.
        public void UncheckClearAll()
        {
            name_TextBox.Clear();
            Equeue_Checkbox.IsChecked = false;
            Dqueue_Checkbox.IsChecked = false;
            Equeue_De_Checkbox.IsChecked = false;
            Dqueue_De_Checkbox.IsChecked = false;
            Equeue_No_Checkbox.IsChecked = false;
            Dqueue_No_Checkbox.IsChecked = false;
            Returpost_checkbox.IsChecked = false;
            Club_Checkbox.IsChecked = false;
            ClubChangeHere_Checkbox.IsChecked = false;

        }


        
    }
}
