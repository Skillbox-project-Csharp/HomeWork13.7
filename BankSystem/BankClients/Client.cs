using HomeWork13._7.BankSystem.BankAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork13._7.BankSystem
{
    internal abstract class Client
    {
        protected Guid _Id;
        protected List<BankAccount> _bankAccounts;
        protected string _name;
        protected string _surName;
        protected string _patronymic;
        abstract public Guid Id { get; }
        abstract public string Name { get; set;}
        abstract public string SurName { get; set; }
        abstract public string Patronymic { get; set; }
        abstract public List<BankAccount> BankAccounts { get;}
    }
}
