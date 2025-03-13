using SimpleBankingSystem;

namespace Simple_Banking_System
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            BankingMethods bankingMethods = new BankingMethods();
            while (true)
            {
                Console.Clear();
                DisplayMenu();
                string choice = Menu();
                try
                {
                    switch (choice)
                    {
                        case "1":
                            bankingMethods.CreateAccount();
                            break;
                        case "2":
                            bankingMethods.DepositMoney();
                            break;
                        case "3":
                            bankingMethods.WithdrawMoney();
                            break;
                        case "4":
                            bankingMethods.AccountBalance();
                            break;
                        case "5":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Deposit Money");
            Console.WriteLine("3. Withdraw Money");
            Console.WriteLine("4. Account Balance");
            Console.WriteLine("5. Exit");
        }

        private static string Menu()
        {
            Console.Write("Enter your choice: ");
            return Console.ReadLine();
        }
    }
}
