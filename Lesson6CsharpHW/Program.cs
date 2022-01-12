using System;
using System.Threading;
using Lesson6CsharpHW;

void clear() { Console.Clear(); }

User[] Clients = new User[5] 
{
    new User("Murad", "Musali", new BankCard("06/24", 100_000)),
    new User("Ramazan", "Mustafazade", new BankCard("01/23", 5_000)),
    new User("Pervin", "Aliyev", new BankCard("12/25",15_500)),
    new User("Rustem", "Bayramov", new BankCard("10/22",12_500)),
    new User("Cavid", "Bayramov", new BankCard("5/25",8_500))
};

labelEnteringToCard:;
clear();
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("\n\n\n\t\t\tT H E   P I N S   A R E: \n");
for (int i = 0; i < Clients.Length; i++)
{
    Console.WriteLine($"\t\t{i + 1}) {Clients[i].CreditCard.PIN}");
}

Console.ForegroundColor= ConsoleColor.DarkYellow;
Console.Write("\nEnter PIN Which You Want: ");
Console.ForegroundColor= ConsoleColor.Yellow;
string? sPIN = Console.ReadLine();
int ind = 0;
bool check = false;

for (int i = 0; i < Clients.Length; i++)
{
    if (Clients[i].CreditCard.PIN == sPIN)
    {
        check = true;
        ind = i;
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write($"\n{Clients[i].Name} {Clients[i].Surname} ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Xos gelmisiniz zehmet olmasa novbeti merhelede birini secerdiniz.");
        Thread.Sleep(3000);
        break;
    }
}

if (!check)
    goto labelEnteringToCard;


labelMenu:;
Console.ForegroundColor = ConsoleColor.Green;
void menu()
{
    Console.WriteLine("\n\n\n\t\t\t --------------------------------");
    Console.WriteLine("\t\t\t|   1)  BALANCE                   |");
    Console.WriteLine("\t\t\t|   2)  NAGD PUL                  |");
    Console.WriteLine("\t\t\t|   3)  MOVE MONEY TO OTHER CARD  |");
    Console.WriteLine("\t\t\t|   4)  COME BACK                 |");
    Console.WriteLine("\t\t\t --------------------------------\n");
}

clear();
menu();
Console.ForegroundColor = ConsoleColor.DarkYellow;
Console.Write("Enter Your Select: ");
Console.ForegroundColor = ConsoleColor.Yellow;
var selectKey = Console.ReadKey();

if (selectKey.Key == ConsoleKey.D1 || selectKey.Key == ConsoleKey.NumPad1)
{
    clear();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"\t\tB A L A N C E: {Clients[ind].CreditCard.Balance} $\n");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("Press any key to come back...");
    Console.ReadKey();
    goto labelMenu;
}

else if (selectKey.Key == ConsoleKey.D2 || selectKey.Key == ConsoleKey.NumPad2)
{
labelTakeMoneyFromCard:;
    clear();
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.Write("Enter count of money to take: ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    long selectedMoney = long.Parse(Console.ReadLine());

    if (selectedMoney < 0)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        try
        {
            throw new Exception("YOUR SELECT IS SMALLER THAN ZERO.");
        }
        catch (Exception ex)
        {
            clear();
            Console.WriteLine($"\n\n\t\tE X C E P T I O N:\n\tEx Message: {ex.Message}");
            Thread.Sleep(4000);
            goto labelTakeMoneyFromCard;
        }
    }

    else if (Clients[ind].CreditCard.Balance - selectedMoney < 0)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        try
        {
            throw new OverflowException("YOU HAVE'NT GOT ENOUGH MONEY.");
        }
        catch (Exception ex)
        {
            clear();
            Console.WriteLine($"\n\n\t\tE X C E P T I O N:\n\tEx Message: {ex.Message}");
            Thread.Sleep(4000);
            goto labelTakeMoneyFromCard;
        }
    }

    Clients[ind].CreditCard.Balance -= selectedMoney;
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\nY O U   S U C C E S F U L Y   T A K E   M O N E Y.\n");
    Console.WriteLine("Press any key to come back...");
    Console.ReadKey();
    goto labelMenu;
}

else if (selectKey.Key == ConsoleKey.D3 || selectKey.Key == ConsoleKey.NumPad3)
{
labelPANS:;
    clear();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\n\n\n\t\t\tT H E   P A N S   A R E:\n");
    for (int i = 0, k = 1; i < Clients.Length; i++)
    {
        if (i == ind)
            continue;
        Console.WriteLine($"\t\t{k++}) {Clients[i].CreditCard.PAN}");
    }

    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.Write("\nEnter PAN which you want to put Money (write \"esc\" to comeback): ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    string pan = Console.ReadLine();
    if (pan.ToUpper() == "ESC") 
    {
        goto labelMenu;
    }
    bool checks = false;
    int indpan = 0;
    for (int i = 0; i < Clients.Length; i++)
    {
        if (Clients[i].CreditCard.PAN == pan && i != ind)
        {
            indpan = i;
            checks = true;
            break;
        }
    }
    if (!checks)
    {
        try
        {
            throw new InvalidDataException("THE PAN IS NOT EXIST.");
        }
        catch (Exception ex)
        {
            clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"\n\n\n\t\t\tE X C E P T I O N\n\t\tEX MESSAGE: {ex.Message}");
            Thread.Sleep(3000);
            goto labelPANS;
            throw;
        }
    }
labelTakeMoneyWithPAN:;
    clear();
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.Write("Enter count of money: ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    long countMoney = int.Parse(Console.ReadLine());

    if (countMoney < 0)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        try
        {
            throw new Exception("YOUR SELECT IS SMALLER THAN ZERO.");
        }
        catch (Exception ex)
        {
            clear();
            Console.WriteLine($"\n\n\t\tE X C E P T I O N:\n\tEx Message: {ex.Message}");
            Thread.Sleep(4000);
            goto labelTakeMoneyWithPAN;
        }
    }

    else if (Clients[ind].CreditCard.Balance - countMoney < 0)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        try
        {
            throw new OverflowException("YOU HAVE'NT GOT ENOUGH MONEY.");
        }
        catch (Exception ex)
        {
            clear();
            Console.WriteLine($"\n\n\t\tE X C E P T I O N:\n\tEx Message: {ex.Message}");
            Thread.Sleep(4000);
            goto labelTakeMoneyWithPAN;
        }
    }

    Clients[ind].CreditCard.Balance -= countMoney;
    Clients[indpan].CreditCard.Balance += countMoney;
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\nY O U   S U C C E S F U L Y   M O V E D   M O N E Y.\n");
    Console.WriteLine("Press any key to come back...");
    Console.ReadKey();
    goto labelMenu;
}

else if (selectKey.Key == ConsoleKey.D4 || selectKey.Key == ConsoleKey.NumPad4)
    goto labelEnteringToCard;

else
    goto labelMenu;