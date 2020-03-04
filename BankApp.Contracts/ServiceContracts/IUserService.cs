using BankApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Contracts.ServiceContracts
{
    public interface IUserService
    {
        User CreateUser(User user);
        User GetUser(int id);
        IEnumerable<User> GetUsers();
        User UpdateUser(User user);
        bool DeleteUser(User user);
    }
}
