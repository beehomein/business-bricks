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
    /// Interaction logic for SearchCustomer.xaml
    /// </summary>
    public partial class SearchCustomer : Window
    {
        bool isEmailValid = false;
        public SearchCustomer()
        {
            InitializeComponent();
        }

        //Validators starts

        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private bool IsValidEmailAddress(string s)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
        }

        //Validators ends

        //keyup Functions starts

        private void MobileNoKeyUp(object sender, KeyEventArgs e)
        {
            var mobile = mobileNo.Text;
            if (mobile == "")
            {
                mobileNo.BorderThickness = new Thickness(2);
                mobileNo.BorderBrush = Brushes.Red;
            }
            else
            {
                mobileNo.BorderThickness = new Thickness(2);
                mobileNo.BorderBrush = Brushes.Green;
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
                isEmailValid = false;
            }
            else
            {
                email.BorderThickness = new Thickness(2);
                email.BorderBrush = Brushes.Green;
                isEmailValid = true;
            }
        }

        //keyup Functions ends

        //click Function starts

        private void reset(object sender, RoutedEventArgs e)
        {
            mobileNo.Text = "";
            email.Text = "";
            mobileNo.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b4afaf"));
            mobileNo.BorderThickness = new Thickness(2);
            email.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b4afaf"));
            email.BorderThickness = new Thickness(2);
        }

        private void search(object sender, RoutedEventArgs e)
        {
            var mobile = mobileNo.Text;
            var emailID = email.Text;

            if (mobile == "" && emailID == "")
            {
                var mobileNum = new PopUps.Alert();
                mobileNum.content.Text = "Please fill Mobile Number or Email ID!!!";
                mobileNum.ShowDialog();
            }
            else if (mobile != "" && mobileNo.Text.Length < 10)
            {
                var mobileLen = new PopUps.Alert();
                mobileLen.content.Text = "Please Enter Valid Mobile Number!!!";
                mobileLen.ShowDialog();
            }
            else if (!isEmailValid && emailID != "")
            {
                var emailValid = new PopUps.Alert();
                emailValid.content.Text = "Please Enter Valid Email ID!!!";
                emailValid.ShowDialog();
            }
        }

        //click Function starts
    }
}
