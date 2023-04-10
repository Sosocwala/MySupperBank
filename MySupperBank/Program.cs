namespace MySupperBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Sonwabile", 150000) ;
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance}.");

            account.MakeWithdrawal(15000, DateTime.Now, "Airbook");
            Console.WriteLine(account.Balance);

            account.MakeDiposit(-2000, DateTime.Now, "Not possible");
            Console.WriteLine(account.Balance);

            account.MakeDiposit(20000, DateTime.Now, "School fees");
            Console.WriteLine(account.Balance);

        }
    }
}