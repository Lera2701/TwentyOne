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
            Console.WriteLine("Enter your name: ");

            var user = new User($"{Console.ReadLine()}");
            var dealer = new User("Dealer");

            Console.WriteLine("");
            Console.WriteLine($"{dealer.Name} turn");

            Turn(dealer);

            Console.WriteLine("");
            Console.WriteLine($"Dealer: {dealer.Score}");
			Console.WriteLine("-------------");
            Console.WriteLine($"{user.Name} turn");

            Turn(user);

            Console.WriteLine("");

            Turn(user);

            Console.WriteLine("");
            Console.WriteLine($"You: {user.Score}");
			Console.WriteLine("-------------");

            if (Blackjack(user)) Console.WriteLine("Blackjack! You won");
            else
            {
                while (IsNextStepNeeded())
                {
                    Turn(user);

                    Console.WriteLine("");
                    Console.WriteLine($"You: {user.Score}");
                    Console.WriteLine("");

                    if (user.Score > 21)
                    {
                        Resume(user, dealer);
                        break;
                    }
                }

                if (user.Score < 22)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"{dealer.Name} turn");
                    while (dealer.Score < 17)
                    {
                        Turn(dealer);
                        Console.WriteLine("");
                    }

                    Console.WriteLine($"Dealer: {dealer.Score}");
                    Resume(user, dealer);
                }
            }
		}

		private void Turn(User user)
		{
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

        private bool Blackjack(User user)
        {
            if (user.Score == 21) return true;
            else return false;
        }

        private void Resume(User user, User dealer)
        {
            if (user.Score == dealer.Score) Console.WriteLine("-----Game ended in a drow-----");
            else if (user.Score > dealer.Score && user.Score < 22 || dealer.Score > 21) Console.WriteLine($"-----{user.Name} won-----");
            else Console.WriteLine($"-----{dealer.Name} won-----");
        }
	}
}
