using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clients
{
	public class Client
	{
		// Private Fields.
		// private const double ACEPROMAZINEFORCAT = 0.002;
		// private const double ACEPROMAZINEFORDOG = 0.03;
		// private const double CARPROFENFORCAT = 0.25;
		// private const double CARPROFENFORDOG = 0.5;
		private string _firstName;
		private string _lastName;
		private int _weight;
		private int _height;

		// Non-Greedy Constructor.
		public Client()
		{
			FirstName="XXXX";
			LastName="YYYY";
			Weight = 0;
			Height = 0;
		}

		// Greedy Constructor.
		public Client(string firstName, string lastName, int weight, int height)
		{
			FirstName = firstName;
			LastName = lastName;
			Weight = weight;
			Height = height;
		}

		// Fully Implemented Properties
		public string FirstName
		{
			get { return _firstName; }
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("First name is required. Must not be empty or blank.");
				_firstName = value;
			}
		}

		public string LastName
		{
			get { return _lastName; }
			set
			{
				if (string.IsNullOrWhiteSpace(value))
					throw new ArgumentNullException("Last name is required. Must not be empty or blank.");
				_lastName = value;
			}
		}

		public int Weight
		{
			get { return _weight; }
			set
			{
				if (value < 0.0)
					throw new ArgumentException("Weight must be a positive value (0 or greater)");
				_weight = value;
			}
		}

		public int Height
		{
			get { return _height; }
			set
			{
				if (value < 0.0)
					throw new ArgumentException("Height must be a positive value (0 or greater)");
				_height = value;
			}
		}
   
	 	// Read Only Fully Implemented Properties
		public double BmiScore
		{
			get
			{
				double bmiScore = 0.0;
				bmiScore = Weight / Math.Pow(Height, 2) * 703;
				return bmiScore;
			}
		}

		public string BmiStatus
		{
			get
			{
				double bmiScore = BmiScore;
				string bmiStatus = "BBBB";
				if (bmiScore <= 18.4)
				{
					bmiStatus = "Underweight";
				}
				else if (bmiScore > 18.4 && bmiScore <= 24.9)
				{
					bmiStatus = "Normal";
				}
				else if (bmiScore > 24.9 && bmiScore <= 39.9)
				{
					bmiStatus = "Overweight";
				}
				else if (bmiScore >= 40)
				{
					bmiStatus = "Obese";
				}
				else 
				{
					bmiStatus = "Invalid value. BmiStatus cannot be less than zero.";
				}
				return bmiStatus;
			}
		}

		// method
		public override string ToString()
		{
			return $"{FirstName}, {LastName}";
		}
	}
}
