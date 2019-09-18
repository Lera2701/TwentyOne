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
            Punt();
            Program.PlayerAccount -= punt;

            Console.WriteLine("");
            Console.WriteLine($"{dealer.Name} turn");

            Turn(dealer);

            Console.WriteLine("");
            Console.WriteLine($"{dealer.Name}: {dealer.Score}");

            if (dealer.Score == 11) 
                if (Insurance()) return;

            Console.WriteLine("-------------");
            Console.WriteLine($"{user.Name} turn");

            Turn(user);

            Console.WriteLine("");

            Turn(user);

            Console.WriteLine("");
            Console.WriteLine($"{user.Name}: {user.Score}");
			Console.WriteLine("-------------");

            if (Blackjack(user))
            {
                Console.WriteLine($"Blackjack! {user.Name} won");
                Program.PlayerAccount += punt * 2.5;
                return;
            }

            while (IsNextStepNeeded())
            {
                Turn(user);

                Console.WriteLine("");
                Console.WriteLine($"{user.Name}: {user.Score}");
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

                Console.WriteLine($"{dealer.Name}: {dealer.Score}");
                Resume(user, dealer);
            }
		}

        private bool Insurance()
        {
            Console.WriteLine("Insurance? [Y/n]");
            var x = Console.ReadLine();
            if (string.IsNullOrEmpty(x) || x == "y")
            {
                Console.WriteLine($"You're paying a half of your punt: {punt / 2}");
                Console.WriteLine($"{user.Name} account: {Program.PlayerAccount -= punt / 2}");
                Turn(dealer);
                if (dealer.Score == 21)
                {
                    Console.WriteLine($"Blackjack! {user.Name} insurance has played");
                    Console.WriteLine($"{user.Name}: {Program.PlayerAccount += punt}");
                    return true;
                }
                else return false;
            }

            if (x == "n")
            {
                Turn(dealer);
                if (dealer.Score == 21)
                {
                    Console.WriteLine($"Blackjack! {user.Name} lost");
                    Console.WriteLine($"{user.Name}: {Program.PlayerAccount -= punt / 2}");
                    return true;
                }
                else return false;
            }

            else return Insurance();
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
            {
                return false;
            }

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
                Program.PlayerAccount += punt;
                Console.WriteLine("-----PUSH-----");
            }
            else if (user.Score > dealer.Score && user.Score < 22 || dealer.Score > 21)
            {
                Console.WriteLine($"-----{user.Name} WON-----");
                Program.PlayerAccount += punt * 2;
            }
            else
            {
                Console.WriteLine($"-----{user.Name} LOST-----");
            }
        }

        private void Punt()
        {
            Console.WriteLine("Enter your punt divisible by 10 [def: 10]: ");
            string x = Console.ReadLine();
            
            try
            {
                var y = Convert.ToInt32(x);
                if (y % 10 != 0 || y == 0) Punt();
                else punt = y;
            }
            catch (FormatException)
            {
                if (string.IsNullOrEmpty(x))
                {
                    Console.WriteLine("Default punt: 10");
                    punt = 10;
                    return;
                }
                Punt();
            }
            
        }
	}
}
