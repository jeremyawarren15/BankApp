using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Menus
{
    public class Login
    {
        public int GetUserId()
        {
            Console.WriteLine("Enter your User Id");
            return Int32.Parse(Console.ReadLine());
        }
    }
}
