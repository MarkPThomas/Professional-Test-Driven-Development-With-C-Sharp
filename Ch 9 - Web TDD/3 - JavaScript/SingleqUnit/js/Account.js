function Account (accountNumber, balance)
{
    this.AccountNumber = accountNumber;
    this.Balance = balance;
}

Account.prototype.Transfer = function(toAccount, amount)
{
    if (this.Balance < amount) {
        return;
    }

    toAccount.Balance += amount;
    this.Balance = this.Balance - amount;
}