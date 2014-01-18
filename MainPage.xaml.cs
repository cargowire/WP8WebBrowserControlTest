using Microsoft.Phone.Controls;
using Microsoft.Phone.Info;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace PhoneWebBrowserTest
{
    public partial class MainPage : PhoneApplicationPage
    {
        private DispatcherTimer updateTimer;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (this.updateTimer == null)
            {
                this.updateTimer = new DispatcherTimer();
                this.updateTimer.Interval = TimeSpan.FromMilliseconds(2000);
                this.updateTimer.Tick += this.OnTimer;
                this.updateTimer.Start();
            }

            GC.Collect();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.updateTimer.Tick -= this.OnTimer;
            this.updateTimer.Stop();
            this.updateTimer = null;
        }

        private void OnTimer(object sender, EventArgs e)
        {
            this.Memory.Text = (DeviceStatus.ApplicationCurrentMemoryUsage / 1048576.0) + "MB";
        }

        private void Action_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/WebBrowserPage.xaml", UriKind.Relative));
        }
    }
}