class CommandCenter
{
    public static void Execute()
    {
        byte userChoice = MainMenu.Execute();

        if (userChoice.Equals(1))
        {
            AddTransactionCommand.Execute();
        }
        else if (userChoice.Equals(2))
        {
            DeleteTransactionCommand.Execute();
        }
        else if (userChoice.Equals(3))
        {
            CheckBalanceCommand.Execute();
        }
        else if (userChoice.Equals(4))
        {
            CheckIncomeCommand.Execute();
        }
        else if (userChoice.Equals(5))
        {
            CheckExpenseCommand.Execute();
        }
        else if (userChoice.Equals(6))
        {
            SaveAndExitCommand.Execute();
        }
        else if (userChoice.Equals(7))
        {
            HelpPageCommand.Execute();
        }
        else
        {
            Console.WriteLine("\nInvalid Input. Please type only numbers. [1-7]");
            PressKeyToContinue.Execute();
        }
    }
}
