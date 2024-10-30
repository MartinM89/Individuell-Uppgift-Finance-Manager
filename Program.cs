class Program
{
    public static bool run = true;
    static void Main(string[] args)
    {
        LoadCommand.Execute();
        RunFirstTime.Execute();

        while (run)
        {
            Console.Clear();
            CommandCenter.Execute();
        }
    }
}
