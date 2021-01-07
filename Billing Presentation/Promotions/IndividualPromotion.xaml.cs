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

namespace Billing_Presentation.Promotions
{
    /// <summary>
    /// Interaction logic for IndividualPromotion.xaml
    /// </summary>
    public partial class IndividualPromotion : Window
    {
        public IndividualPromotion()
        {
            InitializeComponent();
        }

        //validation starts

        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        //validation ends
        
        //keyup start
        private void BarcodeKeyUp(object sender, KeyEventArgs e)
        {
            var barcode = Barcode.Text;
            if (barcode == "")
            {
                Barcode.BorderThickness = new Thickness(2);
                Barcode.BorderBrush = Brushes.Red;
            }
            else
            {
                Barcode.BorderThickness = new Thickness(2);
                Barcode.BorderBrush = Brushes.Green;
            }
        }

        private void flatDiscountKeyUp(object sender, KeyEventArgs e)
        {
            var FlatDiscount = flatDiscount.Text;
            if (FlatDiscount == "" || FlatDiscount.StartsWith("0"))
            {
                flatDiscount.BorderThickness = new Thickness(2);
                flatDiscount.BorderBrush = Brushes.Red;
            }
            else
            {
                flatDiscount.BorderThickness = new Thickness(2);
                flatDiscount.BorderBrush = Brushes.Green;
            }
        }

        private void onBulkDiscountKeyUp(object sender, KeyEventArgs e)
        {
            var OnBulk = onBulk.Text;
            if(OnBulk == "" || OnBulk.StartsWith("0"))
            {
                onBulk.BorderThickness = new Thickness(2);
                onBulk.BorderBrush = Brushes.Red;
            }
            else
            {
                onBulk.BorderThickness = new Thickness(2);
                onBulk.BorderBrush = Brushes.Green;
            }
        }

        private void flatBulkDiscountKeyUp(object sender, KeyEventArgs e)
        {
            var FlatBulk = flatBulk.Text;
            if (FlatBulk == "" || FlatBulk.StartsWith("0"))
            {
                flatBulk.BorderThickness = new Thickness(2);
                flatBulk.BorderBrush = Brushes.Red;
            }
            else
            {
                flatBulk.BorderThickness = new Thickness(2);
                flatBulk.BorderBrush = Brushes.Green;
            }
        }

        private void buyKeyUp(object sender, KeyEventArgs e)
        {
            var Buy = buy.Text;
            if (Buy == "" || Buy.StartsWith("0"))
            {
                buy.BorderThickness = new Thickness(2);
                buy.BorderBrush = Brushes.Red;
            }
            else
            {
                buy.BorderThickness = new Thickness(2);
                buy.BorderBrush = Brushes.Green;
            }
        }

        private void getKeyUp(object sender, KeyEventArgs e)
        {
            var Get = get.Text;
            if(Get == "" || Get.StartsWith("0"))
            {
                get.BorderThickness = new Thickness(2);
                get.BorderBrush = Brushes.Red;
            }
            else
            {
                get.BorderThickness = new Thickness(2);
                get.BorderBrush = Brushes.Green;
            }
        }
        //keyup start

        //click starts
        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void reset()
        {
            Barcode.Text = "";
            flatDiscount.Text = "";
            onBulk.Text = "";
            flatBulk.Text = "";
            buy.Text = "";
            get.Text = "";
            offerType.Text = "Flat";
            discountTypeFlat.Text = "Percentage";
            Barcode.BorderThickness = new Thickness(2);
            flatDiscount.BorderThickness = new Thickness(2);
            onBulk.BorderThickness = new Thickness(2);
            flatBulk.BorderThickness = new Thickness(2);
            buy.BorderThickness = new Thickness(2);
            get.BorderThickness = new Thickness(2);
            Barcode.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b4afaf"));
            flatDiscount.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b4afaf"));
            onBulk.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b4afaf"));
            flatBulk.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b4afaf"));
            buy.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b4afaf"));
            get.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b4afaf"));
            offerTypeDD();
        }

        //offer validation starts
        private void FlatOffer()
        {
            var barcode = Barcode.Text;
            var FlatDiscount = flatDiscount.Text;
            var DiscountTypeFlat = discountTypeFlat.Text;
            var description = "";

            if (DiscountTypeFlat == "Percentage")
            {
                description = "flat " + FlatDiscount +"% on Arrow(" + barcode + ")";
            }
            else
            {
                description = "flat Rs." + FlatDiscount + " on Arrow(" + barcode + ")";
            }

            if (FlatDiscount == "" || FlatDiscount.StartsWith("0"))
            {
                if (FlatDiscount.StartsWith("0"))
                {
                    var dicountPopup = new PopUps.Alert();
                    dicountPopup.content.Text = "Discount should not starts with Zero!!!";
                    dicountPopup.ShowDialog();
                }
                else
                {
                    var dicountPopup = new PopUps.Alert();
                    dicountPopup.content.Text = "Please enter discount value!!!";
                    dicountPopup.ShowDialog();
                    flatDiscount.BorderThickness = new Thickness(2);
                    flatDiscount.BorderBrush = Brushes.Red;
                }
            }

            else
            {
                var confirm = new PopUps.Confirm();
                confirm.content.Text = "Do you want to apply \"" + description + "\"?";
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

        private void BulkOffer()
        {
            var barcode = Barcode.Text;
            var OnBulk = onBulk.Text;
            var FlatBulk = flatBulk.Text;
            var DiscountTypeBulk = discountTypeBulk.Text;
            var description = "";

            if (DiscountTypeBulk == "Percentage")
            {
                description = "Buy " + OnBulk + " Get Flat " + FlatBulk + "% on Arrow(" + barcode + ")";
            }
            else
            {
                description = "Buy " + OnBulk + " Get Flat Rs." + FlatBulk + " on Arrow(" + barcode + ")";
            }

            if (OnBulk == "" && FlatBulk == "")
            {
                var dicountPopup = new PopUps.Alert();
                dicountPopup.content.Text = "Please enter On and Flat value!!!";
                dicountPopup.ShowDialog();
                onBulk.BorderThickness = new Thickness(2);
                onBulk.BorderBrush = Brushes.Red;
                flatBulk.BorderThickness = new Thickness(2);
                flatBulk.BorderBrush = Brushes.Red;

            }
            else if (OnBulk == "" || OnBulk.StartsWith("0"))
            {
                if (OnBulk.StartsWith("0"))
                {
                    var dicountPopup = new PopUps.Alert();
                    dicountPopup.content.Text = "On Value should not starts with Zero!!!";
                    dicountPopup.ShowDialog();
                }
                else
                {
                    var dicountPopup = new PopUps.Alert();
                    dicountPopup.content.Text = "Please enter On value!!!";
                    dicountPopup.ShowDialog();
                    onBulk.BorderThickness = new Thickness(2);
                    onBulk.BorderBrush = Brushes.Red;
                }
                
            }
            else if (FlatBulk == "" || FlatBulk.StartsWith("0"))
            {
                if (FlatBulk.StartsWith("0"))
                {
                    var dicountPopup = new PopUps.Alert();
                    dicountPopup.content.Text = "Flat Value should not starts with Zero!!!";
                    dicountPopup.ShowDialog();
                }
                else
                {
                    var dicountPopup = new PopUps.Alert();
                    dicountPopup.content.Text = "Please enter Flat value!!!";
                    dicountPopup.ShowDialog();
                    flatBulk.BorderThickness = new Thickness(2);
                    flatBulk.BorderBrush = Brushes.Red;
                }
                
            }
            else
            {
                var confirm = new PopUps.Confirm();
                confirm.content.TextWrapping = TextWrapping.WrapWithOverflow;
                confirm.content.Width = 280;
                confirm.content.Text = "Do you want to apply \"" + description + "\"?";
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

        private void BuyandGetOffer()
        {
            var barcode = Barcode.Text;
            var Buy = buy.Text;
            var Get = get.Text;
            var description = "Buy " + Buy + " Get " + Get;
            if (Buy == "" && Get == "")
            {
                var dicountPopup = new PopUps.Alert();
                dicountPopup.content.Text = "Please enter Buy and Get Free value!!!";
                dicountPopup.ShowDialog();
                buy.BorderThickness = new Thickness(2);
                buy.BorderBrush = Brushes.Red;
                get.BorderThickness = new Thickness(2);
                get.BorderBrush = Brushes.Red;

            }
            else if (Buy == "" || Buy.StartsWith("0"))
            {
                if (Buy.StartsWith("0"))
                {
                    var dicountPopup = new PopUps.Alert();
                    dicountPopup.content.Text = "Buy value should not starts with Zero!!!";
                    dicountPopup.ShowDialog();
                }
                else
                {
                    var dicountPopup = new PopUps.Alert();
                    dicountPopup.content.Text = "Please enter Buy value!!!";
                    dicountPopup.ShowDialog();
                    buy.BorderThickness = new Thickness(2);
                    buy.BorderBrush = Brushes.Red;
                }
            }
            else if (Get == "" || Get.StartsWith("0"))
            {
                if (Get.StartsWith("0"))
                {
                    var dicountPopup = new PopUps.Alert();
                    dicountPopup.content.Text = "Get value should not starts with Zero!!!";
                    dicountPopup.ShowDialog();
                }
                else
                {
                    var dicountPopup = new PopUps.Alert();
                    dicountPopup.content.Text = "Please enter Get value!!!";
                    dicountPopup.ShowDialog();
                    get.BorderThickness = new Thickness(2);
                    get.BorderBrush = Brushes.Red;
                }
            }
            else
            {
                var confirm = new PopUps.Confirm();
                confirm.content.Text = "Do you want to apply \"" + description + "\"?";
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
        //offer validation ends

        private void save(object sender, RoutedEventArgs e)
        {
            var barcode = Barcode.Text;
            var OnBulk = onBulk.Text;
            var FlatBulk = flatBulk.Text;
            var OfferType = offerType.Text;

            if(barcode == "")
            {
                var barcodePopup = new PopUps.Alert();
                barcodePopup.content.Text = "Please fill the Barcode!!!";
                barcodePopup.ShowDialog();
                Barcode.BorderThickness = new Thickness(2);
                Barcode.BorderBrush = Brushes.Red;
            }
            else if (OfferType == "Flat")
            {
                FlatOffer();
            }
            else if (OfferType == "Bulk")
            {
                BulkOffer();
            }
            else if (OfferType == "Buy and Get Free")
            {
                BuyandGetOffer();
            }
        }

        private void offerTypeDD()
        {
            var OfferTypes = offerType.Text;
            if (OfferTypes == "Flat")
            {
                Flat.Height = 45;
                Bulk.Height = 0;
                BuyandGet.Height = 0;
            }
            else if (OfferTypes == "Bulk")
            {
                Bulk.Height = 45;
                Flat.Height = 0;
                BuyandGet.Height = 0;
            }
            else if (OfferTypes == "Buy and Get Free")
            {
                BuyandGet.Height = 45;
                Bulk.Height = 0;
                Flat.Height = 0;

            }
        }

        private void offerTypeDropDown(object sender, EventArgs e)
        {
            offerTypeDD();
        }
        //click ends
    }
}
