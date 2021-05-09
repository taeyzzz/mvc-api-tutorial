using System.Security.AccessControl;

namespace APIMVCLearning.RequestPayload
{
    public class UserPayload
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string telephoneNumber { get; set; }
        public string email { get; set; }
        public string birthday { get; set; }
    }
}