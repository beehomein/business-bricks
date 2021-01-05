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
    /// Interaction logic for PriceOverride.xaml
    /// </summary>
    public partial class PriceOverride : Window
    {
        public PriceOverride()
        {
            InitializeComponent();
        }

        //validation
        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        //btnclick
        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void reset()
        {
            barcode.Text = "";
            NewPrice.Text = "";
            barcode.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b4afaf"));
            barcode.BorderThickness = new Thickness(1);
            NewPrice.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b4afaf"));
            NewPrice.BorderThickness = new Thickness(1);
        }


        private void Update(object sender, RoutedEventArgs e)
        {
            var Barcode = barcode.Text;
            var newPrice = NewPrice.Text;
            if (Barcode == "" && newPrice == "")
            {
                var empty = new PopUps.Alert();
                empty.content.Text = "Please Fill all fields!!!";
                empty.ShowDialog();
                barcode.BorderBrush = Brushes.Red;
                barcode.BorderThickness = new Thickness(2);
                NewPrice.BorderBrush = Brushes.Red;
                NewPrice.BorderThickness = new Thickness(2);

            }
            else if (Barcode == "")
            {
                var BarcodePopup = new PopUps.Alert();
                BarcodePopup.content.Text = "Please Enter a Barcode!!!";
                BarcodePopup.ShowDialog();
                barcode.BorderBrush = Brushes.Red;
                barcode.BorderThickness = new Thickness(2);
            }
            else if (newPrice == "")
            {
                var newPricePopup = new PopUps.Alert();
                newPricePopup.content.Text = "Please Enter new price!!!";
                newPricePopup.ShowDialog();
                NewPrice.BorderBrush = Brushes.Red;
                NewPrice.BorderThickness = new Thickness(2);
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
                    success.content.Text = "Successfully Updated!!!";
                    success.ShowDialog();
                    reset();
                }
                
            }

        }

        //keyup
        private void barcodeKeyup(object sender, KeyEventArgs e)
        {
            var Barcode = barcode.Text;

            if (Barcode == "")
            {
                barcode.BorderBrush = Brushes.Red;
                barcode.BorderThickness = new Thickness(2);
            }
            else
            {
                barcode.BorderBrush = Brushes.Green;
                barcode.BorderThickness = new Thickness(2);
            }
        }

        private void newPriceKeyup(object sender, KeyEventArgs e)
        {
            var newPrice = NewPrice.Text;

            if (newPrice == "")
            {
                NewPrice.BorderBrush = Brushes.Red;
                NewPrice.BorderThickness = new Thickness(2);
            }
            else
            {
                NewPrice.BorderBrush = Brushes.Green;
                NewPrice.BorderThickness = new Thickness(2);
            }
        }
    }
}
