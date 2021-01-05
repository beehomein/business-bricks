//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;
//using System.Text.RegularExpressions;

//namespace Billing_Presentation
//{
//    /// <summary>
//    /// Interaction logic for MainWindow.xaml
//    /// </summary>
//    public partial class MainWindow : Window
//    {
//        public MainWindow()
//        {
//            InitializeComponent();
//        }

//        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
//        {
//            Regex regex = new Regex("[^0-9]+");
//            e.Handled = regex.IsMatch(e.Text);
//        }

//        private void myTextBox_TextChanged(object sender, TextCompositionEventArgs e)
//        {
//            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
//            e.Handled = regex.IsMatch(e.Text);
//        }

//        private void todayDate(object sender, RoutedEventArgs e)
//        {
//            datePicker.SelectedDate = DateTime.Today;
//        }

//        //private void myTextBox_TextChanged1(object sender, EventArgs e)
//        //{
//        //    bool result = ValidatorExtensions.IsValidEmailAddress(myTextBox.Text);
//        //}
//    }


//    //public static class ValidatorExtensions
//    //{
//    //    public static bool IsValidEmailAddress(this string s)
//    //    {
//    //        Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
//    //        return regex.IsMatch(s);
//    //    }

//    //}



//}

using System;
using System.Windows.Data;
using System.Windows;

namespace Billing_Presentation
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
    public class TextInputToVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Always test MultiValueConverter inputs for non-null
            // (to avoid crash bugs for views in the designer)
            if (values[0] is bool && values[1] is bool)
            {
                bool hasText = !(bool)values[0];
                bool hasFocus = (bool)values[1];

                if (hasFocus || hasText)
                    return Visibility.Collapsed;
            }

            return Visibility.Visible;
        }


        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
