public class HelpPageCommand
{
    public static void Execute()
    {
        Console.Clear();

        Console.WriteLine("Help Page:");
        Console.WriteLine("\n  [Add Transaction]: Record new transaction, enter date, name, and amount.\n  Positive is income, negative is expense.\n");
        Console.WriteLine("  [Delete Transaction]: Remove an existing transaction by entering its ID.\n");
        Console.WriteLine("  [Check Balance]: View your current balance, calculated from all saved transactions.\n");
        Console.WriteLine("  [Check Income Summary]: Get a summary of all your recorded income.\n");
        Console.WriteLine("  [Check Expense Summary]: Get a summary of all your recorded expenses.\n");
        Console.WriteLine("  [Save and Exit]: Save your data and close the app safely.");

        Console.WriteLine("\nNote: The app automatically loads all previously saved data. If you want to return to the\nmain menu at any time, just press Enter without typing anything.");

        PressKeyToContinue.Execute();
    }
}