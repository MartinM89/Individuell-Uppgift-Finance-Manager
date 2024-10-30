class AddTransactionCommand
{
    public static void Execute()
    {
        Console.Clear();

        DateTime transactionDate = DateTime.Now;

        #region USER_DATE_CHOICE
        while (true)
        {
            Console.Clear();

            Console.WriteLine("Do you wish to add transaction to:");
            Console.WriteLine("[1]Current Date");
            Console.WriteLine("[2]Custom Date");

            Console.Write("\nEnter your choice: ");
            string userChoiceString = Console.ReadLine()!;

            if (string.IsNullOrEmpty(userChoiceString)) { return; }

            if (!byte.TryParse(userChoiceString, out byte userChoice) || userChoice < 1 || userChoice > 2)
            {
                Console.Clear();
                Console.WriteLine("Invalid Input. Please type only numbers. [1-2]");
                PressKeyToContinue.Execute();
                continue;
            }

            if (userChoice.Equals(1))
            {
                Console.Clear();
                transactionDate = DateTime.Now;
                break;
            }
            else if (userChoice.Equals(2))
            {
                while (true)
                {
                    Console.Clear();
                    Console.Write("Enter date: ");
                    userChoiceString = Console.ReadLine()!;

                    if (string.IsNullOrEmpty(userChoiceString)) { return; }

                    if (!DateTime.TryParse(userChoiceString, out DateTime dateTime))
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid Input. Please enter a valid date using one of the following formats: (YYYY-MM-DD) | (DD-MM-YYYY) | (DD-MM)");
                        PressKeyToContinue.Execute();
                        continue;
                    }

                    if (!(dateTime.Year >= 1970 && dateTime.Year <= DateTime.Now.Year + 100))
                    {
                        Console.Clear();
                        Console.WriteLine($"Invalid Input. Please enter a valid date between 1970-{DateTime.Now.Year + 100}");
                        PressKeyToContinue.Execute();
                        continue;
                    }

                    transactionDate = dateTime;
                    break;
                }
                break;
            }
        }
        #endregion

        string capitalizedTransactionName;

        while (true)
        {
            bool onlyLettersOrWhiteSpace = true;

            Console.Clear();
            Console.Write("Enter name: ");
            string transactionName = Console.ReadLine()!.ToLower();

            if (string.IsNullOrEmpty(transactionName)) { return; }

            foreach (char c in transactionName)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                {
                    onlyLettersOrWhiteSpace = false;
                }
            }

            if (transactionName.Length !< 3 || transactionName.Length !> 20 || !onlyLettersOrWhiteSpace)
            {
                Console.Clear();
                Console.WriteLine("Invalid Input. Name must be at least 3 letters long, at most 20 letters long and not contain numbers or symbols.");
                PressKeyToContinue.Execute();
                continue;
            }

            capitalizedTransactionName = char.ToUpper(transactionName[0]) + transactionName.Substring(1);
            break;
        }

        decimal transactionValue;

        while (true)
        {
            Console.Clear();
            Console.Write("Enter amount: ");
            string transactionValueString = Console.ReadLine()!;

            if (string.IsNullOrEmpty(transactionValueString)) { return; }

            if (transactionValueString.Length > 10 || !decimal.TryParse(transactionValueString, out transactionValue))
            {
                Console.Clear();
                Console.WriteLine("Invalid Input. Amount must be only numbers and not exceed 10 numbers long.");
                PressKeyToContinue.Execute();
                continue;
            }

            if (transactionValue.Equals(0))
            {
                Console.Clear();
                Console.WriteLine("Invalid Input. Amount can't be 0.");
                PressKeyToContinue.Execute();
                continue;
            }

            break;
        }

        Transaction transaction = new Transaction(transactionDate, capitalizedTransactionName, transactionValue) { };

        TransactionManager.AddTransaction(transaction);
        TransactionManager.GetTransactions.Sort((a, b) => b.Date.CompareTo(a.Date));

        Console.Clear();
        Console.WriteLine($"The following transaction has been added:\n| {transaction.Date:yyyy MMM dd} | {transaction.Name} | {transaction.Amount:F2} |"); // ToString method name unnecessary, added for reference count.
        PressKeyToContinue.Execute();
    }
}
