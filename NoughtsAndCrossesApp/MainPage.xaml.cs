using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NoughtsAndCrossesApp
{
    /// <summary>
    /// Main Page of app provides navigtion
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {           
            this.InitializeComponent();

            //Romove Title Bar
            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
            //Set Dragable Region
            coreTitleBar.LayoutMetricsChanged += CoreTitleBar_LayoutMetricsChanged;
            Window.Current.SetTitleBar(AppTitleBar);
            //Load Home Page
            ContentContainer.Navigate(typeof(HomePage));
        }

        private void CoreTitleBar_LayoutMetricsChanged(CoreApplicationViewTitleBar sender, object args)
        {
            AppTitleBar.Height = sender.Height;
        }

        private void BtnTogglePane_Click(object sender, RoutedEventArgs e)
        {
            SplitViewMP.IsPaneOpen ^= true;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (ContentContainer.CanGoBack)
            {
                ContentContainer.GoBack();
            }
        }

        private void btnMultiplayer_Click(object sender, RoutedEventArgs e)
        {
            ContentContainer.Navigate(typeof(MultiplayerPage));
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            ContentContainer.Navigate(typeof(HomePage));
        }

        private void btnSingleplayer_Click(object sender, RoutedEventArgs e)
        {
            ContentContainer.Navigate(typeof(SingleplayerPage));
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            ContentContainer.Navigate(typeof(SettingsPage));
        }
    }
}
