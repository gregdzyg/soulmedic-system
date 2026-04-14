using SoulMedic.Api.Domain.Entities;

namespace SoulMedic.Api.Data
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            if (!context.Specializations.Any())
            {
                var specializations = new List<Specialization>
                {
                    new Specialization { Name = "Psycholog", Description = "Wsparcie psychologiczne i diagnoza" },
                    new Specialization { Name = "Psychoterapeuta", Description = "Terapia indywidualna i długoterminowa" },
                    new Specialization { Name = "Psychiatra", Description = "Leczenie farmakologiczne i diagnoza psychiatryczna" }
                };

                context.Specializations.AddRange(specializations);
                await context.SaveChangesAsync();
            }

            if (!context.Specialists.Any())
            {
                var psycholog = context.Specializations.First(s => s.Name == "Psycholog").Id;
                var psychoterapeuta = context.Specializations.First(s => s.Name == "Psychoterapeuta").Id;
                var psychiatra = context.Specializations.First(s => s.Name == "Psychiatra").Id;

                var specialists = new List<Specialist>
                {
                    new Specialist { FirstName = "Anna", LastName = "Kowalska", Email = "anna.kowalska@test.pl", PhoneNumber = "500100100", SpecializationId = psycholog, Bio = "Specjalistka terapii poznawczo-behawioralnej z 10-letnim doświadczeniem.", IsActive = true },
                    new Specialist { FirstName = "Jan", LastName = "Nowak", Email = "jan.nowak@test.pl", PhoneNumber = "500100101", SpecializationId = psychoterapeuta, Bio = "Psychoterapeuta pracujący w nurcie psychodynamicznym.", IsActive = true },
                    new Specialist { FirstName = "Marta", LastName = "Wiśniewska", Email = "marta.w@test.pl", PhoneNumber = "500100102", SpecializationId = psychiatra, Bio = "Lekarz psychiatra zajmujący się leczeniem zaburzeń lękowych i depresji.", IsActive = true },

                    new Specialist { FirstName = "Piotr", LastName = "Zieliński", Email = "piotr.z@test.pl", PhoneNumber = "500100103", SpecializationId = psycholog, Bio = "Psycholog dziecięcy i rodzinny.", IsActive = true },
                    new Specialist { FirstName = "Katarzyna", LastName = "Lewandowska", Email = "katarzyna.l@test.pl", PhoneNumber = "500100104", SpecializationId = psychoterapeuta, Bio = "Prowadzi terapię indywidualną oraz par.", IsActive = true },
                    new Specialist { FirstName = "Tomasz", LastName = "Kamiński", Email = "tomasz.k@test.pl", PhoneNumber = "500100105", SpecializationId = psychiatra, Bio = "Specjalizuje się w leczeniu zaburzeń snu.", IsActive = true },

                    new Specialist { FirstName = "Agnieszka", LastName = "Dąbrowska", Email = "agnieszka.d@test.pl", PhoneNumber = "500100106", SpecializationId = psycholog, Bio = "Pomaga w radzeniu sobie ze stresem i wypaleniem zawodowym.", IsActive = true },
                    new Specialist { FirstName = "Michał", LastName = "Wójcik", Email = "michal.w@test.pl", PhoneNumber = "500100107", SpecializationId = psychoterapeuta, Bio = "Terapeuta pracujący z osobami dorosłymi.", IsActive = true },
                    new Specialist { FirstName = "Karolina", LastName = "Kaczmarek", Email = "karolina.k@test.pl", PhoneNumber = "500100108", SpecializationId = psychiatra, Bio = "Leczenie farmakologiczne i konsultacje psychiatryczne.", IsActive = true },

                    new Specialist { FirstName = "Paweł", LastName = "Mazur", Email = "pawel.m@test.pl", PhoneNumber = "500100109", SpecializationId = psycholog, Bio = "Wsparcie w kryzysach życiowych i zawodowych.", IsActive = true }
                };

                context.Specialists.AddRange(specialists);
                await context.SaveChangesAsync();
            }
        }
    }
}