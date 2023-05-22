namespace BankingSystem
{
    internal class Bank
    {
        private string name;
        private List<BankClient> clients = new List<BankClient>();
        private BankClient loggedUserClient;

        public string Name { get { return name; } }

        public Bank(string name)
        {
            this.name = name;
        }

        public BankClient CreateClient(string name, int initialBalance)
        {
            BankClient client = new BankClient(name, initialBalance);
            clients.Add(client);
            return client;
        }

        public BankClient FetchClient(string name)
        {
            return clients.Find(client => client.Name == name);
        }

        public void AuthUser()
        {
            Console.Clear();
            Console.WriteLine("Please select an option:");
            Console.WriteLine("[1] Register a bank account");
            Console.WriteLine("[2] Login to an existing account");
            try
            {
                int input = int.Parse(Console.ReadLine());
                if (input == 1)
                {
                    string username = GetUsername();
                    loggedUserClient = CreateClient(username, 0);
                    DisplayBankMenu();
                }
                else if (input == 2)
                {
                    string username = GetUsername();
                    BankClient client = FetchClient(username);
                    loggedUserClient = client;
                    DisplayBankMenu();
                }
            }
            catch (Exception e)
            {
                AuthUser();
            }
        }

        public void DisplayBankMenu()
        {
            if (loggedUserClient is null)
            {
                AuthUser();
                return;
            }

            Console.Clear();
            Console.WriteLine("Account {0} balance: BGN {1}", loggedUserClient.Name, loggedUserClient.Balance);
            Console.WriteLine("[1] Deposit money");
            Console.WriteLine("[2] Withdraw money");
            Console.WriteLine("[3] Logout");

            try
            {
                int input = int.Parse(Console.ReadLine());
                if (input == 1)
                {
                    int amount = GetAmount("deposit");
                    loggedUserClient.Deposit(amount);
                    DisplayBankMenu();
                }
                else if (input == 2)
                {
                    int amount = GetAmount("withdraw");
                    loggedUserClient.Withdraw(amount);
                    DisplayBankMenu();
                }
                else if (input == 3)
                {
                    loggedUserClient = null;
                    AuthUser();
                }
            }
            catch (Exception e)
            {
                DisplayBankMenu();
            }
        }

        public static string GetUsername()
        {
            Console.Clear();
            Console.WriteLine("Please enter your username: ");
            return Console.ReadLine();
        }

        public static int GetAmount(string reason)
        {
            Console.Clear();
            Console.WriteLine("Please enter amount to {0}:", reason);
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                return GetAmount(reason);
            }
        }
    }
}
