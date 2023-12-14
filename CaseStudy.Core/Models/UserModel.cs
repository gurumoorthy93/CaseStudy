namespace CaseStudy.Core.Models
{
    public class UserModel
    {
        public UserModel()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            Address = string.Empty;
            City = string.Empty;
            Region = string.Empty;
            ZipCode = string.Empty;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }  
        public string ZipCode { get; set; }
    }
}
