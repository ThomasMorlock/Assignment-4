using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clients
{
	public class CLient
	{
		// Private Fields.
		// private const double ACEPROMAZINEFORCAT = 0.002;
		// private const double ACEPROMAZINEFORDOG = 0.03;
		// private const double CARPROFENFORCAT = 0.25;
		// private const double CARPROFENFORDOG = 0.5;
		private string _firstName;
		private string _lastName;
		private int _weight;
		private double _height;

		// Non-Greedy Constructor.
		public Pet()
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

		public double Weight
		{
			get { return _weight; }
			set
			{
				if (value < 0.0)
					throw new ArgumentException("Weight must be a positive value (0 or greater)");
				_weight = value;
			}
		}

		public double Weight
		{
			get { return _weight; }
			set
			{
				if (value < 0.0)
					throw new ArgumentException("Weight must be a positive value (0 or greater)");
				_weight = value;
			}
		}
   
	 	// Read Only Fully Implemented Properties
		public double Acepromazine
		{
			get
			{
				double dosage = 0.0;
				if (Type.ToUpper().Equals("CAT"))
					dosage = Weight *(ACEPROMAZINEFORCAT / 10.0);
				else
					dosage = Weight *(ACEPROMAZINEFORDOG / 10.0);
				return dosage;
			}
		}

		public double Carprofen
		{
			get
			{
				double dosage = 0.0;
				if (Type.ToUpper().Equals("CAT"))
					dosage = Weight *(CARPROFENFORCAT / 12.0);
				else
					dosage = Weight *(CARPROFENFORDOG / 12.0);
				return dosage;
			}
		}

		// method
		public override string ToString()
		{
			return $"{Tag},{Name},{Age},{Weight},{Type}";
		}
	}
}
