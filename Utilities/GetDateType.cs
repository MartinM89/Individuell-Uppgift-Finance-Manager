public class GetDateType
{
    public static int Execute(Transaction transaction, TransactionType transactionType)
    {
        int date = transactionType switch
        {
            TransactionType.Day => transaction.Date.Day,
            TransactionType.Month => transaction.Date.Month,
            TransactionType.Year => transaction.Date.Year,
            _ => 0
        };

        return date;
    }
}