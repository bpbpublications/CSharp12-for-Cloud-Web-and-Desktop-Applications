using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WinUISampleProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
            this.InitializeComponent();
        }
        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            PayloadDTO payloadDTO = new PayloadDTO();
            if (!string.IsNullOrEmpty(name.Text))
                payloadDTO.Name = name.Text;
            if (feelings.SelectedItem != null)
                payloadDTO.Feel = feelings.SelectedItem.ToString();

            Frame.Navigate(typeof(NewPage), payloadDTO);
        }
        private void SourceImage_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Frame.Navigate(typeof(DestinationAnimation), null, new SuppressNavigationTransitionInfo());
        }
        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            ConnectedAnimationService.GetForCurrentView()
                .PrepareToAnimate("forwardAnimation", SourceImage);

        }
    }
}
