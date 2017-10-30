using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            string swedishEQ, swedishDQ, germanEQ, germanDQ, norwegianEQ, norwegianDQ, returnP, clubAP, clubCH;

            if (Equeue_Checkbox.IsChecked == true) { swedishEQ = "Swedish E-Queue"; }
            else { swedishEQ = string.Empty;}
            if (Dqueue_Checkbox.IsChecked == true) { swedishDQ = "Swedish D-Queue"; }
            else { swedishDQ = string.Empty; }
            if (Equeue_De_Checkbox.IsChecked == true) { germanEQ = "German E-Queue"; }
            else { germanEQ = string.Empty; }
            if (Dqueue_De_Checkbox.IsChecked == true) { germanDQ = "German D-Queue"; ; }
            else { germanDQ = string.Empty; }
            if (Equeue_No_Checkbox.IsChecked == true) { norwegianEQ = "Norwegian E-Queue"; }
            else { norwegianEQ = string.Empty; }
            if (Dqueue_No_Checkbox.IsChecked == true) { norwegianDQ = "Norwegian D-Queue"; }
            else { norwegianDQ = string.Empty; }
            if (Returpost_checkbox.IsChecked == true) { returnP = "Returned post"; }
            else { returnP = string.Empty; }
            if (Club_Checkbox.IsChecked == true) { clubAP = "H&M Club - applications"; }
            else { clubAP = string.Empty; }
            if (ClubChangeHere_Checkbox.IsChecked == true) { clubCH = "H&M Club - change here"; }
            else { clubCH = string.Empty; }

            if (!(string.IsNullOrWhiteSpace(name_TextBox.Text)))
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

        //Add result.
        private void Users_Listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Resultlist_ListBox.Items.Clear();
            DisableCheckBox();
            if (Users_Listbox.SelectedItem != null)
            {
                DeleteUser_Button.IsEnabled = true;
                object selectedAgent = Users_Listbox.SelectedItem;
                PropertyInfo[] properties = selectedAgent.GetType().GetProperties();

                foreach (var p in properties)
                {
                    var myVal = p.GetValue(selectedAgent);
                    Resultlist_ListBox.Items.Add(myVal.ToString());
                    int count = Resultlist_ListBox.Items.Count;
                    for (int i = count - 1; i >= 0; i--)
                    {
                        //Remove empty items.
                        if (Resultlist_ListBox.Items[i].ToString() == string.Empty)
                        {
                            Resultlist_ListBox.Items.RemoveAt(i);
                        }
                    }
                }
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
        //Delete User
        private void DeleteUser_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Users_Listbox.SelectedItem != null)
                {
                    var item = users.LastOrDefault(x => name_TextBox.Text == Name);
                    {
                        users.Remove(item);
                    }
                }
                Users_Listbox.Items.Remove(Users_Listbox.SelectedItem);
            }
            catch { }

        }

        private void skill_finder_Click(object sender, RoutedEventArgs e)
        {
            Users_Listbox.Items.Clear();
            var query = from user in users
                where user.CanClubApplication.Contains("H&M Club - applications")
                select user;

            foreach (var usr in query)
            {
                Users_Listbox.Items.Add(usr);
            }
        }

        private void SkillFind_SEEQ_btn_Click(object sender, RoutedEventArgs e)
        {
            Users_Listbox.Items.Clear();
            var query = from user in users
                where user.CanSwedishE.Contains("Swedish E-Queue")
                select user;

            foreach (var usr in query)
            {
                Users_Listbox.Items.Add(usr);
            }
        }

        private void SkillFind_SWDQ_btn_Click(object sender, RoutedEventArgs e)
        {
            Users_Listbox.Items.Clear();
            var query = from user in users
                where user.CanSwedishD.Contains("Swedish D-Queue")
                select user;

            foreach (var usr in query)
            {
                Users_Listbox.Items.Add(usr);
            }
        }

        private void HM_ClubChange_lbl_Click(object sender, RoutedEventArgs e)
        {
            Users_Listbox.Items.Clear();
            var query = from user in users
                where user.CanClubChangeHere.Contains("H&M Club - change here")
                select user;

            foreach (var usr in query)
            {
                Users_Listbox.Items.Add(usr);
            }
        }

        private void SkillFind_NOEQ_btn_Click(object sender, RoutedEventArgs e)
        {
            Users_Listbox.Items.Clear();
            var query = from user in users
                where user.CanNorwegianE.Contains("Norwegian E-Queue")
                select user;

            foreach (var usr in query)
            {
                Users_Listbox.Items.Add(usr);
            }
        }

        private void SkillFind_NODQ_btn_Click(object sender, RoutedEventArgs e)
        {
            Users_Listbox.Items.Clear();
            var query = from user in users
                where user.CanNorwegianD.Contains("Norwegian D-Queue")
                select user;

            foreach (var usr in query)
            {
                Users_Listbox.Items.Add(usr);
            }
        }

        private void SkillFind_DEEQ_btn_Click(object sender, RoutedEventArgs e)
        {
            Users_Listbox.Items.Clear();
            var query = from user in users
                where user.CanGermanE.Contains("German E-Queue")
                select user;

            foreach (var usr in query)
            {
                Users_Listbox.Items.Add(usr);
            }
        }

        private void SkillFind_DEDQ_btn_Click(object sender, RoutedEventArgs e)
        {
            Users_Listbox.Items.Clear();
            var query = from user in users
                where user.CanGermanD.Contains("German D-Queue")
                select user;

            foreach (var usr in query)
            {
                Users_Listbox.Items.Add(usr);
            }
        }

        private void SkillFind_RP_btn_Click(object sender, RoutedEventArgs e)
        {
            Users_Listbox.Items.Clear();
            var query = from user in users
                where user.CanReturnPost.Contains("Returned post")
                select user;

            foreach (var usr in query)
            {
                Users_Listbox.Items.Add(usr);
            }
        }

        private void ShowAll_users_Click(object sender, RoutedEventArgs e)
        {
           Users_Listbox.Items.Clear();

            foreach (User listItem in users)
            {
                Users_Listbox.Items.Add(listItem);
            }
        }
    }
}
