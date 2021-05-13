using System.Collections.Generic;
using APIMVCLearning.Models;

namespace APIMVCLearning.Repositories
{
    public class UserRepository
    {
        private readonly User _adminUser = new User
        {
            id = 1,
            email = "taeyzao@gmail.com",
            firstName = "taey",
            lastName = "kultontikorn",
            telephoneNumber = "0888888888",
            birthday = "1995/12/07"
        };

        private readonly List<User> listUser = new List<User>();

        public UserRepository()
        {
            listUser.Add(_adminUser);
        }

        public IEnumerable<User> getAllUsers()
        {
            return listUser;
        }

        public User addUser(User newUser)
        {
            var preparedNewUser = new User
            {
                id = listUser.Count + 1,
                email = newUser.email,
                firstName = newUser.firstName,
                lastName = newUser.lastName,
                telephoneNumber = newUser.telephoneNumber,
                birthday = newUser.birthday
            };
            listUser.Add(preparedNewUser);
            return preparedNewUser;
        }

        public User getUserById(int id)
        {
            var targetUser = listUser.Find(u => u.id == id);
            return targetUser;
        }

        public User getAdminUser()
        {
            var adminUser = listUser.Find(u => u.email == "taeyzao@gmail.com");
            return adminUser;
        }
    }
}