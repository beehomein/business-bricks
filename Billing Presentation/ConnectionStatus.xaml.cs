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
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Windows.Threading;


namespace Billing_Presentation
{
    /// <summary>
    /// Interaction logic for ConnectionStatus.xaml
    /// </summary>
    public partial class ConnectionStatus : Window
    {
        public ConnectionStatus()
        {
            InitializeComponent();
            startClock();
            //checks internet connectivity onload
            var checkStatus = CheckForInternetConnection();

            if (checkStatus)
            {
                connection.Content = "Internet Connected";
                connectionImage.Source = new BitmapImage(new Uri("assets/success.png", UriKind.Relative));
                InternetStatus.BorderThickness = new Thickness(0, 15, 0, 0);
                InternetStatus.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CAF50"));
            }
            else
            {
                connection.Content = "Internet Not Connected";
                connectionImage.Source = new BitmapImage(new Uri("assets/fail.png", UriKind.Relative));
                InternetStatus.BorderThickness = new Thickness(0, 15, 0, 0);
                InternetStatus.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C62828"));
            }
            //MessageBox.Show(connection.Content.ToString());

            //Time updation onload
            time.Content = DateTime.Now.ToString("HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo);

            TimeSpan start1 = new TimeSpan(10, 0, 0); //10 o'clock
            TimeSpan end1 = new TimeSpan(10, 30, 0); //10:30

            TimeSpan start2 = new TimeSpan(13, 0, 0); //01 o'clock
            TimeSpan end2 = new TimeSpan(13, 30, 0); //01:30

            TimeSpan start3 = new TimeSpan(16, 0, 0); //04 o'clock
            TimeSpan end3 = new TimeSpan(16, 30, 0); //04:30


            TimeSpan now = DateTime.Now.TimeOfDay; //Current Time

            if ((now > start1) && (now < end1))
            {
                dbConnection.Source = new BitmapImage(new Uri("assets/connection.png", UriKind.Relative));
                UpdateStatus.BorderThickness = new Thickness(0, 15, 0, 0);
                UpdateStatus.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CAF50"));
            }
            else if ((now > start2) && (now < end2))
            {
                dbConnection.Source = new BitmapImage(new Uri("assets/connection.png", UriKind.Relative));
                UpdateStatus.BorderThickness = new Thickness(0, 15, 0, 0);
                UpdateStatus.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CAF50"));
            }
            else if ((now > start3) && (now < end3))
            {
                dbConnection.Source = new BitmapImage(new Uri("assets/connection.png", UriKind.Relative));
                UpdateStatus.BorderThickness = new Thickness(0, 15, 0, 0);
                UpdateStatus.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CAF50"));
            }
            else
            {
                dbConnection.Source = new BitmapImage(new Uri("assets/waiting.png", UriKind.Relative));
                UpdateStatus.BorderThickness = new Thickness(0, 15, 0, 0);
                UpdateStatus.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC107"));
            }

            //printer Status
            try
            {
                System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + "wmic printer get name > printerName.txt");
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();

                procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + "wmic printer get PrinterStatus > printerStatus.txt");
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                string path = @"printerName.txt";
                int length = 0;
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        length++;
                    }
                }
                string[] printerNames = new string[length];
                string[] printerStatus = new string[length];
                path = @"printerName.txt";
                int i = 0;
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        printerNames[i] = s;
                        i++;
                    }
                }
                path = @"printerStatus.txt";
                i = 0;
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        if (s.Contains('3'))
                        {
                            s = "Connected";
                        }
                        else
                        {
                            s = "Not Connected";
                        }
                        printerStatus[i] = s;
                        i++;
                    }
                }
                Container.Children.Clear();
                //Row
                var stack = new StackPanel();
                stack.Orientation = Orientation.Horizontal;
                //Column 1
                var border = new Border();
                border.BorderThickness = new Thickness(1);
                border.BorderBrush = Brushes.Black;
                border.Width = 250;
                border.HorizontalAlignment = HorizontalAlignment.Center;
                var textBlock = new TextBlock();
                textBlock.Text = "Printer Name";
                textBlock.FontSize = 15;
                textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlock.FontWeight = FontWeights.Bold;
                border.Child = textBlock;
                //Binding Column 1
                stack.Children.Add(border);
                //Column 2
                border = new Border();
                border.BorderThickness = new Thickness(1);
                border.BorderBrush = Brushes.Black;
                border.Width = 150;
                border.HorizontalAlignment = HorizontalAlignment.Center;
                textBlock = new TextBlock();
                textBlock.Text = "Printer Status";
                textBlock.FontSize = 15;
                textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlock.FontWeight = FontWeights.Bold;
                border.Child = textBlock;
                //Binding Column 2
                stack.Children.Add(border);
                //Binding row
                Container.Children.Add(stack);

                for (i = 1; i < length; i++)
                {
                    stack = new StackPanel();
                    stack.Orientation = Orientation.Horizontal;
                    //Column 1
                    border = new Border();
                    border.BorderThickness = new Thickness(1, 0, 1, 1);
                    border.BorderBrush = Brushes.Black;
                    border.Width = 250;
                    border.HorizontalAlignment = HorizontalAlignment.Left;
                    border.Padding = new Thickness(10, 0, 0, 0);
                    textBlock = new TextBlock();
                    textBlock.Text = printerNames[i];
                    textBlock.FontSize = 15;
                    textBlock.HorizontalAlignment = HorizontalAlignment.Left;
                    //textBlock.FontWeight = FontWeights.Bold;
                    border.Child = textBlock;
                    //Binding Column 1
                    stack.Children.Add(border);
                    //Column 2
                    border = new Border();
                    border.BorderThickness = new Thickness(1, 0, 1, 1);
                    border.BorderBrush = Brushes.Black;
                    border.Width = 150;
                    border.HorizontalAlignment = HorizontalAlignment.Center;
                    textBlock = new TextBlock();
                    textBlock.Text = printerStatus[i];
                    textBlock.FontSize = 15;
                    textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                    //textBlock.FontWeight = FontWeights.Bold;
                    border.Child = textBlock;
                    //Binding Column 2
                    stack.Children.Add(border);
                    //Binding row
                    Container.Children.Add(stack);
                }

            }
            catch (Exception objException)
            {
                // Log the exception
                MessageBox.Show("Already Process is Running!!! Please Click only once.");

            }
        }
        

        //function to check internet connectivity
        public static bool CheckForInternetConnection()
        {
            try

            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }
        }

        //checknow btn - internet status
        private void Internetcheck_Click(object sender, RoutedEventArgs e)
        {
            var checkStatus = CheckForInternetConnection();

            if (checkStatus)
            {
                connection.Content = "Internet Connected";
                connectionImage.Source = new BitmapImage(new Uri("assets/success.png", UriKind.Relative));
                InternetStatus.BorderThickness = new Thickness(0, 15, 0, 0);
                InternetStatus.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CAF50"));
            }
            else
            {
                connection.Content = "Internet Not Connected";
                connectionImage.Source = new BitmapImage(new Uri("assets/fail.png", UriKind.Relative));
                InternetStatus.BorderThickness = new Thickness(0, 15, 0, 0);
                InternetStatus.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C62828"));
            }
        }

        private void startClock()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += tickevent;
            timer.Start();
        }

        private void tickevent(object sender, EventArgs e)
        {
            time.Content = DateTime.Now.ToString("HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo);
        }
        //checknow btn - update Status
        private void Timecheck_Click(object sender, RoutedEventArgs e)
        {
            //time.Content = DateTime.Now.ToString("HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo);

            //var date = DateTime.Now;
            //var hour = date.Hour;
            //var minute = date.Minute;
            //var seconds = date.Second;

            //var fulltime = hour + ":" + minute + ":" + seconds;
            //time.Content = fulltime;
            //var timer = new System.Timers.Timer();
            //timer.Interval = 1000;
            //MessageBox.Show(timer.ToString());

            TimeSpan start1 = new TimeSpan(10, 0, 0); //10 o'clock
            TimeSpan end1 = new TimeSpan(10, 30, 0); //10:30

            TimeSpan start2 = new TimeSpan(13, 0, 0); //01 o'clock
            TimeSpan end2 = new TimeSpan(13, 30, 0); //01:30

            TimeSpan start3 = new TimeSpan(16, 0, 0); //04 o'clock
            TimeSpan end3 = new TimeSpan(16, 30, 0); //04:30


            TimeSpan now = DateTime.Now.TimeOfDay; //Current Time

            if ((now > start1) && (now < end1))
            {
                dbConnection.Source = new BitmapImage(new Uri("assets/connection.png", UriKind.Relative));
                UpdateStatus.BorderThickness = new Thickness(0, 15, 0, 0);
                UpdateStatus.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CAF50"));
            }
            else if ((now > start2) && (now < end2))
            {
                dbConnection.Source = new BitmapImage(new Uri("assets/connection.png", UriKind.Relative));
                UpdateStatus.BorderThickness = new Thickness(0, 15, 0, 0);
                UpdateStatus.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CAF50"));
            }
            else if ((now > start3) && (now < end3))
            {
                dbConnection.Source = new BitmapImage(new Uri("assets/connection.png", UriKind.Relative));
                UpdateStatus.BorderThickness = new Thickness(0, 15, 0, 0);
                UpdateStatus.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CAF50"));
            }
            else
            {
                dbConnection.Source = new BitmapImage(new Uri("assets/waiting.png", UriKind.Relative));
                UpdateStatus.BorderThickness = new Thickness(0, 15, 0, 0);
                UpdateStatus.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC107"));
            }
        }

        //close btn
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        //printer Status
        private void CheckPrinterStatus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + "wmic printer get name > printerName.txt");
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();

                procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + "wmic printer get PrinterStatus > printerStatus.txt");
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;
                proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                string path = @"printerName.txt";
                int length = 0;
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        length++;
                    }
                }
                string[] printerNames = new string[length];
                string[] printerStatus = new string[length];
                path = @"printerName.txt";
                int i = 0;
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        printerNames[i] = s;
                        i++;
                    }
                }
                path = @"printerStatus.txt";
                i = 0;
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        if (s.Contains('3'))
                        {
                            s = "Connected";
                        }
                        else
                        {
                            s = "Not Connected";
                        }
                        printerStatus[i] = s;
                        i++;
                    }
                }
                Container.Children.Clear();
                //Row
                var stack = new StackPanel();
                stack.Orientation = Orientation.Horizontal;
                //Column 1
                var border = new Border();
                border.BorderThickness = new Thickness(1);
                border.BorderBrush = Brushes.Black;
                border.Width = 250;
                border.HorizontalAlignment = HorizontalAlignment.Center;
                var textBlock = new TextBlock();
                textBlock.Text = "Printer Name";
                textBlock.FontSize = 15;
                textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlock.FontWeight = FontWeights.Bold;
                border.Child = textBlock;
                //Binding Column 1
                stack.Children.Add(border);
                //Column 2
                border = new Border();
                border.BorderThickness = new Thickness(1);
                border.BorderBrush = Brushes.Black;
                border.Width = 150;
                border.HorizontalAlignment = HorizontalAlignment.Center;
                textBlock = new TextBlock();
                textBlock.Text = "Printer Status";
                textBlock.FontSize = 15;
                textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                textBlock.FontWeight = FontWeights.Bold;
                border.Child = textBlock;
                //Binding Column 2
                stack.Children.Add(border);
                //Binding row
                Container.Children.Add(stack);

                for (i = 1; i < length; i++)
                {
                    stack = new StackPanel();
                    stack.Orientation = Orientation.Horizontal;
                    //Column 1
                    border = new Border();
                    border.BorderThickness = new Thickness(1, 0, 1, 1);
                    border.BorderBrush = Brushes.Black;
                    border.Width = 250;
                    border.HorizontalAlignment = HorizontalAlignment.Left;
                    border.Padding = new Thickness(10, 0, 0, 0);
                    textBlock = new TextBlock();
                    textBlock.Text = printerNames[i];
                    textBlock.FontSize = 15;
                    textBlock.HorizontalAlignment = HorizontalAlignment.Left;
                    //textBlock.FontWeight = FontWeights.Bold;
                    border.Child = textBlock;
                    //Binding Column 1
                    stack.Children.Add(border);
                    //Column 2
                    border = new Border();
                    border.BorderThickness = new Thickness(1, 0, 1, 1);
                    border.BorderBrush = Brushes.Black;
                    border.Width = 150;
                    border.HorizontalAlignment = HorizontalAlignment.Center;
                    textBlock = new TextBlock();
                    textBlock.Text = printerStatus[i];
                    textBlock.FontSize = 15;
                    textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                    //textBlock.FontWeight = FontWeights.Bold;
                    border.Child = textBlock;
                    //Binding Column 2
                    stack.Children.Add(border);
                    //Binding row
                    Container.Children.Add(stack);
                }

            }
            catch (Exception objException)
            {
                // Log the exception
                MessageBox.Show("Already Process is Running!!! Please Click only once.", "Alert");
            }
        }
    }
}
