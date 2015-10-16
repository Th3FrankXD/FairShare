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
    public sealed partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            this.InitializeComponent();
        }

        private void bCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(LoginPage));
        }

        async private void bRegister_Click(object sender, RoutedEventArgs e)
        {
            string nickName = reNickName.Text;
            string email = reEmail.Text;
            string password = pbPassword.Password;
            string repeatPassword = pbRepeatPassword.Password;

            if (nickName != "" && email != "" && password != "" && repeatPassword != "")
            {
                if (pbPassword.Password == pbRepeatPassword.Password)
                {
                    if (dbManager.getUser(email) == null)
                    {
                        dbManager.addUser(nickName, email, password);
                        this.Frame.Navigate(typeof(LoginPage));
                    }
                    else
                    {
                        var dialog = new MessageDialog("Email address is already in use!");
                        dialog.Commands.Add(new UICommand { Label = "Ok", Id = 0 });
                        await dialog.ShowAsync();
                    }
                }
                else
                {
                    var dialog = new MessageDialog("Passwords do not match!");
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
