using System;
using System.Runtime.CompilerServices;

public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    string lastName;
    double balance;
    
    // constructors
    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }
    
    // getters
    public String getNum()
    {
        return cardNum;
    }
    
    public int getPin()
    {
        return pin;
    }
    
    public String getFirstName()
    {
        return firstName;
    }
    
    public String getLastName()
    {
        return lastName;
    }
    
    public double getBalance()
    {
        return balance;
    }
    // setters
    public void setCardNum(String newCardNum)
    {
        cardNum = newCardNum;
    }
    
    public void setPin(int newPin)
    {
        pin = newPin;
    }
    
    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }
    
    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }
    
    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("Enter amount to deposit");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Successfully deposited. Your new balance is: " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("Enter amount to withdraw: ");
            double withdrawal = Double.Parse(Console.ReadLine());
            // check if user has enough money
            if (currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient balance :(");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("Good to go! Thank you");
                
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine($"Current balance: {currentUser.getBalance()}");
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("4105401043810593", 1234, "John", "Doe", 15.31));
        cardHolders.Add(new cardHolder("4141844646328008", 4455, "Cliff", "Pri", 255.55));
        cardHolders.Add(new cardHolder("4485920836184247", 6633, "Jane", "Doe", 465.22));
        cardHolders.Add(new cardHolder("4024007133210244", 2112, "Mary", "Jane", 788.10));
        cardHolders.Add(new cardHolder("4716914238050396", 9977, "Tracy", "Lee", 101.98));
        
        // Prompt user
        Console.WriteLine("Welcome SimpleATM");
        Console.WriteLine("Please insert your debit card: ");
        String debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                // check against db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Card not recognized. Please try again");
                }
            }
            catch{Console.WriteLine("Card not recognized. Please try again");}
        }
        
        Console.WriteLine("Please enter your pin");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                // check against db
                if (currentUser.getPin() == userPin)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect pin. Please try again");
                }
            }
            catch{Console.WriteLine("Incorrect pin. Please try again");}
        }
        Console.WriteLine($"Welcome {currentUser.getFirstName()} :)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch
            {
                
            }
            if(option == 1){deposit(currentUser);}
            else if(option == 2){withdraw(currentUser);}
            else if(option == 3){balance(currentUser);}
            else if(option == 4){break;}
            else
            {
                option = 0;
            }

        } while (option != 4);
        Console.WriteLine("Thanyou! Have a nice one");
    }
}