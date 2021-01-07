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
    /// Interaction logic for PricePromotion.xaml
    /// </summary>
    public partial class PricePromotion : Window
    {
        public PricePromotion()
        {
            InitializeComponent();
        }

        
        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void flatDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            var FlatDiscount = flatDiscount.Text;
            if(FlatDiscount == "" || FlatDiscount.StartsWith("0"))
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

        private void aboveDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            var Above = above.Text;
            if (Above == "" || Above.StartsWith("0"))
            {
                above.BorderBrush = Brushes.Red;
                above.BorderThickness = new Thickness(2);
            }
            else
            {
                above.BorderBrush = Brushes.Green;
                above.BorderThickness = new Thickness(2);
            }
        }

        //clicks

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void reset()
        {
            above.Text = "";
            flatDiscount.Text = "";

            above.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b4afaf"));
            flatDiscount.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b4afaf"));

            above.BorderThickness = new Thickness(1);
            flatDiscount.BorderThickness = new Thickness(1);
        }

        private void submit(object sender, RoutedEventArgs e)
        {
            var Above = above.Text;
            var FlatDiscount = flatDiscount.Text;
            var DiscountTypeFlat = discountTypeFlat.Text;
            var description = "";
            if (DiscountTypeFlat == "Percentage")
            {
                description = "Buy Above " + Above + " Get " + FlatDiscount + "%"; 
            }
            else
            {
                description = "Buy Above " + Above + " Get Rs." + FlatDiscount;
            }

            if (Above == "" || Above.StartsWith("0"))
            {
                if(Above.StartsWith("0"))
                {
                    var abovePopups = new PopUps.Alert();
                    abovePopups.content.Text = "Amount should not start from zero!!!";
                    abovePopups.ShowDialog();
                }
                else
                {
                    var abovePopups = new PopUps.Alert();
                    abovePopups.content.Text = "Please Enter above value!!!";
                    abovePopups.ShowDialog();
                }
            }
            else if (FlatDiscount == "" || FlatDiscount.StartsWith("0"))
            {
                if (FlatDiscount.StartsWith("0"))
                {
                    var flatPopups = new PopUps.Alert();
                    flatPopups.content.Text = "Amount should not start from zero!!!";
                    flatPopups.ShowDialog();
                }
                else
                {
                    var flatPopups = new PopUps.Alert();
                    flatPopups.content.Text = "Please Enter flat value!!!";
                    flatPopups.ShowDialog();
                }
            }
            else
            {
                var confirm = new PopUps.Confirm();
                confirm.content.Text = "Are you sure to update \"" + description +"\"?";
                confirm.ShowDialog();
                bool confirmResult = confirm.result;

                if (confirmResult)
                {
                    var success = new PopUps.Success();
                    success.content.Text = "Successfully updated!!!";
                    success.ShowDialog();
                    reset();
                }
            }
        }
    }
}
