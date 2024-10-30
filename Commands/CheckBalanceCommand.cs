class CheckBalanceCommand
{
    public static void Execute()
    {
        while (true)
        {
            Console.Clear();
            decimal totalBalance = TransactionManager.GetBalance();

            Console.WriteLine($"Your total balance is: {totalBalance}:-");

            Console.WriteLine("\nDo you wish to see a list of transactions?");
            Console.WriteLine("[1]Yes");
            Console.WriteLine("[2]No");

            Console.Write("\nEnter your choice: ");
            string userInput = Console.ReadLine()!;

            if (string.IsNullOrEmpty(userInput))
            {
                return;
            }

            if (userInput.Equals("2"))
            {
                return;
            }

            if (userInput.Equals("1"))
            {
                Console.Clear();
                Console.WriteLine($"Your total balance is: {totalBalance}:-");

                Console.WriteLine("\nList of your transactions:\n");
                TransactionManager.PrintTransactions();
                PressKeyToContinue.Execute();
                return;
            }

            Console.WriteLine("Invalid Input. Please type only numbers. [1-2]");
            PressKeyToContinue.Execute();
        }
    }
}
