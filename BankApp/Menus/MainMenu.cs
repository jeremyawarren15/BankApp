using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Menus
{
    public class MainMenu
    {
        public int GetMenuSelection()
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Deposit");
            Console.WriteLine("4. Transfer");
            Console.Write("Selection: ");
            var selection =  Int32.Parse(Console.ReadLine());

            if (selection > 0 && selection <= 4)
            {
                return selection;
            }

            return -1;
        }
    }
}
