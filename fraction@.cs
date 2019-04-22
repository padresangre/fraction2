using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FractionMorning
{
	class Fraction
	{
		int integer;
		int numerator;
		int denominator;
		public int Integer
		{
			get
			{
				return this.integer;
			}
			set
			{
				this.integer = value;
			}
		}
		public int Numerator
		{
			get
			{
				return this.numerator;
			}
			set
			{
				this.numerator = value;
			}
		}
		public int Denominator
		{
			get
			{
				return this.denominator;
			}
			set
			{
				if (value == 0) throw new Exception("На 0 делить нельзя");
				this.denominator = value;
			}
		}
		public Fraction(int Integer = 0, int Numerator = 0, int Denominator = 1)
		{
			this.Integer = Integer;
			this.Numerator = Numerator;
			this.Denominator = Denominator;
		}
		public Fraction(Fraction other)
		{
			this.Integer = other.Integer;
			this.Numerator = other.Numerator;
			this.Denominator = other.Denominator;
			Console.WriteLine("FractionCopyConstructor");
		}
		public static Fraction operator +(Fraction left, Fraction right)
		{
			Fraction temp = new Fraction();
			left.ToImproper();
			right.ToImproper();

			temp.Numerator = left.Numerator * right.Denominator + right.Numerator * left.Denominator;
			temp.Denominator = left.Denominator * right.Denominator;
			return temp;
		}
		public static Fraction operator *(Fraction left, Fraction right)
		{
			Fraction Temp = new Fraction();
			left.ToImproper();
			right.ToImproper();
			Temp.Numerator = left.Numerator * right.Numerator;
			Temp.Denominator = left.Denominator * right.Denominator;
			Temp.ToProper();
			return Temp;
		}
		public static Fraction operator /(Fraction left, Fraction right)
		{
			Fraction Temp = new Fraction();
			left.ToImproper();
			right.ToImproper();
			Temp.Numerator = left.Numerator * right.Denominator;
			Temp.Denominator = left.Denominator * right.Numerator;
			Temp.ToProper();
			return Temp;
		}
		void Reduce()
		{
			int More, Less, Rest;
			if (this.Numerator > this.Denominator)
			{
				More = Numerator;
				Less = Denominator;
			}
			else
			{
				More = Denominator;
				Less = Numerator;
			}
			do
			{
				Rest = More % Less;
				More = Less;
				Less = Rest;
			} while (Rest !=0);
			int GCD = More;
			Numerator /= GCD;
			Denominator /= GCD;
		}
		void ToProper()
		{
			Integer += Numerator / Denominator;
			Numerator = Numerator % Denominator;
		}
		void ToImproper()
		{
			Numerator += Integer * Denominator;
			Integer = 0;
		}
		public override string ToString()
		{
			return (this.integer != 0 ? this.Integer.ToString() : "") + "(" + Numerator + "/" + Denominator + ")";
		}
		

	}
}
