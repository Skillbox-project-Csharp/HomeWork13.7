using HomeWork13._7.BankSystem;
using HomeWork13._7.BankSystem.BankAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork13._7.BankWorkers
{
    internal class Manager : Worker
    {
        public override event Action<Worker, object, object, bool> OpenCloseBankAccountEvent;
        public override event Action<Worker, object, object, object, object, object, bool> MoneyTransferEvent;
        public override event Action<Worker, object, object, object, bool> ReplenishmentAccountEvent;

        public Manager(string name, string surName, string patronymic)
        {
            Name = name;
            SurName = surName;
            Patronymic = patronymic;
        }

        public override bool CloseBankAccount<T>(Client client, T bankAccount)
        {
            bool statusOperation = Bank.CloseBankAccount(client, bankAccount);
            OpenCloseBankAccountEvent?.Invoke(this,client,bankAccount, statusOperation);
            return statusOperation;
        }
        public override bool OpenNewBankAccount<T>(Client client, T bankAccount)
        {
            bool statusOperation = Bank.OpenNewBankAccount(client, bankAccount);
            OpenCloseBankAccountEvent?.Invoke(this, client, bankAccount, statusOperation);
            return statusOperation;
        }
        public override bool MoneyTransfer<T, M>(Client sender, T senderAccount, Client recipient, M recipientAccount, double value)
        {
            bool statusOperation = Bank.MoneyTransfer<T, M>(sender, senderAccount, recipient, recipientAccount, value);
            MoneyTransferEvent?.Invoke(this, sender, senderAccount, recipient, recipientAccount, value, statusOperation);
            return statusOperation;
        }

        public override bool MoneyTransferCov(Client sender, BankAccount senderAccount, Client recipient, BankAccount recipientAccount, double value)
        {
            bool statusOperation = Bank.MoneyTransferCov(sender, senderAccount, recipient, recipientAccount, value);
            MoneyTransferEvent?.Invoke(this, sender, senderAccount, recipient, recipientAccount, value, statusOperation);
            return statusOperation;
        }



        public override bool ReplenishmentByTypeAccount(Client client, Type type, double value)
        {
            bool statusOperation = Bank.ReplenishmentByTypeAccount(client, type, value);
            ReplenishmentAccountEvent?.Invoke(this, client, type, value, statusOperation);
            return statusOperation;
        }
    }
}
