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
            
            this.InitializeComponent();
            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
            coreTitleBar.LayoutMetricsChanged += CoreTitleBar_LayoutMetricsChanged;
            // Set XAML element as a draggable region.
            Window.Current.SetTitleBar(AppTitleBar);

            ContentContainer.Navigate(typeof(HomePage));
        }

        public void Theme()
        {
            var uiSettings = new Windows.UI.ViewManagement.UISettings();
            var rgba = uiSettings.GetColorValue(Windows.UI.ViewManagement.UIColorType.Accent);
            var cssColorString = "rgba(" + rgba.r + "," + rgba.g + "," + rgba.b + ", " + rgba.a + ")";

            if(rgba.A >= 160)
        }

        private void CoreTitleBar_LayoutMetricsChanged(CoreApplicationViewTitleBar sender, object args)
        {
            AppTitleBar.Height = sender.Height;
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
