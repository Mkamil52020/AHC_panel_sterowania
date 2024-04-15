using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net;
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
using Windows.Devices.Enumeration;
using Windows.Devices.WiFi;
using AHC.view;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x415

namespace app
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            mqtt.Serwer();
            mouse_frame.Navigate(typeof(view.mouse_mode));
            gesture_frame.Navigate(typeof(view.gesture_mode));
            gamepad_frame.Navigate(typeof(view.gamepad_mode));
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            //myszka
            if (mouse_mode.IsChecked == true)
            {
                gamepad_mode.IsChecked = false;
                gesture_mode.IsChecked = false;
            }

        }

        private void ToggleButton_Checked_1(object sender, RoutedEventArgs e)
        {
            //gamepad
            if (gamepad_mode.IsChecked == true)
            {
                mouse_mode.IsChecked = false;
                gesture_mode.IsChecked = false;
            }
            
        }

        private void ToggleButton_Checked_2(object sender, RoutedEventArgs e)
        {
            //gesty
            if (gesture_mode.IsChecked == true)
            {
                gamepad_mode.IsChecked = false;
                mouse_mode.IsChecked = false;
            }

        }

        public void Frame_Navigated(object sender, NavigationEventArgs e)
        {
       
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            mouse_mode.IsChecked = false; gesture_mode.IsChecked = false; gamepad_mode.IsChecked = false;
        }

        private void gesture_frame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}


