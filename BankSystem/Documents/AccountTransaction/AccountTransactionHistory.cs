using HomeWork13._7.BankSystem.BankAccounts;
using HomeWork13._7.BankWorkers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork13._7.BankSystem.Documents.AccountTransaction
{
    internal class AccountTransactionHistory
    {
        public ObservableCollection<AccountTransaction> History;
        public event Action<AccountTransaction> TransactionCompleted;
        public AccountTransactionHistory()
        {
            History = new ObservableCollection<AccountTransaction>();
        }
        public AccountTransactionHistory(ObservableCollection<AccountTransaction> accountTransactions)
        {
            History = accountTransactions;
        }
        /// <summary>
        /// Сохранение отчета об операции "открытия\закрытии банковского акаунта клиента"
        /// </summary>
        /// <param name="worker"></param>
        /// <param name="isOpenClose"></param>
        /// <param name="client"></param>
        /// <param name="bankAccount"></param>
        /// <param name="statusOperation"></param>
        public void OpenCloseBankAccountTransactionDo(Worker worker, bool isOpenClose, object client, object bankAccount, bool statusOperation)
        {
            StringBuilder transactionInfoBild = new StringBuilder();
            transactionInfoBild.AppendLine(DateTime.Now.ToString());
            transactionInfoBild.AppendLine(DocumentBildHelper.GetWorkerInfo(worker));
            if (isOpenClose)
                transactionInfoBild.AppendLine("Открыте нового счета:");
            if (!isOpenClose)
                transactionInfoBild.AppendLine("Закрытие счета:");
            if (bankAccount is BankAccount account)
            {
                transactionInfoBild.AppendLine(DocumentBildHelper.GetAccountInfo(account));
            }
            if (client is Client bankClient)
            {
                transactionInfoBild.AppendLine("Клиент:");
                transactionInfoBild.AppendLine(DocumentBildHelper.GetCientInfo(bankClient));
            }

            AccountTransaction accountTransaction = new AccountTransaction
            {
                AccountTransactionInfo = transactionInfoBild.ToString(),
                IsCompleted = statusOperation
            };

            History.Add(accountTransaction);
            TransactionCompleted?.Invoke(accountTransaction);
        }
        /// <summary>
        /// Сохранение отчета об операции "перевод между счетами клиентов"
        /// </summary>
        /// <param name="worker"></param>
        /// <param name="sender"></param>
        /// <param name="senderAccount"></param>
        /// <param name="recipient"></param>
        /// <param name="recipientAccount"></param>
        /// <param name="value"></param>
        /// <param name="statusOperation"></param>
        public void MoneyTransferTransactionDo
            (
            Worker worker,
            object sender,
            object senderAccount,
            object recipient,
            object recipientAccount,
            object value,
            bool statusOperation
            )
        {
            StringBuilder transactionInfoBild = new StringBuilder();
            transactionInfoBild.AppendLine(DateTime.Now.ToString());
            transactionInfoBild.AppendLine(DocumentBildHelper.GetWorkerInfo(worker));
            transactionInfoBild.Append("Перевод мужду клиентами на сумму ");
            if (value is double moneyValue)
                transactionInfoBild.Append(moneyValue);
            transactionInfoBild.AppendLine();
            transactionInfoBild.AppendLine("Отправитель:");
            if (sender is Client bankClient1)
            {
                transactionInfoBild.AppendLine(DocumentBildHelper.GetCientInfo(bankClient1));
            }
            transactionInfoBild.AppendLine("Списать со счета:");
            if (senderAccount is BankAccount account1)
            {
                transactionInfoBild.AppendLine(DocumentBildHelper.GetAccountInfo(account1));
            }
            transactionInfoBild.AppendLine("Получатель:");
            if (recipient is Client bankClient2)
            {
                transactionInfoBild.AppendLine(DocumentBildHelper.GetCientInfo(bankClient2));
            }
            transactionInfoBild.AppendLine("Пополнить счет:");
            if (recipientAccount is BankAccount account2)
            {
                transactionInfoBild.AppendLine(DocumentBildHelper.GetAccountInfo(account2));
            }
            AccountTransaction accountTransaction = new AccountTransaction
            {
                AccountTransactionInfo = transactionInfoBild.ToString(),
                IsCompleted = statusOperation
            };

            History.Add(accountTransaction);
            TransactionCompleted?.Invoke(accountTransaction);
        }
        /// <summary>
        /// Сохранение отчета об операции "Пополнение банковского счета клиетна"
        /// </summary>
        /// <param name="worker"></param>
        /// <param name="client"></param>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <param name="statusOperation"></param>
        public void ReplenishmentAccountTransactionDo(Worker worker, object client, object type, object value, bool statusOperation)
        {
            StringBuilder transactionInfoBild = new StringBuilder();
            transactionInfoBild.AppendLine(DateTime.Now.ToString());
            transactionInfoBild.AppendLine(DocumentBildHelper.GetWorkerInfo(worker));
            transactionInfoBild.Append("Пополнение ");
            if (type is Type typeBankAccount)
                transactionInfoBild.Append(typeBankAccount);
            transactionInfoBild.Append("счета клиента на ");
            if (value is double moneyValue)
                transactionInfoBild.Append(moneyValue);
            transactionInfoBild.AppendLine();
            if (client is Client bankClient)
            {
                transactionInfoBild.AppendLine("Клиент:");
                transactionInfoBild.AppendLine(DocumentBildHelper.GetCientInfo(bankClient));
            }

            AccountTransaction accountTransaction = new AccountTransaction
            {
                AccountTransactionInfo = transactionInfoBild.ToString(),
                IsCompleted = statusOperation
            };

            History.Add(accountTransaction);
            TransactionCompleted?.Invoke(accountTransaction);
        }
    }
}
