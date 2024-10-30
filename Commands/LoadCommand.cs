using System.Text.Json;

public class LoadCommand
{
    public static void Execute()
    {
        Console.Clear();

        if (!File.Exists("./saves/firstRun.pfp"))
        {
            return;
        }

        int loops = 0;
        string dotdotdot = "...";

        while (loops < 3)
        {
            Console.Clear();

            Console.Write("Attempting to load transactions");

            foreach (char c in dotdotdot)
            {
                Console.Write(c);

                Thread.Sleep(300);
            }

            loops++;
        }

        string filePath = "./saves/finance_save.json";

        if (!File.Exists(filePath))
        {
            Console.Clear();
            Console.WriteLine("You have no transactions to load.");
            PressKeyToContinue.Execute();
            return;
        }

        if (new FileInfo(filePath).Length.Equals(0))
        {
            Console.Clear();
            Console.WriteLine("Load unsuccessful.");
            PressKeyToContinue.Execute();
            return;
        }

        string jsonSave = File.ReadAllText(filePath);

        List<Transaction> transactions = JsonSerializer.Deserialize<List<Transaction>>(jsonSave)!;

        if (transactions != null)
        {
            TransactionManager.LoadTransactionList(transactions);
            Console.Clear();
            Console.WriteLine("Load successful.");
        }

        PressKeyToContinue.Execute();
    }
}
