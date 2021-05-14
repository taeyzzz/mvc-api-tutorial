using System.Collections.Generic;
using System.Linq;
using APIMVCLearning.DBContext;
using APIMVCLearning.Models;

namespace APIMVCLearning.Repositories
{
    public class UserRepository : IUserRepository
    {
        private UserContext _context; 
        private readonly User _adminUser = new User
        {
            id = 1,
            email = "taeyzao@gmail.com",
            firstName = "taey",
            lastName = "kultontikorn",
            telephoneNumber = "0888888888",
            birthday = "1995/12/07"
        };

        public UserRepository()
        {
            _context = new UserContext();
        }

        public IEnumerable<User> listUsers()
        {
            var listUsers = _context.Users.ToList();
            return listUsers;
        }

        public User getUserById(int id)
        {
            var targetUser = _context.Users.Find(id);
            return targetUser;
        }

        public User createUser(User user)
        {
            var preparedNewUser = new User
            {
                email = user.email,
                firstName = user.firstName,
                lastName = user.lastName,
                telephoneNumber = user.telephoneNumber,
                birthday = user.birthday
            };
            var createdUser = _context.Users.Add(preparedNewUser);
            _context.SaveChanges();
            return createdUser;
        }

        public void deleteUser(int id)
        {
            User user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public void updateUser(int id, User user)
        {
            throw new System.NotImplementedException();
        }

        public User getAdminUser()
        {
            var adminUser = _context.Users.FirstOrDefault(u => u.email == "taeyzao@gmail.com");
            return adminUser;
        }
    }
}