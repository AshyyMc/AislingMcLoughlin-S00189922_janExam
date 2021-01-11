using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Console;

/*	Author: Aisling Mc Loughlin - S00189922
	Date: 11/09/2021
	Purpose: Create an application interface .*/

namespace AislingMcLoughlin_S00189922
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		int amount = 0;
		public List<Account> Accounts;  //collection to contain all accounts
		public List<Account> FilteredAccounts;  //collection to contain all accounts
		//	public List<Account> currentAccounts; //collection to contain all current accounts
		//	public List<Account> savingsAccounts; //collection to contain all savings accounts
		public MainWindow()
		{
			InitializeComponent();
		}

		//This method is run when the window is loaded - linked to XAML (Window Loaded)
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			//Initialise the collections
			Accounts = new List<Account>();
			FilteredAccounts = new List<Account>();
			//savingsAccounts = SavingsAccount;

			//Create some current accounts and saving accounts
			SavingsAccount sa1 = new SavingsAccount() { AccountNumber = 50000, LastName = "Smith",  FirstName = "John"};
			SavingsAccount sa2 = new SavingsAccount() { AccountNumber = 10000, LastName = "Note", FirstName = "Robert" };
			CurrentAccount ca2 = new CurrentAccount() { AccountNumber = 1000, LastName = "Prop", FirstName = "Joe" };
			CurrentAccount ca1 = new CurrentAccount() { AccountNumber = 11000, LastName = "Natli", FirstName = "Rogan" };

			//Add all accounts to main collection of accounts
			Accounts.Add(sa1);
			Accounts.Add(sa2);
			Accounts.Add(ca2);
			Accounts.Add(ca1);

			UpdateListbox(Accounts);// Call method to sort list and update display

			//Set initial values on checkboxes
			checkboxCurrentAccounts.IsChecked = true;
			checkboxSavingsAccounts.IsChecked = true;
		}//End of Main Method

		


		//Used to filter by savings account and current account
		private void checkboxCurrentAccounts_Click(object sender, RoutedEventArgs e)
		{
			//setup
			//string account;
			//FilteredAccounts.Clear();
			//listboxAccount.ItemsSource = null;

			//all Accounts
			if ((checkboxCurrentAccounts.IsChecked == true) && (checkboxSavingsAccounts.IsChecked == true))
				UpdateListBox(Accounts);

			//no accounts
			else if ((checkboxCurrentAccounts.IsChecked == false) && (checkboxSavingsAccounts.IsChecked == false))
				listboxAccount.ItemsSource = null;

			//Current Accounts
			else if ((checkboxCurrentAccounts.IsChecked == true) && (checkboxSavingsAccounts.IsChecked == false))
			{
				FilteredAccounts.Clear();

				foreach (Account Account in Accounts)
				{
					if (Account is CurrentAccount)
						FilteredAccounts.Add(Account);
				}

				UpdateListBox(FilteredAccounts);
			}

			//Savings Accounts
			else if ((checkboxCurrentAccounts.IsChecked == false) && (checkboxSavingsAccounts.IsChecked == true))
			{
				FilteredAccounts.Clear();

				foreach (Account Account in Accounts)
				{
					if (Account is SavingsAccount)
						FilteredAccounts.Add(Account);
				}

				UpdateListBox(FilteredAccounts);
			}
		}

		//Used to filter by savings account and current account
		private void checkboxSavingsAccounts_Click(object sender, RoutedEventArgs e)
		{
			//setup
			//string account;
			//FilteredAccounts.Clear();
			//listboxAccount.ItemsSource = null;

			//all Accounts
			if ((checkboxCurrentAccounts.IsChecked == true) && (checkboxSavingsAccounts.IsChecked == true))
				UpdateListBox(Accounts);

			//no accounts
			else if ((checkboxCurrentAccounts.IsChecked == false) && (checkboxSavingsAccounts.IsChecked == false))
				listboxAccount.ItemsSource = null;

			//Current Accounts
			else if ((checkboxCurrentAccounts.IsChecked == true) && (checkboxSavingsAccounts.IsChecked == false))
			{
				FilteredAccounts.Clear();

				foreach (Account Account in Accounts)
				{
					if (Account is CurrentAccount)
						FilteredAccounts.Add(Account);
				}

				UpdateListBox(FilteredAccounts);
			}

			//Savings Accounts
			else if ((checkboxCurrentAccounts.IsChecked == false) && (checkboxSavingsAccounts.IsChecked == true))
			{
				FilteredAccounts.Clear();

				foreach (Account Account in Accounts)
				{
					if (Account is SavingsAccount)
						FilteredAccounts.Add(Account);
				}

				UpdateListBox(FilteredAccounts);
			}
		}

		private void listboxAccount_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			//check what has been selected
			Account selectedAccount = listboxAccount.SelectedItem as Account;

			//ensure it is not null
			if (selectedAccount != null)
			{
				//take action - update the display
				textblockFirstName = selectedAccount.FirstName;
				TextblockLastName = selectedAccount.LastName;
				textblockBalance = selectedAccount.Balance;
				textblockAccountType = selectedAccount.AccountType;
			}

		}

		private void buttonDeposit_Click(object sender, RoutedEventArgs e)
		{
			

			if (amount <= 0)
				return;
			this.Balance += amount;
			return;
		}

		private void labelWithdraw_Click(object sender, RoutedEventArgs e)
		{
			if (amount <= 0 || this.Balance - amount < 0)
				return

		this.Balance -= amount;
			return ;
		}

		private void labelInterest2_Click(object sender, RoutedEventArgs e)
		{
			// Interest is calculated by multiplying the account balance by the
			//rate.

		
			amount = Interest * Balance;
			
		}


		private void UpdateListbox(List<Account> accounts)
		{
			throw new NotImplementedException();
		}


		//private void TextblockLastName_GotFocus(object sender, RoutedEventArgs e)
		//{
		//	TextblockLastName.Clear();
		//}
	}
}
