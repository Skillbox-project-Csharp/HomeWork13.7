using HomeWork13._7.BankSystem.BankAccounts.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork13._7.BankSystem.BankAccounts
{
    internal class NoDepositAccount : BankAccount, INotifyPropertyChanged , IReplenishment<BankAccount>, IMoneyTransfer<BankAccount>
    {
        //костыль
        public override Type TypeAccount { get; set; } = typeof(NoDepositAccount);
        public NoDepositAccount(Guid id, double money) : base(id, money) { }
        public NoDepositAccount()
            : base(Guid.NewGuid(), 0) { }
        public override bool AddMoney(double value)
        {
            bool isAdded = base.AddMoney(value);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Money)));
            return isAdded;
        }

        public override event PropertyChangedEventHandler PropertyChanged;

        public override bool SubMoney(double value)
        {
            bool isSubed = base.SubMoney(value);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Money)));
            return isSubed;
        }

        public override BankAccount Replenishment(double value)
        {
            this.AddMoney(value);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Money)));
            return new BankAccount(this.Id, this.Money);
        }

        public override void MoneyTransferCov(Client recipient, BankAccount recipientAccount, double value)
        {
            int indexSenderAccount = recipient.BankAccounts.IndexOf(recipientAccount);
            if (indexSenderAccount != -1)
                if (!recipientAccount.Equals(this))
                    if (this.SubMoney(value))
                    {
                        if (recipient.BankAccounts[indexSenderAccount].AddMoney(value)) { }
                        else
                        {
                            this.AddMoney(value);

                        }
                    }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Money)));
        }
    }
}
