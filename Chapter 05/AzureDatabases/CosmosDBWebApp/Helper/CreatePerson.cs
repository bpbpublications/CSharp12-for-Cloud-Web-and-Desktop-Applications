using CosmosDBWebApp.Models;

namespace CosmosDBWebApp.Helper
{
    public static class CreatePerson
    {
        public static Person GetNewPerson()
        {
            Random random = new Random();
            return new Person
            {
                BirthDate = DateTime.Now.AddYears(28),
                Id = random.Next() + "Thiago",
                Name = "Thiago",
                LastName = "Araujo",
                Vehicle = new Vehicle
                {
                    Id = random.Next() + "BMW",
                    Make = "BMW",
                    Model = "116D",
                    Year = random.Next()
                },
                Address = new Address
                {
                    Id = random.Next() + "Portugal",
                    City = "Lisbonne",
                    StreetAndNumber = "Avenida da Liberdade, 25"
                }
            };
        }
    }
}
