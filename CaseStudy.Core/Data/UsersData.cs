using CaseStudy.Core.Models;

namespace CaseStudy.Core.Data
{
    public class UsersData
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@gmail.com",
                Password = "demo",
                Address = "BTM Layout",
                City = "Banglore",
                Region = "Karnataka",
                ZipCode = "560029"
            },
            new UserModel()
            {
                Id = 2,
                FirstName = "Test",
                LastName = "User",
                Email = "testuser@gmail.com",
                Password = "test",
                Address = "MICO Layout",
                City = "Banglore",
                Region = "Karnataka",
                ZipCode = "560029"
            },
            new UserModel()
            {
                Id = 3,
                FirstName = "mike",
                LastName = "hassan",
                Email = "mikehassan@gmail.com",
                Password = "mike",
                Address = "Majestic",
                City = "Banglore",
                Region = "Karnataka",
                ZipCode = "560001"
            },
            new UserModel()
            {
                Id = 4,
                FirstName = "Dan",
                LastName = "Karl",
                Email = "dankarl@gmail.com",
                Password = "karl",
                Address = "Adayar",
                City = "Chennai",
                Region = "TamilNadu",
                ZipCode = "600001"
            }
        };
    }
}
