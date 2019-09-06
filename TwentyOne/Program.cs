using System;

namespace TwentyOne
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var game = new Game();
			game.Start();
		}

		/*public static int score = 0;
		public static int dealerScore = 0;
		static Random x = new Random();

		static void Main(string[] args)
		{
			Console.WriteLine("Dealer turn.");
			Console.WriteLine("");
			Addition(dealerScore);
			Addition(dealerScore);
			Console.WriteLine($"Dealer: {dealerScore}");
			Console.WriteLine("-------------");

			Console.WriteLine("Your turn.");
			Console.WriteLine("");

			Addition(score);
			Console.WriteLine($"You: {score}");
			Console.WriteLine("-------------");
			Step();
			Console.ReadKey();
		}

		public static void Addition(User user)
		{
			int card = x.Next(2, 15);
			switch (card)
			{
				case 11:
					Console.WriteLine("Card: Ace");
					if (user.Score > 10) user.Score += 1;
					else user.Score += card;
					break;

				case 12:
					Console.WriteLine("Card: Jack");
					user.Score += 10;
					break;

				case 13:
					Console.WriteLine("Card: Queen");
					user.Score += 10;
					break;

				case 14:
					Console.WriteLine("Card: King");
					user.Score += 10;
					break;

				default:
					Console.WriteLine($"Card: {card}");
					user.Score += card;
					break;
			}
		}

		static void Step()
		{
			Console.WriteLine("Do you want another one? [Y/n]");
			var x = Console.ReadLine();
			if (x == "n")
			{
				Console.WriteLine($"You: {score}");
				Console.WriteLine("-------------");

				if (score >= 20 && dealerScore >= 20 && score == dealerScore) Resume();

				if (dealerScore < 20)
				{
					Console.WriteLine("Dealer turn.");
					Console.WriteLine("");
					DealerStep();
				}

				Resume();
			}
			else if (string.IsNullOrEmpty(x) || x == "y")
			{
				Addition(score);
				Console.WriteLine($"You: {score}");
				if (score < 22) Step();
				else Console.WriteLine("You lost!");
			}
			else
			{
				Step();
			}
		}

		static void DealerStep()
		{
			int card = x.Next(1, 4);

			for (int i = 0; i < card; i++)
			{
				// Turn
				if (dealerScore >= 21)
				{
					Console.WriteLine($"Dealer: {dealerScore}");
					break;
				}
			}

			Console.WriteLine($"Dealer: {dealerScore}");
		}

		static void Resume()
		{
			Console.WriteLine("-------------");
			if (dealerScore > 21 && score < 22 || dealerScore < 22 && score < 22 && score > dealerScore) Console.WriteLine("You won!");
			else if (score == dealerScore) Console.WriteLine("Ended in a drow!");
			else Console.WriteLine("You lost!");
		}
	}*/
	}
}
