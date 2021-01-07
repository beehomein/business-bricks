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
    /// Interaction logic for CreditReturns.xaml
    /// </summary>
    public partial class CreditReturns : Window
    {
        public CreditReturns()
        {
            InitializeComponent();
        }
        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }
        
        private void customerNameKeyup(object sender, KeyEventArgs e)
        {
            var customerName = CustomerName.Text;
            if(customerName == "")
            {
                CustomerName.BorderBrush = Brushes.Red;
                CustomerName.BorderThickness = new Thickness(2);
            }
            else
            {
                CustomerName.BorderBrush = Brushes.Green;
                CustomerName.BorderThickness = new Thickness(2);
            }
        }

        private void customerNumberKeyup(object sender, KeyEventArgs e)
        {
            var customerNumber = CustomerNumber.Text;
            if(customerNumber == "" || customerNumber.Length < 10)
            {
                CustomerNumber.BorderBrush = Brushes.Red;
                CustomerNumber.BorderThickness = new Thickness(2);
            }
            else
            {
                CustomerNumber.BorderBrush = Brushes.Green;
                CustomerNumber.BorderThickness = new Thickness(2);
            }
        }

        private void creditAmountKeyup(object sender, KeyEventArgs e)
        {
            var creditAmount = CreditAmount.Text;
            if (creditAmount == "" || creditAmount.StartsWith("0"))
            {
                CreditAmount.BorderBrush = Brushes.Red;
                CreditAmount.BorderThickness = new Thickness(2);
            }
            else
            {
                CreditAmount.BorderBrush = Brushes.Green;
                CreditAmount.BorderThickness = new Thickness(2);
            }
        }

        private void reset()
        {
            CreditAmount.Text = "";
            CustomerNumber.Text = "";
            CustomerName.Text = "";
            CreditAmount.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b4afaf"));
            CustomerNumber.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b4afaf"));
            CustomerName.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b4afaf"));
            CreditAmount.BorderThickness = new Thickness(1);
            CustomerNumber.BorderThickness = new Thickness(1);
            CustomerName.BorderThickness = new Thickness(1);
        }

        private void clear(object sender, RoutedEventArgs e)
        {
            reset();
        }

        private void submit(object sender, RoutedEventArgs e)
        {
            var customerName = CustomerName.Text;
            var customerNumber = CustomerNumber.Text;
            var creditAmount = CreditAmount.Text;

            if(customerName == "" && customerNumber == "" && creditAmount == "")
            {
                var empty = new PopUps.Alert();
                empty.content.Text = "Please fill all the fields!!!";
                empty.ShowDialog();
                CustomerName.BorderBrush = Brushes.Red;
                CustomerName.BorderThickness = new Thickness(2);
                CustomerNumber.BorderBrush = Brushes.Red;
                CustomerNumber.BorderThickness = new Thickness(2);
                CreditAmount.BorderBrush = Brushes.Red;
                CreditAmount.BorderThickness = new Thickness(2);
            }
            else if (customerName == "")
            {
                var customerNamePopup = new PopUps.Alert();
                customerNamePopup.content.Text = "Please fill Customer Name!!!";
                customerNamePopup.ShowDialog();
                CustomerName.BorderBrush = Brushes.Red;
                CustomerName.BorderThickness = new Thickness(2);
            }
            else if (customerNumber == "" || customerNumber.Length < 10)
            {
                if (customerNumber.Length < 10)
                {
                    var customerNamePopup = new PopUps.Alert();
                    customerNamePopup.content.Text = "Mobile Number cannot be less than 10!!!";
                    customerNamePopup.ShowDialog();
                }
                else
	            {
                    var customerNamePopup = new PopUps.Alert();
                    customerNamePopup.content.Text = "Please fill Customer Number!!!";
                    customerNamePopup.ShowDialog();
                    CustomerNumber.BorderBrush = Brushes.Red;
                    CustomerNumber.BorderThickness = new Thickness(2); 
                }
            }
            else if (creditAmount == "" || creditAmount.StartsWith("0"))
            {
                if (creditAmount.StartsWith("0"))
                {
                    var customerNamePopup = new PopUps.Alert();
                    customerNamePopup.content.Text = "Credit Amount should not start with Zero!!!";
                    customerNamePopup.ShowDialog();
                    CreditAmount.BorderBrush = Brushes.Red;
                    CreditAmount.BorderThickness = new Thickness(2);
                }
                else
                {
                    var customerNamePopup = new PopUps.Alert();
                    customerNamePopup.content.Text = "Please fill Credit Amount!!!";
                    customerNamePopup.ShowDialog();
                    CreditAmount.BorderBrush = Brushes.Red;
                    CreditAmount.BorderThickness = new Thickness(2);
                }
            }
            else
            {
                var confirm = new PopUps.Confirm();
                confirm.content.Text = "Are Sure to Update?";
                confirm.ShowDialog();
                bool confirmResult = confirm.result;

                if (confirmResult)
                {
                    var success = new PopUps.Success();
                    success.content.Text = "Successfully Submitted";
                    success.ShowDialog();
                    reset();
                }
            }
        }
    }
}
