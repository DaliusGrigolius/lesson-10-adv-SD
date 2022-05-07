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
            serializer = new Serializer(new ATMRepo(new Deserializer()));
            aTMService = new ATMService(new ATMRepo(new Deserializer()));
            aTMRepo = new ATMRepo(new Deserializer());
            atm = aTMRepo.RetrieveATM();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            ExecuteValidation();
        }

        private void ShowBalanceButton_Click(object sender, EventArgs e)
        {
            ShowBalance();
        }

        private void TransactionsButton_Click(object sender, EventArgs e)
        {
            ShowTransactionList();
        }

        private void WithdrawButton_Click(object sender, EventArgs e)
        {
            ShowWithdrawalPanel();
        }

        private void DepositCashButton_Click(object sender, EventArgs e)
        {
            ShowDepositCashPanel();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void WithdrawConfirmbutton_Click(object sender, EventArgs e)
        {
            ExecuteWithdrawal();
        }

        private void DepositConfirmButton_Click(object sender, EventArgs e)
        {
            ExecuteDepositCash();
        }

        private void ExecuteValidation()
        {
            cardNumber = Convert.ToInt64(CardNumberTextBox.Text);
            pinCode = Convert.ToInt32(PinCodeTextBox.Text);
            bool isValid = aTMService.Validate(cardNumber, pinCode);

            if (isValid) Greetings();
            else ShowErrorMessage();
        }

        private void Greetings()
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
            DepositCashButton.Visible = true;
            DepositCashButton.Location = new Point(32, 99);
            CardNumberLabel.Visible = false;
            CardNumberTextBox.Visible = false;
            PinCodeLabel.Visible = false;
            PinCodeTextBox.Visible = false;
            ConfirmButton.Visible = false;
            DepositCashTextBox.Visible = false;
            DepositConfirmButton.Visible = false;
        }

        private void ShowErrorMessage()
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

        private void ShowWithdrawalPanel()
        {
            OutputTextBox.Text = "Enter amount to withdraw:";
            WithdrawButton.Visible = false;
            WithdrawAmountTextBox.Visible = true;
            WithdrawConfirmbutton.Visible = true;
            DepositCashTextBox.Visible = false;
            DepositConfirmButton.Visible = false;
        }

        private void ShowDepositCashPanel()
        {
            OutputTextBox.Text = "Enter amount to deposit:";
            WithdrawButton.Visible = true;
            WithdrawAmountTextBox.Visible = false;
            WithdrawConfirmbutton.Visible = false;
            DepositCashButton.Visible = false;
            DepositCashTextBox.Visible = true;
            DepositCashTextBox.Location = new Point(262, 46);
            DepositConfirmButton.Visible = true;
            DepositConfirmButton.Location = new Point(262, 75);
        }

        private void ShowBalance()
        {
            OutputTextBox.Clear();
            OutputTextBox.Text = $"Balance: ${currentCard.Balance}";
            WithdrawAmountTextBox.Visible = false;
            WithdrawConfirmbutton.Visible = false;
            WithdrawButton.Visible = true;
            DepositCashTextBox.Visible = false;
            DepositConfirmButton.Visible = false;
        }

        private void ShowTransactionList()
        {
            OutputTextBox.Clear();
            WithdrawAmountTextBox.Visible = false;
            WithdrawConfirmbutton.Visible = false;
            WithdrawButton.Visible = true;
            DepositCashTextBox.Visible = false;
            DepositConfirmButton.Visible = false;
            OutputTextBox.Text = "ID                  DATE                  EXECUTOR             PURPOSE               STATUS         AMOUNT\r\n\r\n";
            foreach (var card in currentCard.TransactionList)
            {
                OutputTextBox.Text += $"{card.Id}      {card.DateOfEvent}       {card.Executor}              {card.Purpose}        {card.Status}        {card.Amount}\r\n\r\n";
            }
        }

        private void ExecuteWithdrawal()
        {
            OutputTextBox.Clear();
            string amount = WithdrawAmountTextBox.Text;
            int convertedAmount = int.Parse(amount);

            WithdrawButton.Visible = true;
            WithdrawAmountTextBox.Visible = false;
            WithdrawConfirmbutton.Visible = false;
            DepositCashTextBox.Visible = false;
            DepositConfirmButton.Visible = false;

            if (currentCard.Balance - convertedAmount < 10)
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
                currentCard.TransactionList.Add(new Transaction(5, $"owner", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture), convertedAmount, "cash withdrawal", "outcome"));
                serializer.UpdateDataFile(atm);
            }

            WithdrawAmountTextBox.Clear();
        }

        private void ExecuteDepositCash()
        {
            OutputTextBox.Clear();
            string amount = DepositCashTextBox.Text;
            int convertedAmount = int.Parse(amount);
            OutputTextBox.Text = $"Success! ${convertedAmount} was accepted";

            DepositCashTextBox.Visible = false;
            DepositConfirmButton.Visible = false;
            DepositCashButton.Visible = true;

            currentCard.Balance += convertedAmount;
            currentCard.TransactionList[1].Id -= 1;
            currentCard.TransactionList[2].Id -= 1;
            currentCard.TransactionList[3].Id -= 1;
            currentCard.TransactionList[4].Id -= 1;
            currentCard.TransactionList.RemoveAt(0);
            currentCard.TransactionList.Add(new Transaction(5, $"owner", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture), convertedAmount, "cash deposit", "income"));
            serializer.UpdateDataFile(atm);

            DepositCashTextBox.Clear();
        }
    }
}
