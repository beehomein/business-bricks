using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Billing_Business_Access_Layer;
using Billing_Business_Entity_Layer;
namespace Billing_Presentation
{
    /// <summary>
    /// Interaction logic for Company_Details.xaml
    /// </summary>
    public partial class Company_Details : Window
    {
        bool companyNameFlag = false;
        bool companyNumberFlag = false;
        bool companyTypeFlag = false;
        bool companyAddressFlag = false;
        bool companyEmailFlag = true;
        public Company_Details()
        {
            InitializeComponent();
        }

        private void mobileNumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void emailValidation(object sender, TextCompositionEventArgs e)
        {
            var email = (TextBox)sender;
            var emailString = email.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            e.Handled = regex.IsMatch(e.Text);
            bool isEmail = IsValid(emailString);
            if(isEmail)
            {
                companyEmail.BorderBrush = Brushes.Green;
                companyEmail.BorderThickness = new Thickness(2);
                companyEmailFlag = true;
            }
            else
            {
                companyEmail.BorderBrush = Brushes.Red;
                companyEmail.BorderThickness = new Thickness(2);
                companyEmailFlag = false;
            }
        }
        public bool IsValid(string emailaddress)
        {
            if(emailaddress.Length>0)
            {
                try
                {
                    MailAddress m = new MailAddress(emailaddress);
                    return true;
                }
                catch (FormatException)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void nameValidation(object sender, KeyEventArgs e)
        {
            var name = (TextBox)sender;
            var nameString = name.Text;
            if (nameString.Length > 2)
            {
                companyName.BorderBrush = Brushes.Green;
                companyName.BorderThickness = new Thickness(2);
                companyNameMandatory.Foreground = Brushes.Black;
                companyNameFlag = true;
            }
            else
            {
                companyName.BorderBrush = Brushes.Red;
                companyName.BorderThickness = new Thickness(2);
                companyNameMandatory.Foreground = Brushes.Red;
                companyNameFlag = false;
            }
        }

        private void numberLengthValidation(object sender, KeyEventArgs e)
        {
            var number = (TextBox)sender;
            var numberString = number.Text;
            if (numberString.Length == 10)
            {
                companyNumber.BorderBrush = Brushes.Green;
                companyNumber.BorderThickness = new Thickness(2);
                companyNumberMandatory.Foreground = Brushes.Black;
                companyNumberFlag = true;
            }
            else
            {
                companyNumber.BorderBrush = Brushes.Red;
                companyNumber.BorderThickness = new Thickness(2);
                companyNumberMandatory.Foreground = Brushes.Red;
                companyNumberFlag = false;
            }
        }


        private void addressLengthValidation(object sender, KeyEventArgs e)
        {
            var addresss = (TextBox)sender;
            var addresssString = addresss.Text;
            if (addresssString.Length > 10)
            {
                companyAddress.BorderBrush = Brushes.Green;
                companyAddress.BorderThickness = new Thickness(2);
                companyAddressMandatory.Foreground = Brushes.Black;
                companyAddressFlag = true;
            }
            else
            {
                companyAddress.BorderBrush = Brushes.Red;
                companyAddress.BorderThickness = new Thickness(2);
                companyAddressMandatory.Foreground = Brushes.Red;
                companyAddressFlag = false;
            }
        }

        private void checkCompanyType(object sender, RoutedEventArgs e)
        {
            if (companyTypeHeadOffice.IsChecked == true || companyTypeBranch.IsChecked == true)
            {
                companyTypeMandatory.Foreground = Brushes.Black;
                companyTypeFlag = true;
            }
            else
            {
                companyTypeMandatory.Foreground = Brushes.Red;
                companyTypeFlag = false;
            }
        }

        private void addCompanyDetails(object sender, RoutedEventArgs e)
        {
            if (companyNameFlag != false && companyNumberFlag != false && companyTypeFlag != false && companyAddressFlag != false && companyEmailFlag != false)
            {
                var confirmCompanyDetailsSubmit = new PopUps.Confirm();
                confirmCompanyDetailsSubmit.content.Text = "Are you sure, Want to submit?";
                confirmCompanyDetailsSubmit.ShowDialog();
                bool userChoice = confirmCompanyDetailsSubmit.result;
                if (userChoice)
                {
                    CompanyDetails companyDetails = new CompanyDetails();
                    companyDetails.name = companyName.Text;
                    companyDetails.mobileNumber = companyNumber.Text;
                    companyDetails.email = companyEmail.Text;

                    var companyTypeText = "";
                    if(companyTypeHeadOffice.IsChecked == true)
                    {
                        companyTypeText = companyTypeHeadOffice.Content.ToString();
                    }
                    if(companyTypeBranch.IsChecked == true)
                    {
                        companyTypeText = companyTypeBranch.Content.ToString();
                    }

                    companyDetails.companyType = companyTypeText;
                    companyDetails.address = companyAddress.Text;

                    CompanyDetailsBALC companyDetailsBALC = new CompanyDetailsBALC();
                    var res=companyDetailsBALC.InsertCompanyDetails(companyDetails);
                    if(res!=0)
                    {
                        var success = new PopUps.Success();
                        success.content.Text = "Company Details Added Sucessfully";
                        success.ShowDialog();
                        clear();
                    }
                    else
                    {
                        var failed = new PopUps.Failed();
                        failed.content.Text = "Company Details Addition Failed";
                        failed.ShowDialog();
                    }
                }
            }
            else
            {
                if (companyNameFlag == false && companyNumberFlag == false && companyTypeFlag == false && companyAddressFlag == false)
                {
                    var alert = new PopUps.Alert();
                    alert.content.Text = "Fill all mandatory fields";
                    alert.ShowDialog();
                }
                else if(companyNameFlag==false)
                {
                    var alert = new PopUps.Alert();
                    alert.content.Text = "Enter valid Company's Name";
                    alert.ShowDialog();
                }
                else if(companyNumberFlag==false)
                {
                    var alert = new PopUps.Alert();
                    alert.content.Text = "Enter Valid Company's Mobile Number";
                    alert.ShowDialog();
                }
                else if (companyEmailFlag == false)
                {
                    var alert = new PopUps.Alert();
                    alert.content.Text = "Enter Valid Company's Email";
                    alert.ShowDialog();
                }
                else if (companyTypeFlag == false)
                {
                    var alert = new PopUps.Alert();
                    alert.content.Text = "Select Company's Type";
                    alert.ShowDialog();
                }
                else if (companyAddressFlag == false)
                {
                    var alert = new PopUps.Alert();
                    alert.content.Text = "Enter Valid Company's Address";
                    alert.ShowDialog();
                }
            }
        }

        private void resetCompanyDetails(object sender, RoutedEventArgs e)
        {
            clear();
        }
        private void clear()
        {
            //clear company name
            companyName.Text = "";
            companyName.BorderBrush = Brushes.Black;
            companyName.BorderThickness = new Thickness(1);
            companyNameMandatory.Foreground = Brushes.Red;
            companyNameFlag = false;
            //clear company number
            companyNumber.Text = "";
            companyNumber.BorderBrush = Brushes.Black;
            companyNumber.BorderThickness = new Thickness(1);
            companyNumberMandatory.Foreground = Brushes.Red;
            companyNumberFlag = false;
            //clear company email
            companyEmail.Text = "";
            companyEmail.BorderBrush = Brushes.Black;
            companyEmail.BorderThickness = new Thickness(1);
            //clear company type
            companyTypeHeadOffice.IsChecked = false;
            companyTypeBranch.IsChecked = false;
            companyTypeMandatory.Foreground = Brushes.Red;
            companyTypeFlag = false;
            //clear company address
            companyAddress.Text = "";
            companyAddress.BorderBrush = Brushes.Black;
            companyAddress.BorderThickness = new Thickness(1);
            companyAddressMandatory.Foreground = Brushes.Red;
            companyAddressFlag = false;
        }

        private void onlyTextValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[^a-z\^A-Z]");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
