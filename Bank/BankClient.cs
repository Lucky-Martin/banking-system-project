using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    internal class BankClient
    {
        private string name;
        private int balance;

        public string Name { get { return name; } }
        public int Balance { get { return balance; } }

        public BankClient(string name, int balance)
        {
            this.name = name;
            this.balance = balance;
        }

        public void Deposit(int amount)
        {
            balance += amount;
        }

        public bool Withdraw(int amout)
        {
            if (balance - amout >= 0)
            {
                balance -= amout;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
