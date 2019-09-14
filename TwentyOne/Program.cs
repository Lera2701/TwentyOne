using System;

namespace TwentyOne
{
	public class Program
	{
        public static double Player1 { get; set; }
        public static double Player2 { get; set; }
        public static string PlayerName { get; set; }
        public static void Main(string[] args)
		{
            Player1 = Player2 = 100;
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
            Console.WriteLine($"DEALER - {Player1}, {Program.PlayerName} - {Player2}");
        }

        public static void Round()
        {
            var game = new Game();
			game.Start();
            Console.WriteLine($"Currently accounts: DEALER - {Player1}, {Program.PlayerName} - {Player2}");
            Console.WriteLine("");
            Console.WriteLine("");
            if (IsNextGameWanted() && Player1 > 0)
            {
                Round();
            }
            else Console.WriteLine($"You won {Player2}");
        }

        private static bool IsNextGameWanted()
        {
            Console.WriteLine("One more game? [Y/n]");
            var response = Console.ReadLine();

            if (response == "n")
                return false;

            if (string.IsNullOrEmpty(response) || response == "y")
                return true;

            return IsNextGameWanted();
        }
	}
}
