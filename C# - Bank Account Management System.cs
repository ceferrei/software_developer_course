/*
The Bank Account Management System is a console-based application that allows users to create and manage bank accounts. 
Users can create new accounts by specifying the account number, the account holder's name, and an optional initial deposit. 
Once an account is created, users can perform transactions like depositing and withdrawing money from the account. 
The application also supports changing the account holder's name.using Banco;*/

using System.ComponentModel;
using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {
        Account acc = new Account();
        Console.Write("Enter account number: ");
        int accountNumber = int.Parse(Console.ReadLine());
        Console.Write("Enter account holder: ");
        string accountHolder = Console.ReadLine();
        Console.Write("Is there an initial deposit (y/n)? ");
        char response = char.Parse(Console.ReadLine());
        if (response == 'y' || response == 'Y')
        {
            Console.Write("Enter initial deposit value: ");
            double initialDeposit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            acc = new Account(accountNumber, accountHolder, initialDeposit);
        }
        else
        {
            acc = new Account(accountNumber, accountHolder); // assuming zero balance
        }

        Console.WriteLine("Account data:\n" + acc);

        Console.Write("Enter a deposit value: ");
        int depositValue = int.Parse(Console.ReadLine());
        acc.Deposit(depositValue);
        Console.WriteLine("Updated account data:\n" + acc);

        Console.Write("Enter a withdrawal value: ");
        depositValue = int.Parse(Console.ReadLine());
        acc.Withdraw(depositValue);
        Console.WriteLine("Updated account data:\n" + acc);

        acc.AccountHolder = "Maria";
        Console.WriteLine(acc); // changed account holder name to Maria
    }
}



namespace Banco
{
    internal class Account
    {
        // Properties
        public int AccountNumber { get; } // we don't use the set because it doesn't make sense to change the account number
        public string AccountHolder { get; set; } // can be changed, e.g. after marriage
        public double Balance { get; private set; } // public to get the value, but private to modify the balance
        public static double WithdrawalFee = 5;
        public double InitialDeposit;

        // Constructors - always public and use the name of the class
        public Account() { }

        // This constructor allows instantiating accounts with just the account number and account holder
        public Account(int accountNumber, string accountHolder)
        {
            AccountHolder = accountHolder;
            AccountNumber = accountNumber;
        }

        // This constructor allows instantiating accounts with the account number, account holder, and initial balance
        public Account(int accountNumber, string accountHolder, double balance) : this(accountNumber, accountHolder) // using "this" to reuse code from the other constructor
        {
            Balance = balance;
        }

        // Methods
        public void Withdraw(double withdrawal)
        {
            Balance -= withdrawal + WithdrawalFee;
        }
        public void Deposit(double deposit)
        {
            Balance += deposit;
        }

        public override string ToString()
        {
            return
                "Account: "
                + AccountNumber
                + ", Account Holder: "
                + AccountHolder
                + ", Balance: "
                + Balance.ToString("F2", CultureInfo.InvariantCulture)
                + "euros.";
        }
    }
}
