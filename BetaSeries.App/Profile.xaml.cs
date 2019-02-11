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
using BetaSeries.API.Model;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BetaSeries.App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Profile : Page
    {
        UserService US;
        BadgeService BS;
        AppUser User;
        RootMember UserInfo;

        public Profile()
        {
            this.InitializeComponent();
            User = new AppUser();
            US = new UserService(Config.AppConfig.ApiKey, Config.AppConfig.UserAgent, User.Token);
            BS = new BadgeService(Config.AppConfig.ApiKey, Config.AppConfig.UserAgent, User.Token);
            
        }

        private  async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UserInfo = await US.GetUserInfo();
            if (UserInfo.Err.Count == 0 )
            {
                ProfileBanner.Source = UserInfo.User.Banner;
                ProfilePic.Source = UserInfo.User.Avatar;
                UserNameTB.Text = $"{UserInfo.User.login}#{UserInfo.User.Id}";
                BadgeList Badges = await BS.GetUserBadges(UserInfo.User.Id);
                BadgesView.ItemsSource = Badges.Badges;
            }

        }
    }
}
