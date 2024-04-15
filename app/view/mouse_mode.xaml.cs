using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.NetworkInformation;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=234238

namespace app.view
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class mouse_mode : Page
    {
        string fLPM, fSPM, fPPM;
        int DPI;
       

        public mouse_mode()
        {
            this.InitializeComponent();
        }

    private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            if (czujnik_en.IsOn == true)
            {
                czujnik_slider.IsEnabled = true;
            }
            else
            {
                czujnik_slider.IsEnabled = false;
            }
        }

        private void LPM_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SPM_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PPM_Click(object sender, RoutedEventArgs e)
        {

        }

        private void change_fingers_en_Toggled(object sender, RoutedEventArgs e)
        {
            if(!change_fingers_en.IsOn)
            {
                LPM.IsEnabled = false;

                PPM.IsEnabled = false;
            }
            else
            {
                LPM.IsEnabled = true;

                PPM.IsEnabled = true;
            }
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var r = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 173, 43, 43));
            var w = new SolidColorBrush(Windows.UI.Color.FromArgb(0,0,0,0));
            //3
            if ((LPM.IsChecked == true))
            {
                f3.Background = r; // Kolor niebieski
                if((((f1.Background == r) || (f2.Background == r) || (f4.Background == r) || (f5.Background == r)))){
                    f4.Background = w; f5.Background = w; f1.Background = w; f2.Background = w;
                }
            }
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            var r = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 173, 43, 43));
            var g = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 27, 136, 23));
            if(LPM.IsEnabled && PPM.IsEnabled)
            {
                if (LPM.IsChecked == true)
                {
                    fLPM = "1";
                    fPPM = "2";
                    f1.Background = r;
                    f2.Background = g;
                }
                if (PPM.IsChecked == true)
                {
                    fLPM = "2";
                    fPPM = "1";
                    f2.Background = r;
                    f1.Background = g;
                }
            }
        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            var r = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 173, 43, 43));
            var g = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 27, 136, 23));
            if (LPM.IsEnabled && PPM.IsEnabled)
            {
                if (LPM.IsChecked == true)
                {
                    fLPM = "2";
                    fPPM = "1";
                    f2.Background = r;
                    f1.Background = g;
                }
                if (PPM.IsChecked == true)
                {
                    fLPM = "1";
                    fPPM = "2";
                    f1.Background = r;
                    f2.Background = g;
                }
            }
        }

        private void LPM_checked(object sender, RoutedEventArgs e)
        {
            PPM.IsChecked = false;
        }


        private void czujnik_slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        { 
            DPI = (int)czujnik_slider.Value;
        }

        private void PPM_checked(object sender, RoutedEventArgs e)
        {
            LPM.IsChecked = false;
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //reset
            var w = new SolidColorBrush(Windows.UI.Color.FromArgb(0, 0, 0, 0));
            f4.Background = w; f5.Background = w; f1.Background = w; f3.Background = w; f2.Background = w;
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {//zastosuj i wyślij publikacja mqtt na temat ahc_ust
            string dane_out = fLPM + fPPM + DPI; //zmienna do wysyłki

        }
    }
}
