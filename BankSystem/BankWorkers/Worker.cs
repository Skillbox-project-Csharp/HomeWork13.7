using HomeWork13._7.BankSystem;
using HomeWork13._7.BankSystem.BankAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork13._7.BankWorkers
{
    abstract class Worker
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Patronymic { get; set; }
        public abstract event Action<Worker, bool, object, object, bool> OpenCloseBankAccountEvent;
        public abstract event Action<Worker, object, object,object,object,object, bool> MoneyTransferEvent;
        public abstract event Action<Worker, object, object, object, bool> ReplenishmentAccountEvent;
        /// <summary>
        /// Открытие нового банковского счета для клиента
        /// </summary>
        /// <typeparam name="T">Тип банковского счета</typeparam>
        /// <param name="client">Клиент запросивший открытие</param>
        /// <param name="bankAccount">Новый банковский счет</param>
        /// <returns></returns>
        public abstract bool OpenNewBankAccount<T>(Client client, T bankAccount)
            where T : BankAccount;
        /// <summary>
        /// Закрытие счета клиента
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="client">Клиент запросивший закрытие</param>
        /// <param name="bankAccount">Акаунт</param>
        /// <returns></returns>
        public abstract bool CloseBankAccount<T>(Client client, T bankAccount)
            where T : BankAccount;
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
        public abstract bool MoneyTransfer<T, M>(Client sender, T senderAccount, Client recipient, M recipientAccount, double value)
            where T : BankAccount
            where M : BankAccount;
        
        /// <summary>
        /// Пополнение клиетского счета по типу 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public abstract bool ReplenishmentByTypeAccount(Client client, Type type, double value);
        /// <summary>
        /// Перевод средств между счетами клиентов ковариатный
        /// </summary>
        /// <param name="sender">Отправитель средств</param>
        /// <param name="senderAccount">Счет отправителя</param>
        /// <param name="recipient">Получатель</param>
        /// <param name="recipientAccount">Счет получателя</param>
        /// <param name="value">Сумма перевода</param>
        /// <returns></returns>
        public abstract bool MoneyTransferCov(Client sender, BankAccount senderAccount, Client recipient, BankAccount recipientAccount, double value);
       


    }
}
