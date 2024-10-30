class MainMenu
{
    public static byte Execute()
    {
        Console.WriteLine("What do you wish to do?");
        Console.WriteLine("[1]Add Transaction");
        Console.WriteLine("[2]Delete Transaction");
        Console.WriteLine("[3]Check Balance");
        Console.WriteLine("[4]Check Income Summary");
        Console.WriteLine("[5]Check Expense Summary");
        Console.WriteLine("[6]Save and Exit");
        Console.WriteLine("[7]Help Page");

        Console.Write("\nEnter your choice: ");

        if (byte.TryParse(Console.ReadLine(), out byte userChoice))
        {
            return userChoice;
        }

        return 0;
    }
}
