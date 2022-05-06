using BusinessLogic.Services;
using Repository.DataAccess;
using Repository.ExternalApi;
using Repository.Models;
using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        long cardNumber;
        int pinCode;
        int attempts;
        Serializer serializer;
        ATMService aTMService;
        ATMRepo aTMRepo;
        ATM atm;
        Card currentCard;

        public Form1()
        {
            InitializeComponent();
            serializer = new Serializer();
            aTMService = new ATMService();
            aTMRepo = new ATMRepo();
            atm = aTMRepo.RetrieveATM();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            cardNumber = Convert.ToInt64(CardNumberTextBox.Text);
            pinCode = Convert.ToInt32(PinCodeTextBox.Text);
            bool isValid = aTMService.Validate(cardNumber, pinCode);
            
            if (isValid)
            {
                currentCard = atm.CardsList.Single(i => i.Id == cardNumber);
                OutputTextBox.Clear();
                OutputTextBox.Text = $"Hello, {currentCard.Client.FullName}!\r\nSelect an action from the menu on the left";
                ShowBalanceButton.Visible = true;
                ShowBalanceButton.Location = new Point(32, 12);
                TransactionsButton.Visible = true;
                TransactionsButton.Location = new Point(32, 41);
                WithdrawButton.Visible = true;
                WithdrawButton.Location = new Point(32, 70);
                CardNumberLabel.Visible = false;
                CardNumberTextBox.Visible = false;
                PinCodeLabel.Visible = false;
                PinCodeTextBox.Visible = false;
                ConfirmButton.Visible = false;
            }
            else
            {
                attempts++;
                if (attempts < 3)
                {
                    OutputTextBox.Clear();
                    OutputTextBox.Text = $"Incorrect password, {3 - attempts} attempt(s) left before card will be blocked and ejected.";
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void ShowBalanceButton_Click(object sender, EventArgs e)
        {
            OutputTextBox.Clear();
            OutputTextBox.Text = $"Balance: ${currentCard.Balance}";
            WithdrawAmountTextBox.Visible = false;
            WithdrawConfirmbutton.Visible = false;
            WithdrawButton.Visible = true;
        }

        private void TransactionsButton_Click(object sender, EventArgs e)
        {
            OutputTextBox.Clear();
            WithdrawAmountTextBox.Visible = false;
            WithdrawConfirmbutton.Visible = false;
            WithdrawButton.Visible = true;
            OutputTextBox.Text = "ID                  DATE                  EXECUTOR          PURPOSE     STATUS    AMOUNT\r\n\r\n";
            foreach (var card in currentCard.TransactionList)
            {
                OutputTextBox.Text += $"{card.Id}      {card.DateOfEvent}       {card.Executor}              {card.Purpose}        {card.Status}        {card.Amount}\r\n\r\n";
            }
        }

        private void WithdrawButton_Click(object sender, EventArgs e)
        {
            OutputTextBox.Text = "Enter amount to withdraw:";
            WithdrawButton.Visible = false;
            WithdrawAmountTextBox.Visible = true;
            WithdrawConfirmbutton.Visible = true;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WithdrawConfirmbutton_Click(object sender, EventArgs e)
        {
            OutputTextBox.Clear();
            string amount = WithdrawAmountTextBox.Text;
            int convertedAmount = int.Parse(amount);

            WithdrawButton.Visible = true;
            WithdrawAmountTextBox.Visible = false;
            WithdrawConfirmbutton.Visible = false;

            if (currentCard.Balance - convertedAmount < 0)
            {
                OutputTextBox.Text = "Insufficient account balance";
                WithdrawAmountTextBox.Clear();

            }
            else
            {
                OutputTextBox.Text = $"Success! Take your ${amount}";
                currentCard.Balance -= convertedAmount;
                currentCard.TransactionList[1].Id -= 1;
                currentCard.TransactionList[2].Id -= 1;
                currentCard.TransactionList[3].Id -= 1;
                currentCard.TransactionList[4].Id -= 1;
                currentCard.TransactionList.RemoveAt(0);
                int transactionId = 5;
                currentCard.TransactionList.Add(new Transaction(transactionId, $"owner", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture), convertedAmount, "cash withdrawal", "outcome"));
                serializer.UpdateDataFile(atm);
            }

            WithdrawAmountTextBox.Clear();
        }
    }
}
