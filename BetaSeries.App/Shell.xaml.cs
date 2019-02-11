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
using BetaSeries.API;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BetaSeries.App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Shell : Page
    {
        UserService US;
        AppUser User;
        public Shell()
        {
            this.InitializeComponent();
            User = new AppUser();

        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                ContentFrame.Navigate(typeof(Settings));
            }
            else
            {
                // find NavigationViewItem with Content that equals InvokedItem
                var item = sender.MenuItems.OfType<NavigationViewItem>().First(x => (string)x.Content == (string)args.InvokedItem);
                NavView_Navigate(item as NavigationViewItem);
            }

        }
        private async void NavView_Navigate(NavigationViewItem item)
        {
            switch (item.Tag)
            {
                case "MyFeed":
                    if (await US.Logout())
                    {
                        User.RemoveCredentials();
                        Frame.Navigate(typeof(Shell));
                    };
                    break;
                case "Profile":
                    ContentFrame.Navigate(typeof(Profile));
                    break;
            }
        }
























        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (User.IsAuthenticated)
            {
                US = new UserService(Config.AppConfig.ApiKey, Config.AppConfig.UserAgent, User.Token);
                //ContentFrame Navigation 
            }
            else
            {
                //LogInFrame Navigation
                Frame.Navigate(typeof(Login));
            }

        }


    }
}
