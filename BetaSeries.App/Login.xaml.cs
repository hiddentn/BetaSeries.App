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
    public sealed partial class Login : Page
    {
        DispatcherTimer FlipFiewDispatchTimer;
        UserService US;
        RootAuth BetaUser;
        AppUser User;

        public Login()
        {
            this.InitializeComponent();
            //Misc
            BGFlipView.Loaded += FlipView_Loaded;
            BGFlipView.ItemsSource = Config.loginBG.BGList;
            FlipFiewDispatchTimer = new DispatcherTimer();
            FlipFiewDispatchTimer.Tick += FlipView_Play;
            FlipFiewDispatchTimer.Interval = new TimeSpan(0, 0,5);
            FlipFiewDispatchTimer.Start();
            //Api Part
            US = new UserService(Config.AppConfig.ApiKey, Config.AppConfig.UserAgent);
            //App DataVault
            User = new AppUser();
        }

        private void BGFlipView_Loaded(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void FlipView_Play(object sender, object e)
        {
            int X = BGFlipView.SelectedIndex;
            X++;
            X= X % 15;
            BGFlipView.SelectedIndex = X;
        }

        //Btn Removal 
        private void FlipView_Loaded(object sender, RoutedEventArgs e)
        {
            Grid grid = (Grid)VisualTreeHelper.GetChild(BGFlipView, 0);
            for (int i = grid.Children.Count - 1; i >= 0; i--)
                if (grid.Children[i] is Button)
                    grid.Children.RemoveAt(i);
        }

        private async void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string Username = UsernameTB.Text;
            string Password = PasswordTB.Password;
            BetaUser =  await US.AuthenticateMember(Username, Password);
            if (BetaUser.Token != null) 
            {
              
                    User.UpdateCredentials(BetaUser.User.Login, BetaUser.Token);
                    Frame.Navigate(typeof(Shell));
            }
            else
            {
                if(BetaUser.Err.Count != 0)
                {
                    ErrorTB.Visibility = Visibility.Visible;
                }
            }

            

        }
    }
}
