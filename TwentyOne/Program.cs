using System;

namespace TwentyOne
{
	public class Program
	{
        public static double PlayerAccount { get; set; }
        public static string PlayerName { get; set; }
        public static void Main(string[] args)
		{
            PlayerAccount = 100;
            Greeting();
            Nickname();
            Round();
        }

        public static void Greeting()
        {
            Console.WriteLine("Hello");
            Console.WriteLine("-------------");
        }

        public static void Nickname()
        {
            Console.WriteLine("Enter your name: ");
            Program.PlayerName = Console.ReadLine();
            if (string.IsNullOrEmpty(Program.PlayerName)) Nickname();
            else Console.WriteLine($"Balance: {Program.PlayerName} - {PlayerAccount}");
        }

        public static void Round()
        {
            var game = new Game();
			game.Start();
            Console.WriteLine($"Currently account: {Program.PlayerName} - {PlayerAccount}");
            if (PlayerAccount < 10) Console.WriteLine("You can play on credit");
            Console.WriteLine("");
            Console.WriteLine("");
            Resume();
        }

        private static void Resume()
        {
            if (IsNextGameWanted())
            {
                Round();
            }
            else if (Program.PlayerAccount < 0) Console.WriteLine($"\r\n{Program.PlayerName}'s debt is {0 - Program.PlayerAccount}");
            else Console.WriteLine($"\r\n{Program.PlayerName}'s gain is {Program.PlayerAccount}");
        }

        private static bool IsNextGameWanted()
        {
            Console.WriteLine("One more game? [Y/n]");
            var x = Console.ReadLine();

            if (x == "n")
                return false;

            if (string.IsNullOrEmpty(x) || x == "y")
                return true;

            return IsNextGameWanted();
        }
	}
}
