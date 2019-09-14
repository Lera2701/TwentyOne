using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyOne
{
	class Game
	{
		private readonly Deck _deck;
        public User user = new User($"{Program.PlayerName}");
        public User dealer = new User("Dealer");
        public int punt;

        public Game()
		{
			_deck = new Deck();
		}
        public void Start()
		{
            user.Name = Program.PlayerName;

            Console.WriteLine("Enter your punt (divisible by 10): ");
            
            Punt(user);
            
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

            if (Blackjack(user))
            {
                Console.WriteLine("Blackjack! You won");
                user.Account += user.Account * 0.5;
                Console.WriteLine($"{user.Name}: {user.Account}");
                Console.WriteLine($"{dealer.Name}: {dealer.Account}");
            }
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
            Program.Player1 += dealer.Account - punt;
            Program.Player2 += user.Account - punt;
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
            if (user.Score == dealer.Score)
            {
                Console.WriteLine("-----PUSH-----");
                dealer.Account = user.Account;
                Console.WriteLine($"{user.Name}: {user.Account}");
                Console.WriteLine($"{dealer.Name}: {dealer.Account}");
            }
            else if (user.Score > dealer.Score && user.Score < 22 || dealer.Score > 21)
            {
                Console.WriteLine($"-----{user.Name} WON-----");
                user.Account += user.Account;
                Console.WriteLine($"{user.Name}: {user.Account}");
                Console.WriteLine($"{dealer.Name}: {dealer.Account}");
            }
            else
            {
                Console.WriteLine($"-----{dealer.Name} WON-----");
                dealer.Account += user.Account * 2;
                user.Account -= user.Account;
                Console.WriteLine($"{user.Name}: {user.Account}");
                Console.WriteLine($"{dealer.Name}: {dealer.Account}");
            }
        }

        private void Punt(User user)
        {
            int x;
            
            try
            {
                x = Convert.ToInt32(Console.ReadLine());
                if (x % 10 != 0 || x == 0)
                {
                    Console.WriteLine("Enter a correct number");
                    Punt(user);
                }
                else user.Account = punt = x;
            }
            catch (FormatException)
            {
                Console.WriteLine("Enter a correct number");
                Punt(user);
            }
            
        }
	}
}
