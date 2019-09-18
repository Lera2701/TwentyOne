using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyOne
{
	public class User
	{
		public User(string name)
		{
			Name = name;
		}

		public string Name { get; set; }
		public int Score { get; set; }
	}
}
