using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyOne
{
	public class Deck
	{
		private static readonly Random _random;

		static Deck()
		{
			_random = new Random();
		}

		public int GetCard()
		{
			return _random.Next(2, 15);
		}
	}
}
