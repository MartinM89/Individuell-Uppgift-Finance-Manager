public class RunFirstTime
{
    public static void Execute()
    {
        Console.Clear();

        if (!Directory.Exists("./saves"))
        {
            Directory.CreateDirectory("./saves");
        }

        if (!File.Exists("./saves/firstRun.pfp"))
        {
            Console.Clear();

            string welcomeMessage = "Welcome to your Personal Finance Partner!\n";

            foreach (char c in welcomeMessage)
            {
                Console.Write(c);
                Thread.Sleep(100);
            }

            PressKeyToContinue.Execute();

            HelpPageCommand.Execute();

            Console.Clear();
            Console.WriteLine("At anytime if you wish to see the help page again press '7' in the main menu.");

            PressKeyToContinue.Execute();

            File.Create("./saves/firstRun.pfp").Dispose();
        }
    }
}
