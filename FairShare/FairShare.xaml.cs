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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FairShare
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FairShare : Page
    {
        public FairShare()
        {
            this.InitializeComponent();
            LoadLoans();
        }

        public void AddLoanButton()
        {
            Button button = new Button();
            button.Width = 250;
            button.Content = "Add new loan";
            stackPanel.Children.Add(button);
            button.Click += addLoan_Click;
        }

        public void RemoveButtons()
        {
            foreach (Button button in stackPanel.Children.OfType<Button>())
            {
                stackPanel.Children.Remove(button);
            }
        }

        public void LoadLoans()
        {
            RemoveButtons();
            if (dbManager.userLoans[dbManager.loggedInUser.ID].Loans != null)
            {
                foreach (int loanID in dbManager.userLoans[dbManager.loggedInUser.ID].Loans)
                {
                    foreach (Loan loan in dbManager.loans)
                    {
                        if (loanID == loan.ID)
                        {
                            Button button = new Button();
                            button.Width = 250;
                            button.Name = loanID.ToString();
                            if(loan.GetUser == dbManager.loggedInUser)
                            {
                                button.Content = "get " + loan.Amount + " from " + loan.OweUser.NickName;
                            }
                            else
                            {
                                button.Content = "owe " + loan.Amount + " to " + loan.GetUser.NickName;
                            }
                            stackPanel.Children.Add(button);
                        }
                    }
                }
            }
            AddLoanButton();
        }

        private void addLoan_Click(object sender, RoutedEventArgs e)
        {
            this.SplitViewFrame.Navigate(typeof(AddLoanPage));
            LoadLoans();
        }
    }
}