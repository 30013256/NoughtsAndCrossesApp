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
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = false;
            this.InitializeComponent();
            var appView = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
            appView.TitleBar.BackgroundColor = Windows.UI.ColorHelper.FromArgb(255, 61, 243, 28);
            appView.TitleBar.InactiveBackgroundColor = Windows.UI.ColorHelper.FromArgb(255, 61, 243, 28);
            appView.TitleBar.ButtonBackgroundColor = Windows.UI.ColorHelper.FromArgb(255, 61, 243, 28);
            appView.TitleBar.ButtonHoverBackgroundColor = Windows.UI.ColorHelper.FromArgb(255, 150, 243, 130);
            appView.TitleBar.ButtonPressedBackgroundColor = Windows.UI.ColorHelper.FromArgb(255, 61, 243, 28);
            appView.TitleBar.ButtonInactiveBackgroundColor = Windows.UI.ColorHelper.FromArgb(255, 61, 243, 28);

            ContentContainer.Navigate(typeof(HomePage));
        }

        private void BtnTogglePane_Click(object sender, RoutedEventArgs e)
        {
            SplitViewMP.IsPaneOpen ^= true;
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
    }
}
