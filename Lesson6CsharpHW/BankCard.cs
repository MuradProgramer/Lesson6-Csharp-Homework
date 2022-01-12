using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6CsharpHW
{
    internal class BankCard
    {
        public string PAN { get; set; }

        public string PIN { get; set; }

        public int CVC { get; set; }

        public string ExpireDate { get; set; }

        public double Balance { get; set; }

        public BankCard(string expireDate, double balance)
        {
            if (balance < 0)
                throw new ArgumentOutOfRangeException(nameof(balance), " smaller than zero.");

            Random rand = new();
            int n = 4;
            while (n > 0)
            {
                PAN += (rand.Next(1000, 10000)).ToString();
                rand = new();
                PAN += "-";
                n--;
            }
            PAN = PAN.Remove(PAN.Length - 1);

            PIN = (rand.Next(1000, 10000)).ToString();
            rand = new();

            CVC = rand.Next(100, 1000);

            ExpireDate = expireDate;
            Balance = balance;
        }

        public void ShowBankCard()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"PAN: {PAN}  |  PIN: {PIN}  |  CVC: {CVC}");
            Console.ResetColor();
        }
    }
}
