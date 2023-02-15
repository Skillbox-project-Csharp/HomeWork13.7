using HomeWork13._7.BankSystem.BankAccounts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork13._7.BankSystem.BankAccounts
{
    internal class BankAccount :  IAddMoney, ISubMoney, IEquatable<BankAccount>, IReplenishment<BankAccount>, IMoneyTransfer<BankAccount>
    {
        protected double _money;
        protected Guid _id;

        public double  Money => _money;
        public Guid Id => _id;
        //костыль
        public virtual Type TypeAccount { get; set; } = typeof(BankAccount);

        public BankAccount(Guid id, double money)
        {
            _id = id;
            _money = money;
        }
        public BankAccount()
            : this(Guid.NewGuid(), 0) { }

        public virtual bool AddMoney(double value)
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

        public virtual bool SubMoney(double value)
        {
            if (value <= 0)
                return false;
            if (Money - value >= 0)
            {
                _money -= value;
                return true;
            }
            return false;
        }
        public bool Equals(BankAccount other)
        {
            return Id == other.Id;
        }

        public virtual BankAccount Replenishment(double value)
        {
            this.AddMoney(value);
            return new BankAccount(this.Id, this.Money);
        }

        public virtual void MoneyTransferCov(Client recipient, BankAccount recipientAccount, double value)
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
