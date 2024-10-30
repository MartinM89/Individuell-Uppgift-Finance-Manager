public class TransactionManager
{
    private static List<Transaction> transactions = new List<Transaction>();
    public static List<Transaction> GetTransactions { get { return transactions; } }

    public static void AddTransaction(Transaction transaction)
    {
        transactions.Add(transaction);
    }

    public static void DeleteTransaction(int id)
    {
        transactions.RemoveAt(id);
    }

    public static decimal GetBalance()
    {
        decimal totalBalance = 0;

        foreach (Transaction transaction in transactions)
        {
            totalBalance += transaction.Amount;
        }

        return totalBalance;
    }

    public static int GetTransactionCount()
    {
        int transactionCount = transactions.Count();

        return transactionCount;
    }

    public static List<Transaction> GetTransactionList()
    {
        return transactions;
    }

    public static void PrintTransactions()
    {
        foreach (Transaction transaction in transactions)
        {
            Console.WriteLine($"{transaction.ToString()}");
        }

        // transactions.ForEach(Console.WriteLine); // Works the same as above
    }

    public static void LoadTransactionList(List<Transaction> transactionLoad)
    {
        transactions.Clear();
        transactions.AddRange(transactionLoad);
    }

    public static int LongestNameLength()
    {
        int longestName = 0;

        foreach (Transaction transaction in transactions)
        {
            if (transaction.Name!.Length > longestName)
            {
                longestName = transaction.Name!.Length;
            }
        }

        return longestName;
    }

    public static int LongestAmountLength()
    {
        int longestAmount = 0;

        foreach (Transaction transaction in transactions)
        {
            if (transaction.Amount.ToString().Length > longestAmount)
            {
                longestAmount = transaction.Amount.ToString().Length;
            }
        }

        return longestAmount + 2; // Add 2 to account for the length of ':-'
    }
}
