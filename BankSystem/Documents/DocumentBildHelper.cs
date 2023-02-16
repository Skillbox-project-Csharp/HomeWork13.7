using HomeWork13._7.BankSystem.BankAccounts;
using HomeWork13._7.BankWorkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork13._7.BankSystem.Documents
{
    internal static class DocumentBildHelper
    {
        internal static string GetWorkerInfo(Worker worker)
        {
            StringBuilder workerInfoBild = new StringBuilder();
            workerInfoBild.Append(worker.GetType().Name);
            workerInfoBild.Append(":");
            workerInfoBild.AppendLine();
            workerInfoBild.Append("\t");
            workerInfoBild.AppendLine(worker.Name);
            workerInfoBild.Append("\t");
            workerInfoBild.AppendLine(worker.SurName);
            workerInfoBild.Append("\t");
            workerInfoBild.AppendLine(worker.Patronymic);
            return workerInfoBild.ToString();
        }
        internal static string GetAccountInfo(BankAccount bankAccount)
        {
            StringBuilder bankAccountInfoBild = new StringBuilder();
            bankAccountInfoBild.Append(bankAccount.GetType().Name);
            bankAccountInfoBild.AppendLine(":");
            bankAccountInfoBild.Append("\t");
            bankAccountInfoBild.Append(bankAccount.Id);
            bankAccountInfoBild.AppendLine();
            bankAccountInfoBild.Append("\t");
            bankAccountInfoBild.Append(bankAccount.Money);
            bankAccountInfoBild.AppendLine();
            return bankAccountInfoBild.ToString();
        }
        internal static string GetCientInfo(Client client)
        {
            StringBuilder clientInfoBild = new StringBuilder();
            clientInfoBild.AppendLine(client.Name);
            clientInfoBild.AppendLine(client.SurName);
            clientInfoBild.AppendLine(client.Patronymic);
            return clientInfoBild.ToString();
        }
    }
}
