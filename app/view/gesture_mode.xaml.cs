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
using System.Threading.Tasks;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=234238

namespace app.view
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    /// 

    public sealed partial class gesture_mode : Page
    {
        string mouse_mode_en_value;
        float palec1, palec2, palec3, palec4, palec5;
        public gesture_mode()
        {
            this.InitializeComponent();

            c1.Items.Add("Uruchom aplikację");
            c1.Items.Add("Wstaw znak");
            //c1.Items.Add("Wykonaj zadanie");
            c2.Items.Add("Uruchom aplikację");
            c2.Items.Add("Wstaw znak");
            //c2.Items.Add("Wykonaj zadanie");
            c3.Items.Add("Uruchom aplikację");
            c3.Items.Add("Wstaw znak");
            //c3.Items.Add("Wykonaj zadanie");
            c4.Items.Add("Uruchom aplikację");
            c4.Items.Add("Wstaw znak");
            //c4.Items.Add("Wykonaj zadanie");
            c5.Items.Add("Uruchom aplikację");
            c5.Items.Add("Wstaw znak");
            //c5.Items.Add("Wykonaj zadanie");
        }

        private void ProgramsComboBoxListing(ComboBox p_num)
        {

        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            c1.IsDropDownOpen = true;
        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            c2.IsDropDownOpen = true;
        }

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            c3.IsDropDownOpen = true;
        }

        private void b4_Click(object sender, RoutedEventArgs e)
        {
            c4.IsDropDownOpen = true;
        }

        private void b5_Click(object sender, RoutedEventArgs e)
        {
            c5.IsDropDownOpen = true;
        }
        private void c1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (c1.SelectedItem)
            {
                case "Uruchom aplikację":
                    t1.PlaceholderText = "Wklej ścieżkę do aplikacji";
                    t1.Visibility = Visibility.Visible;
                    cb1.Visibility = Visibility.Visible;
                    break;
                case "Wstaw znak":
                    t1.PlaceholderText = "Wpisz oczekiwany znak";
                    t1.Visibility = Visibility.Visible;
                    cb1.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void c2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (c2.SelectedItem)
            {
                case "Uruchom aplikację":
                    t2.PlaceholderText = "Wklej ścieżkę do aplikacji";
                    t2.Visibility = Visibility.Visible;
                    cb2.Visibility = Visibility.Visible;
                    break;
                case "Wstaw znak":
                    t2.PlaceholderText = "Wpisz oczekiwany znak";
                    t2.Visibility = Visibility.Visible;
                    cb2.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void c3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (c3.SelectedItem)
            {
                case "Uruchom aplikację":
                    t3.PlaceholderText = "Wklej ścieżkę do aplikacji";
                    t3.Visibility = Visibility.Visible;
                    cb3.Visibility = Visibility.Visible;
                    break;
                case "Wstaw znak":
                    t3.PlaceholderText = "Wpisz oczekiwany znak";
                    t3.Visibility = Visibility.Visible;
                    cb3.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void c4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (c4.SelectedItem)
            {
                case "Uruchom aplikację":
                    t4.PlaceholderText = "Wklej ścieżkę do aplikacji";
                    t4.Visibility = Visibility.Visible;
                    cb4.Visibility = Visibility.Visible;
                    break;
                case "Wstaw znak":
                    t4.PlaceholderText = "Wpisz oczekiwany znak";
                    t4.Visibility = Visibility.Visible;
                    cb4.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void c5_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (c5.SelectedItem)
            {
                case "Uruchom aplikację":
                    t5.PlaceholderText = "Wklej ścieżkę do aplikacji";
                    t5.Visibility = Visibility.Visible;
                    cb5.Visibility = Visibility.Visible;
                    break;
                case "Wstaw znak":
                    t5.PlaceholderText = "Wpisz oczekiwany znak";
                    t5.Visibility = Visibility.Visible;
                    cb5.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void cb1_Click(object sender, RoutedEventArgs e)
        {
            t1.Visibility = Visibility.Collapsed;
            cb1.Visibility = Visibility.Collapsed;
        }

        private void cb2_Click(object sender, RoutedEventArgs e)
        {
            t2.Visibility = Visibility.Collapsed;
            cb2.Visibility = Visibility.Collapsed;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void cb3_Click(object sender, RoutedEventArgs e)
        {
            t3.Visibility = Visibility.Collapsed;
            cb3.Visibility = Visibility.Collapsed;
        }

        private void cb4_Click(object sender, RoutedEventArgs e)
        {
            t4.Visibility = Visibility.Collapsed;
            cb4.Visibility = Visibility.Collapsed;
        }

        private void cb5_Click(object sender, RoutedEventArgs e)
        {
            t5.Visibility = Visibility.Collapsed;
            cb5.Visibility = Visibility.Collapsed;
        }

        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            if(mouse_mode_en.IsOn)
            {
                mouse_mode_en_value = "1";
            }
            else
            {
                mouse_mode_en_value = "0";
            }
        }
    }
}
