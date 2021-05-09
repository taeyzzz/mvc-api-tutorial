using System;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using System.Web.ModelBinding;

namespace APIMVCLearning.Models
{
    public class User
    {
        public string id { get; set; }
        [Required]
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string telephoneNumber { get; set; }
        public string birthday { get; set; }

        public int age
        {
            get
            {
                var todayDate = DateTime.Today;
                var age = todayDate.Year - DateTime.Parse(birthday).Year ;
                return age;
            }
        }

    }
}