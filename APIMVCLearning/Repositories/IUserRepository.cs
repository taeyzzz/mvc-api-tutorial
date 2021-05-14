using System.Collections.Generic;
using APIMVCLearning.Models;

namespace APIMVCLearning.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> listUsers();
        User getUserById(int id);
        User createUser(User user);
        void deleteUser(int id);
        void updateUser(int id, User user);

        User getAdminUser();
    }
}