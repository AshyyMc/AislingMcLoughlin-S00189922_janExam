using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace AislingMcLoughlin_S00189922
{
	public abstract class Account : IComparable
	{
		//Properties
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public string AccountType { get; set; }
		public int AccountNumber { get; set; }
		public int Balance { get; set; }
		public DateTime InterestDate { get; set; }

		

		//Abstract method - implemented in sub classes
		public abstract decimal CalculateInterest();

		//Method used to identify how this object will be sorted - in this case using Surname
		public int CompareTo(object obj)
		{
			Account that = obj as Account;
			return this.LastName.CompareTo(that.LastName);
		}

		//Override of ToString - used to display information in listbox
		public override string ToString()
		{
			return $"{AccountNumber}, {LastName.ToUpper()}, {FirstName}";
		}
	}//End of method

	public class Deposit : Account
	{
		public decimal deposit { get; set; }

		//Implementation of abstract method
		public override decimal CalculateInterest()
		{
			return deposit;

			//set DateTime
		}

		//Overide of ToString defined in abstract class
		public override string ToString()
		{
			return $"{base.ToString()} - deposit";
		}
	}//end

	public class Withdraw : Account
	{
		//Properties - this are additional to the base class properties
		public decimal withdraw { get; set; }

		//Implementation of abstract method
		public override decimal CalculateInterest()
		{
			
			return withdraw;

			//set DateTime
		}

		//Overide of ToString defined in abstract class
		public override string ToString()
		{
			return $"{base.ToString()} - withdraw";
		}
	}//end

	public class CurrentAccount : Account
	{
		//Properties
		public int Interest { get; set; }

		public override decimal CalculateInterest()
		{
			return Balance * (decimal)0.03;

			//setting DateTime
			InterestDate = DateTime.Today;
		}
	}//end

	public class SavingsAccount : Account
	{
		//Properties
		public int Interest { get; set; }

		public override decimal CalculateInterest()
		{
			return Balance * (decimal)0.06;

			//setting DateTime
			InterestDate = DateTime.Today;
		}

	}//end
}
