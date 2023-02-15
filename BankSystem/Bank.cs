using HomeWork13._7.BankSystem.BankAccounts;
using HomeWork13._7.BankSystem.BankAccounts.Interfaces;
using HomeWork13._7.BankSystem.BankClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork13._7.BankSystem
{
    internal class Bank
    {
        /// <summary>
        /// Открытие нового банковского счета для клиента
        /// </summary>
        /// <typeparam name="T">Тип банковского счета</typeparam>
        /// <param name="client">Клиент запросивший открытие</param>
        /// <param name="bankAccount">Новый банковский счет</param>
        /// <returns></returns>
        public static bool OpenNewBankAccount<T>(Client client, T bankAccount)
            where T : BankAccount
        {
            if (client == null || bankAccount == null)
                return false;
            if (client.BankAccounts.Count <= 2)
            {
                foreach (var account in client.BankAccounts)
                    if (account.GetType().Equals(bankAccount.GetType()))
                        return false;
                client.BankAccounts.Add(bankAccount);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Закрытие счета клиента
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="client">Клиент запросивший закрытие</param>
        /// <param name="bankAccount">Акаунт</param>
        /// <returns></returns>
        public static bool CloseBankAccount<T>(Client client, T bankAccount)
            where T : BankAccount
        {
            if (client == null || bankAccount == null)
                return false;
            int indexAccount = client.BankAccounts.IndexOf(bankAccount);
            if (indexAccount != -1)
            {
                if (client.BankAccounts[indexAccount].Money == 0)
                {
                    client.BankAccounts.RemoveAt(indexAccount);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Перевод средств между счетами клиентов
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="M"></typeparam>
        /// <param name="sender">Отправитель средств</param>
        /// <param name="senderAccount">Счет отправителя</param>
        /// <param name="recipient">Получатель</param>
        /// <param name="recipientAccount">Счет получателя</param>
        /// <param name="value">Сумма перевода</param>
        /// <returns></returns>
        public static bool MoneyTransfer<T, M>(Client sender, T senderAccount, Client recipient, M recipientAccount, double value)
            where T : BankAccount
            where M : BankAccount
        {
            if (sender == null || senderAccount == null || recipient == null || recipientAccount == null)
                return false;
            int indexSenderAccount = sender.BankAccounts.IndexOf(senderAccount);
            int indexRecipientAccount = recipient.BankAccounts.IndexOf(recipientAccount);
            if (indexSenderAccount == -1 || indexRecipientAccount == -1)
                return false;
            if (senderAccount.Equals(recipientAccount))
                return false;
            if (sender.BankAccounts[indexSenderAccount].SubMoney(value))
            {
                if (recipient.BankAccounts[indexRecipientAccount].AddMoney(value))
                {
                    return true;
                }
                else
                {
                    sender.BankAccounts[indexSenderAccount].AddMoney(value);
                    return false;
                }
            }
            else return false;
        }
        /// <summary>
        /// Пополнение клиетского счета по типу 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ReplenishmentByTypeAccount(Client client, Type type, double value)
        {
            if (client == null)
                return false;
            IReplenishment<BankAccount> account;
            foreach (var bankAccount in client.BankAccounts)
                if (bankAccount.GetType().Equals(type))
                {
                    account = bankAccount;
                    double money = bankAccount.Money;
                    account.Replenishment(value);

                    if (money != bankAccount.Money)
                        return true;
                    else return false;
                }
            return false;
        }
        /// <summary>
        /// Перевод средств между счетами клиентов ковариатный
        /// </summary>
        /// <param name="sender">Отправитель средств</param>
        /// <param name="senderAccount">Счет отправителя</param>
        /// <param name="recipient">Получатель</param>
        /// <param name="recipientAccount">Счет получателя</param>
        /// <param name="value">Сумма перевода</param>
        /// <returns></returns>
        public static bool MoneyTransferCov(Client sender, BankAccount senderAccount, Client recipient, BankAccount recipientAccount, double value)
        {
            if (sender == null || senderAccount == null || recipient == null || recipientAccount == null)
                return false;
            int indexSenderAccount = sender.BankAccounts.IndexOf(senderAccount);
            int indexRecipientAccount = recipient.BankAccounts.IndexOf(recipientAccount);
            if (indexSenderAccount == -1 || indexRecipientAccount == -1)
                return false;
            if (senderAccount.Equals(recipientAccount))
                return false;

            double beginMoney = senderAccount.Money;
            IMoneyTransfer<BankAccount> transfer = senderAccount;
            transfer.MoneyTransferCov(recipient, recipientAccount, value);

            if (beginMoney != senderAccount.Money)
                return true;
            else return false;
        }
    }

}

