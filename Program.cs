using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FractionMorning
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Fraction A = new Fraction(2, 3, 10);
				Console.WriteLine(A);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}
}
