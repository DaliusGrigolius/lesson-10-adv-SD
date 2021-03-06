namespace WinFormsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CardNumberLabel = new System.Windows.Forms.Label();
            this.CardNumberTextBox = new System.Windows.Forms.TextBox();
            this.OutputTextBox = new System.Windows.Forms.TextBox();
            this.PinCodeTextBox = new System.Windows.Forms.TextBox();
            this.PinCodeLabel = new System.Windows.Forms.Label();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.ShowBalanceButton = new System.Windows.Forms.Button();
            this.TransactionsButton = new System.Windows.Forms.Button();
            this.WithdrawButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.WithdrawAmountTextBox = new System.Windows.Forms.TextBox();
            this.WithdrawConfirmbutton = new System.Windows.Forms.Button();
            this.DepositCashButton = new System.Windows.Forms.Button();
            this.DepositCashTextBox = new System.Windows.Forms.TextBox();
            this.DepositConfirmButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CardNumberLabel
            // 
            this.CardNumberLabel.AutoSize = true;
            this.CardNumberLabel.Location = new System.Drawing.Point(12, 16);
            this.CardNumberLabel.Name = "CardNumberLabel";
            this.CardNumberLabel.Size = new System.Drawing.Size(109, 15);
            this.CardNumberLabel.TabIndex = 0;
            this.CardNumberLabel.Text = "Enter Card Number";
            // 
            // CardNumberTextBox
            // 
            this.CardNumberTextBox.Location = new System.Drawing.Point(126, 12);
            this.CardNumberTextBox.Name = "CardNumberTextBox";
            this.CardNumberTextBox.Size = new System.Drawing.Size(121, 23);
            this.CardNumberTextBox.TabIndex = 1;
            this.CardNumberTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CardNumberTextBox_KeyPress);
            // 
            // OutputTextBox
            // 
            this.OutputTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.OutputTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OutputTextBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.OutputTextBox.Location = new System.Drawing.Point(253, 12);
            this.OutputTextBox.Multiline = true;
            this.OutputTextBox.Name = "OutputTextBox";
            this.OutputTextBox.ReadOnly = true;
            this.OutputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.OutputTextBox.Size = new System.Drawing.Size(517, 226);
            this.OutputTextBox.TabIndex = 2;
            // 
            // PinCodeTextBox
            // 
            this.PinCodeTextBox.Location = new System.Drawing.Point(126, 46);
            this.PinCodeTextBox.Name = "PinCodeTextBox";
            this.PinCodeTextBox.Size = new System.Drawing.Size(121, 23);
            this.PinCodeTextBox.TabIndex = 3;
            this.PinCodeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PinCodeTextBox_KeyPress);
            // 
            // PinCodeLabel
            // 
            this.PinCodeLabel.AutoSize = true;
            this.PinCodeLabel.Location = new System.Drawing.Point(13, 50);
            this.PinCodeLabel.Name = "PinCodeLabel";
            this.PinCodeLabel.Size = new System.Drawing.Size(85, 15);
            this.PinCodeLabel.TabIndex = 4;
            this.PinCodeLabel.Text = "Enter Pin Code";
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(126, 75);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(121, 23);
            this.ConfirmButton.TabIndex = 5;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // ShowBalanceButton
            // 
            this.ShowBalanceButton.Location = new System.Drawing.Point(32, 102);
            this.ShowBalanceButton.Name = "ShowBalanceButton";
            this.ShowBalanceButton.Size = new System.Drawing.Size(215, 23);
            this.ShowBalanceButton.TabIndex = 6;
            this.ShowBalanceButton.Text = "Balance";
            this.ShowBalanceButton.UseVisualStyleBackColor = true;
            this.ShowBalanceButton.Visible = false;
            this.ShowBalanceButton.Click += new System.EventHandler(this.ShowBalanceButton_Click);
            // 
            // TransactionsButton
            // 
            this.TransactionsButton.Location = new System.Drawing.Point(32, 130);
            this.TransactionsButton.Name = "TransactionsButton";
            this.TransactionsButton.Size = new System.Drawing.Size(215, 23);
            this.TransactionsButton.TabIndex = 7;
            this.TransactionsButton.Text = "Last 5 Transactions";
            this.TransactionsButton.UseVisualStyleBackColor = true;
            this.TransactionsButton.Visible = false;
            this.TransactionsButton.Click += new System.EventHandler(this.TransactionsButton_Click);
            // 
            // WithdrawButton
            // 
            this.WithdrawButton.Location = new System.Drawing.Point(32, 159);
            this.WithdrawButton.Name = "WithdrawButton";
            this.WithdrawButton.Size = new System.Drawing.Size(215, 23);
            this.WithdrawButton.TabIndex = 8;
            this.WithdrawButton.Text = "Withdraw";
            this.WithdrawButton.UseVisualStyleBackColor = true;
            this.WithdrawButton.Visible = false;
            this.WithdrawButton.Click += new System.EventHandler(this.WithdrawButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(32, 215);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(215, 23);
            this.ExitButton.TabIndex = 9;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // WithdrawAmountTextBox
            // 
            this.WithdrawAmountTextBox.Location = new System.Drawing.Point(262, 46);
            this.WithdrawAmountTextBox.Name = "WithdrawAmountTextBox";
            this.WithdrawAmountTextBox.Size = new System.Drawing.Size(100, 23);
            this.WithdrawAmountTextBox.TabIndex = 10;
            this.WithdrawAmountTextBox.Visible = false;
            this.WithdrawAmountTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.WithdrawAmountTextBox_KeyPress);
            // 
            // WithdrawConfirmbutton
            // 
            this.WithdrawConfirmbutton.Location = new System.Drawing.Point(262, 75);
            this.WithdrawConfirmbutton.Name = "WithdrawConfirmbutton";
            this.WithdrawConfirmbutton.Size = new System.Drawing.Size(100, 23);
            this.WithdrawConfirmbutton.TabIndex = 11;
            this.WithdrawConfirmbutton.Text = "Withdraw";
            this.WithdrawConfirmbutton.UseVisualStyleBackColor = true;
            this.WithdrawConfirmbutton.Visible = false;
            this.WithdrawConfirmbutton.Click += new System.EventHandler(this.WithdrawConfirmbutton_Click);
            // 
            // DepositCashButton
            // 
            this.DepositCashButton.Location = new System.Drawing.Point(32, 187);
            this.DepositCashButton.Name = "DepositCashButton";
            this.DepositCashButton.Size = new System.Drawing.Size(215, 23);
            this.DepositCashButton.TabIndex = 12;
            this.DepositCashButton.Text = "Deposit Cash";
            this.DepositCashButton.UseVisualStyleBackColor = true;
            this.DepositCashButton.Visible = false;
            this.DepositCashButton.Click += new System.EventHandler(this.DepositCashButton_Click);
            // 
            // DepositCashTextBox
            // 
            this.DepositCashTextBox.Location = new System.Drawing.Point(368, 46);
            this.DepositCashTextBox.Name = "DepositCashTextBox";
            this.DepositCashTextBox.Size = new System.Drawing.Size(100, 23);
            this.DepositCashTextBox.TabIndex = 13;
            this.DepositCashTextBox.Visible = false;
            this.DepositCashTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DepositCashTextBox_KeyPress);
            // 
            // DepositConfirmButton
            // 
            this.DepositConfirmButton.Location = new System.Drawing.Point(368, 75);
            this.DepositConfirmButton.Name = "DepositConfirmButton";
            this.DepositConfirmButton.Size = new System.Drawing.Size(100, 23);
            this.DepositConfirmButton.TabIndex = 14;
            this.DepositConfirmButton.Text = "Deposit Cash";
            this.DepositConfirmButton.UseVisualStyleBackColor = true;
            this.DepositConfirmButton.Visible = false;
            this.DepositConfirmButton.Click += new System.EventHandler(this.DepositConfirmButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(796, 260);
            this.Controls.Add(this.DepositConfirmButton);
            this.Controls.Add(this.DepositCashTextBox);
            this.Controls.Add(this.DepositCashButton);
            this.Controls.Add(this.WithdrawConfirmbutton);
            this.Controls.Add(this.WithdrawAmountTextBox);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.WithdrawButton);
            this.Controls.Add(this.TransactionsButton);
            this.Controls.Add(this.ShowBalanceButton);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.PinCodeLabel);
            this.Controls.Add(this.PinCodeTextBox);
            this.Controls.Add(this.OutputTextBox);
            this.Controls.Add(this.CardNumberTextBox);
            this.Controls.Add(this.CardNumberLabel);
            this.Name = "Form1";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CardNumberLabel;
        private System.Windows.Forms.TextBox CardNumberTextBox;
        private System.Windows.Forms.TextBox OutputTextBox;
        private System.Windows.Forms.TextBox PinCodeTextBox;
        private System.Windows.Forms.Label PinCodeLabel;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Button ShowBalanceButton;
        private System.Windows.Forms.Button TransactionsButton;
        private System.Windows.Forms.Button WithdrawButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.TextBox WithdrawAmountTextBox;
        private System.Windows.Forms.Button WithdrawConfirmbutton;
        private System.Windows.Forms.Button DepositCashButton;
        private System.Windows.Forms.TextBox DepositCashTextBox;
        private System.Windows.Forms.Button DepositConfirmButton;
    }
}
