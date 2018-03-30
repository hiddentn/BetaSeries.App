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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BetaSeries.TestApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string ApiKey = "91c4aafe663a";
        string UsrAgent = "TestApp";
        UserService UserManger;
        public MainPage()
        {
            this.InitializeComponent();
            UserManger = new UserService();
            UserManger.ApiKey = ApiKey;
            UserManger.UserAgent = UsrAgent;
            
        }

        private  async void Page_Loaded(object sender, RoutedEventArgs e)

        {
           RootAuth User = await  UserManger.AuthenticateMember("mdr120", "benammar120");
            UserManger.Token = User.Token;
            RootMember UserInfo = await UserManger.GetUserInfo();

        }
    }
}
