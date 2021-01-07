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

namespace Billing_Presentation.Promotions
{
    /// <summary>
    /// Interaction logic for CreatePromotion.xaml
    /// </summary>
    public partial class CreatePromotion : Window
    {
        public CreatePromotion()
        {
            InitializeComponent();
        }

        private void submit(object sender, RoutedEventArgs e)
        {
            var promotion = Promotion.Text;
            if (promotion == "Individual Promotion")
            {
                var individualPromotion = new IndividualPromotion();
                individualPromotion.Show();
            }
            else if(promotion == "Multiple Promotion")
            {
                var multiplePromotion = new MultiplePromotion();
                multiplePromotion.Show();
            }
            else if(promotion == "Price Promotion")
            {
                var pricePromotion = new PricePromotion();
                pricePromotion.Show();
            }
        }

        private void close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
