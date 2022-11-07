using System.Linq;
using Sparsh.Models.Database;

namespace Sparsh.Repositories
{
    public interface IUserRepo
    {
        User GetByUsername(string username);
        User Create(User newUser);
    }

    public class UserRepo : IUserRepo
    {
        private readonly SparshDbContext _context;

        public UserRepo(SparshDbContext context)
        {
            _context = context;
        }

        public User GetByUsername(string username)
        {
            return _context.Users.Single(user => user.Username == username);
        }

        public User Create(User newUser)
        {
            var insertResponse = _context.Users.Add(newUser);

            _context.SaveChanges();

            return insertResponse.Entity;
        }
    }
}
