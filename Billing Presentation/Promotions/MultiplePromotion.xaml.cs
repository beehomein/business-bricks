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
    /// Interaction logic for MultiplePromotion.xaml
    /// </summary>
    public partial class MultiplePromotion : Window
    {
        public MultiplePromotion()
        {
            InitializeComponent();
            addBarcode();
        }


        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void offerTypeDD()
        {
            var OfferTypes = offerType.Text;
            if (OfferTypes == "Flat")
            {
                Flat.Height = 40;
                BuyandGet.Height = 0;
            }
            else if (OfferTypes == "Buy and Get Free")
            {
                BuyandGet.Height = 40;
                Flat.Height = 0;

            }
        }

        private void offerTypeDropDown(object sender, EventArgs e)
        {
            offerTypeDD();
        }


        private void FlatDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            var FlatDiscount = flatDiscount.Text;
            if (FlatDiscount == "" || FlatDiscount.StartsWith("0"))
            {
                flatDiscount.BorderBrush = Brushes.Red;
                flatDiscount.BorderThickness = new Thickness(2);
            }
            else
            {
                flatDiscount.BorderBrush = Brushes.Green;
                flatDiscount.BorderThickness = new Thickness(2);
            }
        }

        private void Buy_KeyUp(object sender, KeyEventArgs e)
        {
            var Buy = buy.Text;
            if (Buy == "" || Buy.StartsWith("0"))
            {
                buy.BorderBrush = Brushes.Red;
                buy.BorderThickness = new Thickness(2);
            }
            else
            {
                buy.BorderBrush = Brushes.Green;
                buy.BorderThickness = new Thickness(2);
            }
        }

        //click
        private void addBarcode()
        {
            var i = BarcodeAdd.Children.Count;
            var textbox = new TextBox();
            
            textbox.FontSize = 20;
            textbox.CharacterCasing = CharacterCasing.Upper;
            textbox.Width = 300;
            textbox.Padding = new Thickness(10, 5, 10, 5);
            textbox.Margin = new Thickness(0, 10, 0, 0);
            textbox.ToolTip = "Enter Barcode";
            textbox.Name = "Barcode" + i;

            BarcodeAdd.Children.Add(textbox);
            if (i > 1)
            {
                Remove.Height = 32;
            }
            else
            {
                Remove.Height = 0;
            }
        }

        private void add(object sender, RoutedEventArgs e)
        {
            addBarcode();
        }

        private void remove(object sender, RoutedEventArgs e)
        {
            var i = BarcodeAdd.Children.Count-1;
            if (i > 1)
            {
                Remove.Height = 32;
                BarcodeAdd.Children.RemoveAt(i);
                if (i == 2)
                {
                    Remove.Height = 0;
                }
            }
            else
            {
                Remove.Height = 0;
            }
        }

        private void close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void flatOffer()
        {
            var FlatDiscount = flatDiscount.Text;
            var DiscountTypeFlat = discountTypeFlat.Text;
            var description = "";
            if (DiscountTypeFlat == "Percentage")
            {
                description = "Flat " + FlatDiscount + "% on";
            }
            else
            {
                description = "Flat Rs." + FlatDiscount; 
            }
            if (FlatDiscount == "" || FlatDiscount.StartsWith("0"))
            {
                if (FlatDiscount.StartsWith("0"))
                {
                    var flatPopup = new PopUps.Alert();
                    flatPopup.content.Text = "Discount should not start with Zero!!!";
                    flatPopup.ShowDialog();
                    flatDiscount.BorderBrush = Brushes.Red;
                    flatDiscount.BorderThickness = new Thickness(2);
                }
                else
                {
                    var flatPopup = new PopUps.Alert();
                    flatPopup.content.Text = "Please Enter Flat discount!!!";
                    flatPopup.ShowDialog();
                    flatDiscount.BorderBrush = Brushes.Red;
                    flatDiscount.BorderThickness = new Thickness(2);
                }
            }
            else
            {
                var flatConfirmPopup = new PopUps.Confirm();
                flatConfirmPopup.content.Text = "Do you want to update \"" + description + "\"?";
                flatConfirmPopup.ShowDialog();
                bool confirmResult = flatConfirmPopup.result;
                if (confirmResult)
                {
                    var success = new PopUps.Success();
                    success.content.Text = "Successfully Updated!!!";
                    success.ShowDialog();
                }
            }
        }

        private void buyOffer()
        {
            var Buy = buy.Text;
            var BarcodeCombo = barcodeCombo.Text;
            var description = "Buy this combo Get " + Buy + " products of " + BarcodeCombo + " as free!";
            if (Buy == "" || Buy.StartsWith("0"))
            {
                if (Buy.StartsWith("0"))
                {
                    var buyPopup = new PopUps.Alert();
                    buyPopup.content.Text = "Discount should not start with Zero!!!";
                    buyPopup.ShowDialog();
                    buy.BorderBrush = Brushes.Red;
                    buy.BorderThickness = new Thickness(2); 
                }
                else
                {
                    var buyPopup = new PopUps.Alert();
                    buyPopup.content.Text = "Please Enter Get discount!!!";
                    buyPopup.ShowDialog();
                    buy.BorderBrush = Brushes.Red;
                    buy.BorderThickness = new Thickness(2);
                }
            }
            else if (BarcodeCombo == "Select Barcode")
            {
                var BarcodeComboPopup = new PopUps.Alert();
                BarcodeComboPopup.content.Text = "Please Select Barcode!!!";
                BarcodeComboPopup.ShowDialog();
            }
            else
            {
                var buyConfirmPopup = new PopUps.Confirm();
                buyConfirmPopup.content.Text = "Do you want to update \"" + description + "\"? ";
                buyConfirmPopup.content.TextWrapping = TextWrapping.WrapWithOverflow;
                buyConfirmPopup.content.Width = 400;
                buyConfirmPopup.ShowDialog();
                bool confirmResult = buyConfirmPopup.result;
                if (confirmResult)
                {
                    var success = new PopUps.Success();
                    success.content.Text = "Successfully Updated!!!";
                    success.ShowDialog();
                }
            }
        }

        private void submit(object sender, RoutedEventArgs e)
        {
            var Count = count();
            var OfferType = offerType.Text;

            if (Count == 1)
            {
                if (OfferType == "Flat")
                {
                    flatOffer();
                }
                else if (OfferType == "Buy and Get Free")
                {
                    buyOffer();
                } 
            }
            else
            {
                var barcodeEmpty = new PopUps.Alert();
                barcodeEmpty.content.Text = "Fill all barcode!!!";
                barcodeEmpty.ShowDialog();
            }
        }
        public int count()
        {
            var Newtextbox = BarcodeAdd.Children.OfType<TextBox>();
            var actualLength = Newtextbox.Count();
            var nonEmptyBarcodeLength = 0;
            foreach (var text in Newtextbox)
            {
                var textelement = (TextBox)text;
                var textboxes = textelement.Text;
                if(textboxes != "")
                {
                    nonEmptyBarcodeLength++;
                }
            }
            if (actualLength == nonEmptyBarcodeLength)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
