using BankApp.Contracts.RepositoryContracts;
using BankApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BankContext _context;

        public UserRepository(BankContext context)
        {
            _context = context;
        }

        public User CreateUser(User user)
        {
            _context.Users.Add(user);

            _context.SaveChanges();

            return _context.Users.Find(user.Id);
        }

        public bool DeleteUser(User user)
        {
            _context.Users.Remove(user);

            return _context.SaveChanges() == 1;
        }

        public User GetUser(int userId)
        {
            return _context.Users
                .SingleOrDefault(x => x.Id == userId);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public User UpdateUser(User user)
        {
            var oldUser = GetUser(user.Id);

            oldUser.FirstName = user.FirstName;
            oldUser.LastName = user.LastName;
            oldUser.ModifiedDate = DateTimeOffset.UtcNow;

            _context.SaveChanges();

            return _context.Users.Find(oldUser.Id);
        }
    }
}
