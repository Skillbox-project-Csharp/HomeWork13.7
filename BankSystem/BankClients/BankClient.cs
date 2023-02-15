using HomeWork13._7.BankSystem.BankAccounts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork13._7.BankSystem.BankClients
{
    internal class BankClient : Client, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public override Guid Id => _Id;
        public override ObservableCollection<BankAccount> BankAccounts => _bankAccounts;
        public override string Name
        {
            get => _name;
            set
            {
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }
        public override string SurName
        {
            get => _surName;
            set
            {
                _surName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SurName)));
            }
        }
        public override string Patronymic
        {
            get => _patronymic;
            set { 
                _patronymic = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Patronymic)));
            }
        }


        public BankClient()
        {
            _Id = Guid.NewGuid();
            _bankAccounts = new ObservableCollection<BankAccount>();
            Name = string.Empty;
            SurName = string.Empty;
            Patronymic = string.Empty;
        }
        public BankClient(string name, string surName, string patronymic, Guid id, ObservableCollection<BankAccount> bankAccounts)
        {
            _Id = id;
            _bankAccounts = bankAccounts;
            Name = name;
            SurName = surName;
            Patronymic = patronymic;
        }

        public BankClient(string name, string surName, string patronymic)
            : this(name, surName, patronymic, Guid.NewGuid(), new ObservableCollection<BankAccount>()) { }

    }
}
