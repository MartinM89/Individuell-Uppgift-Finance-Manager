class DeleteTransactionCommand
{
    public static void Execute()
    {
        int transactionCount = TransactionManager.GetTransactionCount();

        if (transactionCount.Equals(0))
        {
            Console.Clear();
            Console.WriteLine("There are no saved transactions.");
            PressKeyToContinue.Execute();
            return;
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine("List of transactions:");
            Console.WriteLine("  | ID | Date        | Name                 | Amount     |");

            for (int i = 0; i < TransactionManager.GetTransactions.Count; i++)
            {
                Console.WriteLine(
                    $"  | {i + 1} {TransactionManager.GetTransactions[i].ToString()}"
                );
            }

            Console.WriteLine("\nEnter the ID of a transaction you want to delete.");
            Console.Write("\nEnter ID: ");
            string transactionIndex = Console.ReadLine()!;

            if (transactionIndex.Length.Equals(0))
            {
                break;
            }

            if (!int.TryParse(transactionIndex, out int transactionIndexInt))
            {
                Console.Clear();
                Console.WriteLine("Invalid Input. Enter only numbers for ID.");
                PressKeyToContinue.Execute();
                continue;
            }

            if (transactionIndexInt < 1 || transactionIndexInt > transactionCount)
            {
                Console.Clear();
                Console.WriteLine("Invalid Input. ID does not exist.");
                PressKeyToContinue.Execute();
                continue;
            }

            int indexToDelete = transactionIndexInt - 1;

            Console.Clear();
            TransactionManager.DeleteTransaction(indexToDelete);
            Console.WriteLine("Transaction removed.");
            PressKeyToContinue.Execute();
            break;
        }
    }
}
