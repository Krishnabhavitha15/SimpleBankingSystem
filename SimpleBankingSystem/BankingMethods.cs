namespace SimpleBankingSystem
{
    internal class BankingMethods
    {

        static List<Account> accounts = new List<Account>();
        private static Account currentAccount;
        AccdbContext db = new AccdbContext();
        private object a;
        private object input;

        public void CreateAccount()
        {
            Console.WriteLine("Enter AccountNumber:");
            string accountnumber = Console.ReadLine();
            if(db.Accounts.Any(a => a.AccountNumber == accountnumber))
            {
                Console.WriteLine("Account already exists");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Enter HolderName:");
            string holdername = Console.ReadLine();
            Console.WriteLine("Balance:");
            decimal balance = Convert.ToDecimal(Console.ReadLine());
            db.Accounts.Add(new AccountEntity()
            {
                AccountNumber = accountnumber,
                HolderName = holdername,
                Balance = balance
            });
            db.SaveChanges();
            Console.WriteLine(AccountBalance);
        }
        public void DepositMoney()
        {
            Console.WriteLine("Enter AccountNumber:");
            string accountnumber = Console.ReadLine();
            decimal amount;
            while (true)
            {
                Console.WriteLine("Enter Money to Deposit:");
                //decimal amount = Convert.ToDecimal(Console.ReadLine());
                if (decimal.TryParse(Console.ReadLine(), out amount ))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid amount. Please enter a valid number.");
                }
            }
            var account = db.Accounts.FirstOrDefault(a => a.AccountNumber == accountnumber);
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be greater than zero");
                return;
            }

            account.Balance = account.Balance + amount;
            db.Accounts.Update(account);
            db.SaveChanges();
            if (account != null)
            {
                Console.WriteLine($"Account Balance for {account.HolderName} {account.AccountNumber} : {account.Balance}");
            }
            Console.WriteLine("Amount Deposited Successfully");
            Console.ReadLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();


        }

        private bool TryGetDepositAmount(object input, out decimal amount)
        {
            throw new NotImplementedException();
        }

        public void WithdrawMoney()
        {
            Console.WriteLine("Enter AccountNumber:");
            string accountnumber = Console.ReadLine();
            var account = db.Accounts.FirstOrDefault(a => a.AccountNumber == accountnumber);
            if (account != null)
            {
                Console.WriteLine("Enter the amount to withdraw:");
            }
            if (account == null )
            {
                Console.WriteLine("Account not found");
                Console.Read();
            }
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            account.Balance = account.Balance - amount;
            db.Accounts.Update(account);
            db.SaveChanges();
            if (account != null)
            {
                Console.WriteLine($"Account Balance for {account.HolderName} {account.AccountNumber} : {account.Balance}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();

        }
        public void AccountBalance()
        {
            using (var db = new AccdbContext())
            {
                Console.WriteLine("Enter Account Number:");
                string accountNumber = Console.ReadLine();

                var account = db.Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);

                if (account != null)
                {
                    Console.WriteLine($"Account Balance for {account.HolderName} {account.AccountNumber} : {account.Balance}");
                }
                else
                {
                    Console.WriteLine("Account not found.");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
            }
        }

       
    }
}

