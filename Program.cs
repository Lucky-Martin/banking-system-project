namespace BankingSystem
{
    internal class Program
    {
        static Bank bank;

        static void Main(string[] args)
        {
            string bankName = ChooseBankProvider();
            bank = new Bank(bankName);
            bank.AuthUser();
        }

        static string ChooseBankProvider()
        {
            Console.Clear();
            Console.WriteLine("Please enter your bank provider:");
            return Console.ReadLine();
        }
    }
}