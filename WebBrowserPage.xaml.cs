using Microsoft.Phone.Controls;
using Microsoft.Phone.Info;
using System;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace PhoneWebBrowserTest
{
    public partial class WebBrowserPage : PhoneApplicationPage
    {
        private DispatcherTimer updateTimer;

        public WebBrowserPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            this.browser.Navigated -= browser_Navigated;
            this.updateTimer.Stop();
            this.updateTimer.Tick -= this.OnTimer;
            this.updateTimer = null;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (this.updateTimer == null)
            {
                this.updateTimer = new DispatcherTimer();
                this.updateTimer.Interval = TimeSpan.FromMilliseconds(2000);
                this.updateTimer.Tick += this.OnTimer;
                this.updateTimer.Start();

                this.browser.Navigated += browser_Navigated;
            }
        }

        private void browser_Navigated(object sender, NavigationEventArgs e)
        {
            browser.ClearInternetCacheAsync();
            browser.ClearCookiesAsync();
        }

        private void OnTimer(object sender, EventArgs e)
        {
            this.Memory.Text = (DeviceStatus.ApplicationCurrentMemoryUsage / 1048576.0) + "MB";
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            browser.InvokeScript("eval", "location.reload();");
        }

        private void Blank_Click(object sender, RoutedEventArgs e)
        {
            browser.Navigate(new Uri("about:blank"));
            browser.ClearInternetCacheAsync();
            browser.ClearCookiesAsync();
        }

        private void Nav_Click(object sender, RoutedEventArgs e)
        {
            browser.Navigate(new Uri("about:blank"));
            this.NavigationService.GoBack();
        }
    }
}