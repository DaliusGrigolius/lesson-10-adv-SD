using BusinessLogic.Services;
using Repository.DataAccess;
using Repository.ExternalApi;
using Repository.Models;
using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        long cardNumber;
        int pinCode;
        int attempts;
        int transactionCounter;
        readonly Serializer serializer;
        readonly ATMService aTMService;
        readonly ATMRepo aTMRepo;
        readonly ATM atm;
        Card currentCard;

        public Form1()
        {
            InitializeComponent();
            serializer = new Serializer();
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
            bool regexMatchForCardNumber = Regex.Match(CardNumberTextBox.Text, "^[0-9]{16,16}$").Success;
            bool regexMatchForPin = Regex.Match(PinCodeTextBox.Text, "^[0-9]{4,4}$").Success;
            if(regexMatchForCardNumber && regexMatchForPin)
            {
                bool isValid = aTMService.Validate(cardNumber, pinCode);
                if (isValid) Greetings();
                else ShowErrorMessage();
            }
            else
            {
                OutputTextBox.Text = "Error: not valid card number(16 digits) or pin code(4 digits).";
            }
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
            DepositCashButton.Visible = true;
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
            DepositCashButton.Visible = true;
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
            DepositCashButton.Visible = true;
        }

        private void ShowTransactionList()
        {
            OutputTextBox.Clear();
            WithdrawAmountTextBox.Visible = false;
            WithdrawConfirmbutton.Visible = false;
            WithdrawButton.Visible = true;
            DepositCashTextBox.Visible = false;
            DepositConfirmButton.Visible = false;
            DepositCashButton.Visible = true;
            OutputTextBox.Text = "ID                  DATE                  EXECUTOR             PURPOSE               STATUS         AMOUNT\r\n\r\n";
            var lastFiveTransactions = currentCard.TransactionList.OrderByDescending(t => t.DateOfEvent).Take(5).OrderBy(t => t.DateOfEvent);
            foreach (var t in lastFiveTransactions)
            {
                OutputTextBox.Text += $"{t.Id}      {t.DateOfEvent}       {t.Executor}              {t.Purpose}        {t.Status}        {t.Amount}\r\n\r\n";
            }
        }

        private void ExecuteWithdrawal()
        {
            OutputTextBox.Clear();
            string amount = WithdrawAmountTextBox.Text;
            bool regexMatch = Regex.Match(amount, "^([1-9]|[1-9][0-9]|[1-9][0-9][0-9]|1000)$").Success;
            if (regexMatch)
            {
                var today = DateTime.Now.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                var todaysTransactions = currentCard.TransactionList.FindAll(i => DateTime.Parse(i.DateOfEvent).Date.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture) == today && i.Purpose == "cash withdrawal");
                if (todaysTransactions.Count < 10)
                {
                    int convertedAmount = int.Parse(amount);
                    WithdrawButton.Visible = true;
                    WithdrawAmountTextBox.Visible = false;
                    WithdrawConfirmbutton.Visible = false;
                    DepositCashTextBox.Visible = false;
                    DepositConfirmButton.Visible = false;

                    if (currentCard.Balance - convertedAmount < 1)
                    {
                        OutputTextBox.Text = "Error: insufficient account balance!";
                        WithdrawAmountTextBox.Clear();
                    }
                    else
                    {
                        OutputTextBox.Text = $"Success! Take your ${convertedAmount}";
                        currentCard.Balance -= convertedAmount;
                        int transactionId = currentCard.TransactionList.Count + 1;
                        currentCard.TransactionList.Add(new Transaction(transactionId, $"owner", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture), convertedAmount, "cash withdrawal", "outcome"));
                        serializer.UpdateDataFile(atm);
                        WithdrawAmountTextBox.Clear();
                    }
                }
                else
                {
                    OutputTextBox.Clear();
                    OutputTextBox.Text = "Error: you reached transactions limit/day(10). Please come back tommorow or contact your Bank for more information.";
                    WithdrawAmountTextBox.Visible = false;
                    WithdrawConfirmbutton.Visible = false;
                    WithdrawAmountTextBox.Clear();
                }
            }
            else
            {
                OutputTextBox.Clear();
                OutputTextBox.Text = $"Error. Enter digits from 1 to 1000. Maximum withdrawal amount/day: $1000";
                WithdrawAmountTextBox.Clear();
            }
        }

        private void ExecuteDepositCash()
        {
            OutputTextBox.Clear();
            string amount = DepositCashTextBox.Text;
            bool regexMatch = Regex.Match(amount, "^([1-9]|[1-9][0-9]|[1-9][0-9][0-9]|1000)$").Success;
            if (regexMatch)
            {
                int convertedAmount = int.Parse(amount);
                OutputTextBox.Text = $"Success! ${convertedAmount} was accepted";

                DepositCashTextBox.Visible = false;
                DepositConfirmButton.Visible = false;
                DepositCashButton.Visible = true;

                currentCard.Balance += convertedAmount;
                int transactionId = currentCard.TransactionList.Count + 1;
                currentCard.TransactionList.Add(new Transaction(transactionId, $"owner", DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture), convertedAmount, "cash deposit       ", "income  "));
                serializer.UpdateDataFile(atm);
                DepositCashTextBox.Clear();
            }
            else
            {
                OutputTextBox.Text = $"Error. Enter digits from 1 to 1000. Maximum deposit amount/time: $1000";
                DepositCashTextBox.Clear();
            }
            
        }

        private void CardNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar) && e.KeyChar != 8;
        }

        private void PinCodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar) && e.KeyChar != 8;
        }

        private void WithdrawAmountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar) && e.KeyChar != 8;
        }

        private void DepositCashTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Char.IsNumber(e.KeyChar) && e.KeyChar != 8;
        }
    }
}
