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
using System.Windows.Shapes;
using System.Text.RegularExpressions;


namespace Billing_Presentation
{
    /// <summary>
    /// Interaction logic for NewCustomerRegistration.xaml
    /// </summary>
    public partial class NewCustomerRegistration : Window
    {
        bool fnameFlag = false;
        bool mobileFlag = false;
        bool genderFlag = false;
        public NewCustomerRegistration()
        {
            InitializeComponent();
        }
        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void DateValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[^0-9\-]");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void TextValidation(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex(@"[^a-z\^A-Z]");
            e.Handled = regex.IsMatch(e.Text);

        }
        private bool IsValidEmailAddress(string s)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
        }
        

        private void todayDate(object sender, RoutedEventArgs e)
        {
            dob.SelectedDate = DateTime.Today;
            dobValidator();
        }

        private void reset(object sender, RoutedEventArgs e)
        {
            firstName.Text = "";
            lastName.Text = "";
            mobileNo.Text = "";
            occupation.Text = "";
            dob.Text = "";
            male.IsChecked = false;
            female.IsChecked = false;
            age.Text = "Select Age Group";
            sms.IsChecked = false;
            emailRadio.IsChecked = false;
            email.Text = "";
            city.Text = "";
            fnameFlag = false;
            mobileFlag = false;
            genderFlag = false;
            firstName.BorderBrush = Brushes.Black;
            firstName.BorderThickness = new Thickness(0.5);
            lastName.BorderBrush = Brushes.Black;
            lastName.BorderThickness = new Thickness(0.5);
            mobileNo.BorderBrush = Brushes.Black;
            mobileNo.BorderThickness = new Thickness(0.5);
            occupation.BorderBrush = Brushes.Black;
            occupation.BorderThickness = new Thickness(0.5);
            dob.BorderBrush = Brushes.Black;
            dob.BorderThickness = new Thickness(0.3);
            email.BorderBrush = Brushes.Black;
            email.BorderThickness = new Thickness(0.5);
            city.BorderBrush = Brushes.Black;
            city.BorderThickness = new Thickness(0.5);
            firstNameMandatory.Foreground = Brushes.Red;
            mobileNoMandatory.Foreground = Brushes.Red;
            genderMandatory.Foreground = Brushes.Red;
        }

        private void FirstNameKeyUp(object sender, KeyEventArgs e)
        {
            var fname = firstName.Text;
            if (fname == "")
            {
                firstName.BorderThickness = new Thickness(2);
                firstName.BorderBrush = Brushes.Red;
                firstNameMandatory.Foreground = Brushes.Red;
                fnameFlag = false;
            }
            else
            {
                firstName.BorderThickness = new Thickness(2);
                firstName.BorderBrush = Brushes.Green;
                firstNameMandatory.Foreground = Brushes.Green;
                firstNameMandatory.FontWeight = FontWeights.Bold;
                fnameFlag = true;
            }
        }

        private void LastNameKeyUp(object sender, KeyEventArgs e)
        {
            var lname = lastName.Text;
            if (lname == "")
            {
                lastName.BorderThickness = new Thickness(2);
                lastName.BorderBrush = Brushes.Red;
            }
            else
            {
                lastName.BorderThickness = new Thickness(2);
                lastName.BorderBrush = Brushes.Green;
            }
        }

        private void MobileNoKeyUp(object sender, KeyEventArgs e)
        {
            var mobile = mobileNo.Text;
            if (mobile == "")
            {
                mobileNo.BorderThickness = new Thickness(2);
                mobileNo.BorderBrush = Brushes.Red;
                mobileNoMandatory.Foreground = Brushes.Red;
                mobileFlag = false;
            }
            else
            {
                mobileNo.BorderThickness = new Thickness(2);
                mobileNo.BorderBrush = Brushes.Green;
                mobileNoMandatory.Foreground = Brushes.Green;
                mobileNoMandatory.FontWeight = FontWeights.Bold;
                mobileFlag = true;
            }
        }

        private void OccupationKeyUp(object sender, KeyEventArgs e)
        {
            var occu = occupation.Text;
            if (occu == "")
            {
                occupation.BorderThickness = new Thickness(2);
                occupation.BorderBrush = Brushes.Red;
            }
            else
            {
                occupation.BorderThickness = new Thickness(2);
                occupation.BorderBrush = Brushes.Green;
            }
        }

        private void DobKeyUp(object sender, KeyEventArgs e)
        {
            dobValidator();
        }
        private void dobValidator()
        {
            var DOB = dob.Text;
            if (DOB == "")
            {
                dob.BorderThickness = new Thickness(1);
                dob.BorderBrush = Brushes.Red;
            }
            else
            {
                dob.BorderThickness = new Thickness(1);
                dob.BorderBrush = Brushes.Green;
            }
        }

        private void EmailKeyUp(object sender, KeyEventArgs e)
        {

            var Email = email.Text;
            bool emailValidate = IsValidEmailAddress(Email);
            if (!emailValidate)
            {
                email.BorderThickness = new Thickness(2);
                email.BorderBrush = Brushes.Red;
            }
            else
            {
                email.BorderThickness = new Thickness(2);
                email.BorderBrush = Brushes.Green;
            }
        }

        private void CityKeyUp(object sender, KeyEventArgs e)
        {
            var City = city.Text;
            if (City == "")
            {
                city.BorderThickness = new Thickness(2);
                city.BorderBrush = Brushes.Red;
            }
            else
            {
                city.BorderThickness = new Thickness(2);
                city.BorderBrush = Brushes.Green;
            }
        }

        private void GeneralChecked(object sender, RoutedEventArgs e)
        {
            genderMandatory.Foreground = Brushes.Green;
            genderMandatory.FontWeight = FontWeights.Bold;
            genderFlag = true;
        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            if(!fnameFlag && !mobileFlag && !genderFlag)
            {
                var empty = new PopUps.Alert();
                empty.content.Text = "Please fill all mandatory fields";
                empty.ShowDialog();
            }
            else if (!fnameFlag)
            {
                var fname = new PopUps.Alert();
                fname.content.Text = "Please fill First Name!!!";
                fname.ShowDialog();
            }
            else if (!mobileFlag)
            {
                var mobile = new PopUps.Alert();
                mobile.content.Text = "Please fill Mobile number!!!";
                mobile.ShowDialog();
            }
            else if (mobileNo.Text.Length < 10)
            {
                var mobileNum = new PopUps.Alert();
                mobileNum.content.Text = "Enter valid Mobile number!!!";
                mobileNum.ShowDialog();
            }
            else if (!genderFlag)
            {
                var gender = new PopUps.Alert();
                gender.content.Text = "Please choose any Gender!!!";
                gender.ShowDialog();
            }
            else
            {
                var submit = new PopUps.Success();
                submit.content.Text = "Successfully submitted!!!";
                submit.ShowDialog();
            }
            
        }

        
    }
}
