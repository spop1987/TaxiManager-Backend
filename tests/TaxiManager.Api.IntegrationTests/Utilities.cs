using TaxiManagerDomain.Entities;
using TaxiManagerInfrastructure;

namespace TaxiManager.Api.IntegrationTests
{
    public static class Utilities
    {
        public static void InitializeDbForTests(TaxiManagerContext db)
        {
            db.Users.Add(new User{ Email = "adminTest@mail.com", Password = "Pa$$wordTest", FirstName = "Sergio Test", LastName = "Perez Test", Telephone = "1111111", NationalId = 1093543987});
            db.SaveChanges();
        }   
    }
}