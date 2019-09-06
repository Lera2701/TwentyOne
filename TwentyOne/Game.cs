using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyOne
{
	class Game
	{
		private readonly Deck _deck;

		public Game()
		{
			_deck = new Deck();
		}

		public void Start()
		{
			Console.WriteLine("Hello");
			Console.WriteLine("-------------");

			var user = new User("Lera");
			var dealer = new User("Dealer");

			Turn(dealer);
			Turn(dealer);

			Console.WriteLine($"Dealer: {dealer.Score}");
			Console.WriteLine("-------------");


			Console.WriteLine("Your turn.");
			Console.WriteLine("");

			Turn(user);

			Console.WriteLine($"You: {user.Score}");
			Console.WriteLine("-------------");

			while (IsNextStepNeeded())
				Turn(user);

			Console.WriteLine($"You: {user.Score}");

			var steps = new Random().Next(1, 4);

			for (int i = 0; i < steps && dealer.Score < 18; i++)
			{
				Turn(dealer);
			}

			Console.WriteLine($"Dealer: {dealer.Score}");
		}

		private void Turn(User user)
		{
			Console.WriteLine($"{user.Name} turn");

			var card = _deck.GetCard();
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

			if (user.Score > 21)
				Console.WriteLine($"{user.Name} lost");
		}

		private bool IsNextStepNeeded()
		{
			Console.WriteLine("Do you want another one? [Y/n]");
			var response = Console.ReadLine();

			if (response == "n")
				return false;

			if (string.IsNullOrEmpty(response) || response == "y")
				return true;

			return IsNextStepNeeded();
		}
	}
}
