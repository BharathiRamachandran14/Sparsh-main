using System;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Sparsh.Repositories;
using Sparsh.Models.Database;

namespace Sparsh.Services
{
    public interface IAuthService
    {
        bool IsValidLoginInfo(string username, string password);
        bool IsAdmin(string username);
        User GetUserByLogin(string username, string password);
    }
    public class AuthService : IAuthService
    {
        private readonly IUserRepo _users;

        public AuthService(IUserRepo users)
        {
            _users = users;
        }

        public bool IsValidLoginInfo(string username, string password)
        {
            var foundUser = _users.GetByUsername(username);

            if (foundUser != null)
            {
                var foundUserSalt = foundUser.Salt;

                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: password,
                    salt: foundUserSalt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8));

                return hashed == foundUser.HashedPassword;
            }
            else
            {
                return false;
            }
        }
        public bool IsAdmin(string username)
        {
            var foundUser = _users.GetByUsername(username);
            return (foundUser != null && foundUser.Role == Role.Admin);
        }

        public User GetUserByLogin(string username,
                                   string password)
        {
            var check = IsValidLoginInfo(username, password);
            if(!check)
            {
               throw new ArgumentException("Username and password combination not valid.");
            }
            User user = _users.GetByUsername(username);
            return user;
        }
    }
}
