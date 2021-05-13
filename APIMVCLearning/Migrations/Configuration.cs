using System.Data.Entity.Migrations;
using APIMVCLearning.DBContext;
using APIMVCLearning.Models;

namespace APIMVCLearning.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<UserContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(UserContext userContext)
        {
            userContext.Users.AddOrUpdate(x => x.id,
                new User()
                {
                    id = 1,
                    email = "taeyzao@gmail.com",
                    firstName = "taey",
                    lastName = "kultontikorn",
                    telephoneNumber = "0888888888",
                    birthday = "1995/12/07"
                }
            );
        }

    }
}