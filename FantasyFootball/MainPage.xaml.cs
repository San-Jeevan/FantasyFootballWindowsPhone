using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using FantasyFootball.Resources;
using System.Text;
using System.Diagnostics;

namespace FantasyFootball
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor

        public MainPage()
        {
            InitializeComponent();

            minBrowser.Height = Application.Current.Host.Content.ActualHeight;
            minBrowser.Width = Application.Current.Host.Content.ActualWidth;

            var email = "sanjeevan@outlook.com";
            var password = "ohyou..:)";

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 8)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            

            //var token = "4lQ9gLDWdgpZ";
            var token2 = Convert.ToBase64String(Encoding.Unicode.GetBytes(result));
            var token = token2.Substring(0, 11).Replace("=","i");
            string postDataString = "csrfmiddlewaretoken=" + token + "&email=" + email + "&" + "password=" + password + "&Submit=Submit&success=http%3A%2F%2Fm.fantasy.premierleague.com%2Faccounts%2Flogin%2F&fail=http%3A%2F%2Fm.fantasy.premierleague.com%2F%3Ffail";
            byte[] postData = Encoding.UTF8.GetBytes(postDataString);
            const string additionalHeaders = "Content-Type: application/x-www-form-urlencoded";

            minBrowser.Navigate(new Uri("https://users.premierleague.com/PremierUser/redirectLogin"), postData, additionalHeaders);



        }

     


        //this is an alternative method of auto-logging in, it can be used if fantasy.premierleague guys find a way to block the current method
        //void minBrowser_LoadCompleted(object sender, NavigationEventArgs e)
        //{
        //     var baseenc ="|PLUSER COOKIE VALUE HERE|";

        //    string cookieString = minBrowser.InvokeScript("eval", new string[] { "document.cookie;" }) as string;
        //    if (cookieString.Contains("pluser"))
        //    {
        //        return;
        //    }
        //    var command = "document.cookie=\"pluser="+baseenc+";domain=.m.fantasy.premierleague.com;\";";
        //    minBrowser.InvokeScript("eval", command);
        //    minBrowser.Navigate(new Uri("http://m.fantasy.premierleague.com/my-team/"));
          
        //}



        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
        private void Settings_OnClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void About_OnClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}