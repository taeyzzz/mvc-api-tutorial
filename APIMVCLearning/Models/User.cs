using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Ajax.Utilities;

namespace APIMVCLearning.Models
{
    public class User
    {
        [Key] public int id { get; set; }

        [Required] public string email { get; set; }

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string telephoneNumber { get; set; }
        public string birthday { get; set; }

        public int? age
        {
            get
            {
                int? prepareAge = null;
                if (!birthday.IsNullOrWhiteSpace())
                {
                    var todayDate = DateTime.Today;
                    prepareAge = todayDate.Year - DateTime.Parse(birthday).Year;
                }

                return prepareAge;
            }
        }
    }
}