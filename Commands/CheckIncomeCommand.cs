class CheckIncomeCommand
{
    private static IncomeSummary incomeSummary = new IncomeSummary();
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
                    incomeSummary.Day();
                }
                else if (userChoice.Equals(2))
                {
                    incomeSummary.Week();
                }
                else if (userChoice.Equals(3))
                {
                    incomeSummary.Month();
                }
                else if (userChoice.Equals(4))
                {
                    incomeSummary.Year();
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
