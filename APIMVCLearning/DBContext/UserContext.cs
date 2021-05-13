using System.Data.Entity;
using APIMVCLearning.Models;
using MySql.Data.EntityFramework;

namespace APIMVCLearning.DBContext
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class UserContext : DbContext
    {
        public UserContext() : base("Default")
        {
        }

        public DbSet<User> Users { get; set; }
    }
}