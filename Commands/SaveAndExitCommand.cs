using System.Text.Json;

public class SaveAndExitCommand
{
    public static void Execute()
    {
        Console.Clear();

        string directoryPath = "./saves";
        string filePath = "./saves/finance_save.json";

        List<Transaction> transactions = TransactionManager.GetTransactionList();

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
        string jsonSave = JsonSerializer.Serialize(transactions, options);

        File.WriteAllText(filePath, jsonSave);

        Program.run = false;

        Console.WriteLine("Thank you for using your Personal Finance Parter.");
        PressKeyToContinue.Execute();
    }
}
