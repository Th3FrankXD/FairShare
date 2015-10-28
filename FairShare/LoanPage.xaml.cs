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
    public sealed partial class LoanPage : Page
    {
        Loan selectedLoan;
        public LoanPage()
        {
            this.InitializeComponent();
            FetchLoan();
            fillFields();
        }

        private void FetchLoan()
        {
            foreach(UIButton uiButton in dbManager.uiButtons)
            {
                if (uiButton.Selected)
                {
                    foreach(Loan loan in dbManager.loans)
                    {
                        if (uiButton.ID == loan.ID)
                        {
                            selectedLoan = loan;
                        }
                    }
                }
            }
        }

        private void fillFields()
        {
            if (selectedLoan.GetUser == dbManager.loggedInUser)
            {
                tbNickname.Text = selectedLoan.OweUser.NickName;
                tbDebt.Text = "Owes you:";
                tbAmount.Text = selectedLoan.Amount;
                tbComment.Text = selectedLoan.Comment;
            }
            else
            {
                tbNickname.Text = selectedLoan.GetUser.NickName;
                tbDebt.Text = "Gets from you:";
                tbAmount.Text = selectedLoan.Amount;
                tbComment.Text = selectedLoan.Comment;
            }
        }

        private void bPaid_Click(object sender, RoutedEventArgs e)
        {
            foreach(Loan loan in dbManager.loans)
            {
                if(loan.ID == selectedLoan.ID)
                {
                    dbManager.loans.Remove(loan);
                }
            }
            foreach(UserLoan userLoan in dbManager.userLoans)
            {
                foreach(int loanID in userLoan.Loans)
                {
                    if (loanID.ToString() == selectedLoan.ID)
                    {
                        userLoan.Loans.Remove(loanID);
                    }
                }
            }
            this.Frame.Navigate(typeof(BlankPage));
        }

        private void bCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BlankPage));
        }
    }
}
