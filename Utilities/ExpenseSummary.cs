using System.Globalization;

public class ExpenseSummary
{
    static int transactionCount = TransactionManager.GetTransactionCount();
    static int loops = 0;
    static int userDateChoice;

    public void Day()
    {
        HandleExpenseTransactionSummary(TransactionType.Day, 1, 31);
    }

    public void Week()
    {
        HandleExpenseTransactionSummary(TransactionType.Week, 1, 53);
    }

    public void Month()
    {
        HandleExpenseTransactionSummary(TransactionType.Month, 1, 12);
    }

    public void Year()
    {
        HandleExpenseTransactionSummary(TransactionType.Year, 1970, DateTime.Now.Year + 100);
    }

    public void HandleExpenseTransactionSummary(TransactionType transactionType, int minValue, int maxValue)
    {
        while (true)
        {
            Console.Clear();
            Console.Write($"Which {transactionType} do you wish to check? ");
            string userDateChoiceString = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(userDateChoiceString)) { return; }

            if (!int.TryParse(userDateChoiceString, out userDateChoice))
            {
                Console.Clear();
                Console.WriteLine("Invalid Input. Please type only numbers. [1-4]");
                PressKeyToContinue.Execute();
                continue;
            }

            Console.Clear();
            loops = 0;
            CultureInfo cultureInfo = CultureInfo.CurrentCulture;                      // Determines date format rules for user's region
            Calendar calendar = cultureInfo.Calendar;                                 // Retrieves calendar rules depending on user's region
            CalendarWeekRule weekRule = cultureInfo.DateTimeFormat.CalendarWeekRule; // Check which week is considered week 1 depending on user's region
            DayOfWeek firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek;   // Checks if week starts on Sunday or Monday depending on user's region

            if (userDateChoice < minValue || userDateChoice > maxValue)
            {
                Console.WriteLine($"{transactionType} has to be between ({minValue} - {maxValue})");
                PressKeyToContinue.Execute();
                continue;
            }

            foreach (Transaction transaction in TransactionManager.GetTransactions)
            {
                int transactionDatePart = 0;

                if (transactionType.Equals(TransactionType.Day) || transactionType.Equals(TransactionType.Month) || transactionType.Equals(TransactionType.Year))
                {
                    transactionDatePart = GetDateType.Execute(transaction, transactionType);
                }
                else
                {
                    transactionDatePart = calendar.GetWeekOfYear(transaction.Date, weekRule, firstDayOfWeek);
                }

                if (userDateChoice.Equals(transactionDatePart) && transaction.Amount < 0)
                {
                    Console.WriteLine(transaction.ToString());
                }
                else
                {
                    loops++;
                }

                if (!loops.Equals(transactionCount))
                {
                    continue;
                }

                if (transactionType.Equals(TransactionType.Day))
                {
                    string suffix = GetDaySuffix.Execute(userDateChoice);
                    Console.WriteLine($"There are no transactions on the {userDateChoice}{suffix}");
                }
                else if (transactionType.Equals(TransactionType.Week))
                {
                    Console.WriteLine($"There are no transactions in {TransactionType.Week} {userDateChoice}.");
                }
                else if (transactionType.Equals(TransactionType.Month))
                {
                    Months month = (Months)userDateChoice;
                    Console.WriteLine($"There are no transactions in {month}.");
                }
                else if (transactionType.Equals(TransactionType.Year))
                {
                    Console.WriteLine($"There are no transactions in the year {userDateChoice}.");
                }
            }
            PressKeyToContinue.Execute();
            return;
        }
    }
}
