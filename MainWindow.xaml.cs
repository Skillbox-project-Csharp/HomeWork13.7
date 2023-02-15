using HomeWork13._7.BankSystem;
using HomeWork13._7.BankSystem.BankAccounts;
using HomeWork13._7.BankSystem.BankAccounts.Interfaces;
using HomeWork13._7.BankSystem.BankClients;
using HomeWork13._7.BankWorkers;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;


namespace HomeWork13._7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal Worker Employee;
        internal ObservableCollection<Client> BankClients { get; set; }
        internal Client SelectedBankClient1 { get; set; }
        internal Client SelectedBankClient2 { get; set; }
        internal BankAccount SelectedBankAccount1 { get; set; }
        internal BankAccount SelectedBankAccount2 { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            EmployeeSelectionWindow openAccountWindow = new EmployeeSelectionWindow();
            if (openAccountWindow.ShowDialog() == true)
            {
                Employee = openAccountWindow.GetWorker;
            }
            BankClients = new ObservableCollection<Client>
            {
                new BankClient{Name ="Анна", SurName="Петровна", Patronymic="Игоревна"},
                new BankClient{Name ="Павел", SurName="Вересов", Patronymic="Александрович"},
                new BankClient{Name ="Андрей", SurName="Краснов", Patronymic=""}
            };
            GeneratingAccounts(BankClients);

            ListBoxDataClients1.ItemsSource = BankClients;
            ListBoxDataClients2.ItemsSource = BankClients;
        }
        private void GeneratingAccounts(ObservableCollection<Client> clients)
        {
            for (int i = 0; i < clients.Count; i++)
            {
                BankAccount bankAccount = new BankAccount();
                DepositAccount depositAccount = new DepositAccount();
                NoDepositAccount noDepositAccount = new NoDepositAccount();
                bankAccount.AddMoney(i);
                depositAccount.AddMoney(i);
                noDepositAccount.AddMoney(i);
                Employee?.OpenNewBankAccount(clients[i], bankAccount);
                Employee?.OpenNewBankAccount(clients[i], depositAccount);
                Employee?.OpenNewBankAccount(clients[i], noDepositAccount);
            }
        }
        private void ListBoxDataClients1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (ListBoxDataClients1.SelectedItem is BankClient client)
            {
                SelectedBankClient1 = client;
                ListBoxClientBankAccounts1.ItemsSource = client.BankAccounts;
            }

        }

        private void ListBoxDataClients2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxDataClients2.SelectedItem is BankClient client)
            {
                SelectedBankClient2 = client;
                ListBoxClientBankAccounts2.ItemsSource = client.BankAccounts;
            }
        }

        private void ListBoxClientBankAccounts1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxClientBankAccounts1.SelectedItem is BankAccount bankAccount)
                SelectedBankAccount1 = bankAccount;
        }

        private void ListBoxClientBankAccounts2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxClientBankAccounts2.SelectedItem is BankAccount bankAccount)
                SelectedBankAccount2 = bankAccount;
        }

        private void ButtonCloseAccount_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedBankClient1 != null && SelectedBankAccount1 != null)
            {
                Employee?.CloseBankAccount(SelectedBankClient1, SelectedBankAccount1);
            }
        }

        private void ButtonOpenAccount_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedBankClient1 != null)
            {
                OpenAccountWindow openAccountWindow = new OpenAccountWindow();
                if (openAccountWindow.ShowDialog() == true)
                {
                    Employee?.OpenNewBankAccount(SelectedBankClient1, openAccountWindow.GetBankAccount);
                }
            }
        }

        private void ButtonReplenishmentAccount_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedBankClient1 != null && SelectedBankAccount1 != null)
            {
                ReplenishmentAccount replenishmentWindow = new ReplenishmentAccount("Пополнить счет на");
                if (replenishmentWindow.ShowDialog() == true)
                {
                    Employee?.ReplenishmentByTypeAccount(SelectedBankClient1, SelectedBankAccount1.TypeAccount, replenishmentWindow.AmountAddMoney);
                }
            }
        }

        private void ButtonMoneyTransfer_Click(object sender, RoutedEventArgs e)
        {
            ReplenishmentAccount replenishmentWindow = new ReplenishmentAccount("Сумма перевода");
            if (replenishmentWindow.ShowDialog() == true)
            {
                Employee?.MoneyTransfer
                    (
                    SelectedBankClient1,
                    SelectedBankAccount1,
                    SelectedBankClient2,
                    SelectedBankAccount2,
                    replenishmentWindow.AmountAddMoney
                    );
            }
        }

        private void ButtonMoneyTransferCov_Click(object sender, RoutedEventArgs e)
        {
            ReplenishmentAccount replenishmentWindow = new ReplenishmentAccount("Сумма перевода");
            if (replenishmentWindow.ShowDialog() == true)
            {
                Employee?.MoneyTransferCov
                    (
                    SelectedBankClient1,
                    SelectedBankAccount1,
                    SelectedBankClient2,
                    SelectedBankAccount2,
                    replenishmentWindow.AmountAddMoney
                    );
            }
        }
    }
}
