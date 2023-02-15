using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork13._7.BankSystem.BankAccounts
{
    internal interface IReplenishment<out T> where T : BankAccount
    {

         T Replenishment(double value);
    }
}
