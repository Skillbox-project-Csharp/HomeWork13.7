using HomeWork13._7.BankSystem.BankAccounts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork13._7.BankSystem.BankAccounts
{
    internal class DepositAccount : BankAccount, IReplenishment<BankAccount>, IMoneyTransfer<BankAccount>
    {
        //костыль
        public override Type TypeAccount { get ; set ; } = typeof(DepositAccount);
        public DepositAccount(Guid id, double money) : base(id, money) { }
        public DepositAccount()
            : base(Guid.NewGuid(), 0) { }
        public override bool AddMoney(double value)
        {
            if (value <= 0)
                return false;
            if (Money + value > 0)
            {
                _money += value;
                return true;
            }
            return false;
        }

        public override bool SubMoney(double value)
        {
            return false;
        }

        public override BankAccount Replenishment(double value)
        {
            this.AddMoney(value);
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
        }
    }
}
