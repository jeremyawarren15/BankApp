using BankApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Contracts.RepositoryContracts
{
    public interface IUserRepository
    {
        User CreateUser(User user);
        User GetUser(int userId);
        IEnumerable<User> GetUsers();
        User UpdateUser(User user);
        bool DeleteUser(User user);
    }
}
