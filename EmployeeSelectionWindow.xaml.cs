using HomeWork13._7.BankWorkers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HomeWork13._7
{
    /// <summary>
    /// Логика взаимодействия для EmployeeSelectionWindow.xaml
    /// </summary>
    public partial class EmployeeSelectionWindow : Window
    {
        internal Worker GetWorker
        {
            get
            {
                switch (TypesBankAccounts.SelectedIndex)
                {
                    case 0: return new Manager(InputName.Text, InputSurName.Text, InputPatronymic.Text);
                    case 1: return new Consultant(InputName.Text, InputSurName.Text, InputPatronymic.Text);
                    default: return null;
                }

            }
        }
        public EmployeeSelectionWindow()
        {
            InitializeComponent();
        }
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
