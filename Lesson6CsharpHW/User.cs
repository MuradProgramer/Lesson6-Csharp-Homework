using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6CsharpHW
{
    internal class User
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public BankCard CreditCard { get; set; }

        public User(string name, string surname, BankCard bankAccaunt)
        {
            Name = name;
            Surname = surname;
            CreditCard = bankAccaunt;
        }
    }
}
