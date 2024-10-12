using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace RandomDataGenerator.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext())
            {
                if (context.Genders.Any() || context.Hobbies.Any())
                {
                    return;   // DB has been seeded
                }

                context.Genders.AddRange(
                    new Gender { Name = "Pria" },
                    new Gender { Name = "Wanita" }
                );

                context.Hobbies.AddRange(
                    new Hobby { Name = "Sepak Bola" },
                    new Hobby { Name = "Badminton" },
                    new Hobby { Name = "Tennis" },
                    new Hobby { Name = "Renang" },
                    new Hobby { Name = "Bersepeda" },
                    new Hobby { Name = "Tidur" }
                );

                context.SaveChanges();
            }
        }
    }
}
