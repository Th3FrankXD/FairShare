using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FairShare
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private void bRegister_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RegisterPage));
        }

        async private void bLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = reEmail.Text;
            string password = pbPassword.Password;

            if (email != "" && password != "")
            {
                if (dbManager.loginUser(email, password) != null)
                {
                    this.Frame.Navigate(typeof(FairShare));
                }
                else
                {
                    var dialog = new MessageDialog("Incorrect credentials!");
                    dialog.Commands.Add(new UICommand { Label = "Ok", Id = 0 });
                    await dialog.ShowAsync();
                }
            }
            else
            {
                var dialog = new MessageDialog("Some fields are empty!");
                dialog.Commands.Add(new UICommand { Label = "Ok", Id = 0 });
                await dialog.ShowAsync();
            }
        }
    }
}
