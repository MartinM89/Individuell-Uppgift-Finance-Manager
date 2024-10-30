class CheckExpenseCommand
{
    private static ExpenseSummary expenseSummary = new ExpenseSummary();
    public static void Execute()
    {
        while (true)
        {
            Console.Clear();

            int transactionCount = TransactionManager.GetTransactionCount();

            if (transactionCount == 0)
            {
                Console.WriteLine("There are no saved transactions.");
                PressKeyToContinue.Execute();
                break;
            }

            Console.WriteLine("Do you wish to see:");
            Console.WriteLine("[1]Daily");
            Console.WriteLine("[2]Weekly");
            Console.WriteLine("[3]Monthly");
            Console.WriteLine("[4]Yearly");

            Console.Write("\nEnter your choice: ");
            string userChoiceString = Console.ReadLine()!;

            if (string.IsNullOrEmpty(userChoiceString)) { return; }

            if (byte.TryParse(userChoiceString, out byte userChoice))
            {
                Console.Clear();

                if (userChoice.Equals(1))
                {
                    expenseSummary.Day();
                }
                else if (userChoice.Equals(2))
                {
                    expenseSummary.Week();
                }
                else if (userChoice.Equals(3))
                {
                    expenseSummary.Month();
                }
                else if (userChoice.Equals(4))
                {
                    expenseSummary.Year();
                }
                else
                {
                    Console.WriteLine("\nInvalid Input. Please type only numbers. [1-4]");
                    PressKeyToContinue.Execute();
                }
            }
            else
            {
                Console.WriteLine("\nInvalid Input. Please type only numbers. [1-4]");
                PressKeyToContinue.Execute();
            }
            break;
        }
    }
}
