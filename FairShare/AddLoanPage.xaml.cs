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
    public sealed partial class AddLoanPage : Page
    {
        public AddLoanPage()
        {
            this.InitializeComponent();
        }

        async private void bAdd_Click(object sender, RoutedEventArgs e)
        {
            string email = reEmail.Text;
            bool owes = rbOwes.IsEnabled;
            bool gets = rbGets.IsEnabled;
            string euro = reEuro.Text;
            string cent = reCent.Text;
            string amount = euro + "," + cent;
            string comment = reComment.Text;
            
            if (email != "" && (owes || gets) && euro != "")
            {
                if (dbManager.getUser(email) != null && email != dbManager.loggedInUser.Email)
                {
                    try
                    {
                        int validateCurrency = Int32.Parse(euro + cent);

                        if (owes)
                        {
                            dbManager.addLoan(dbManager.loggedInUser, dbManager.getUser(email), amount, comment);
                            this.Frame.Navigate(typeof(FairShare));
                        }
                        else
                        {
                            dbManager.addLoan(dbManager.getUser(email), dbManager.loggedInUser, amount, comment);
                            this.Frame.Navigate(typeof(FairShare));
                        }
                    }
                    catch
                    {
                        var dialog = new MessageDialog("Invalid currency");
                        dialog.Commands.Add(new UICommand { Label = "Ok", Id = 0 });
                        await dialog.ShowAsync();
                    }        
                }
                else
                {
                    var dialog = new MessageDialog("Email address Does not excist");
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

        private void bCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FairShare));
        }
    }
}
