using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork13._7.BankSystem.BankAccounts.Interfaces
{
    internal interface IMoneyTransfer<in S> 
        where S : BankAccount
    {
        void MoneyTransferCov(Client recipient, S recipientAccount, double value);
    }
}
