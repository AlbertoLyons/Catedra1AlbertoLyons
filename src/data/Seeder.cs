using Catedra1AlbertoLyons.src.models;
namespace Catedra1AlbertoLyons.src.data
{
    public class Seeder
    {
        public static async Task Seed(DataContext context)
        {
            if (context.Users.Any())
                return;

            var genders = new string[] { "masculino", "femenino", "otro", "prefiero no decirlo" };
            var random = new Random();
            var users = new List<User>
            {
                new User
                {
                    Rut = $"{random.Next(10000000, 99999999)}-{random.Next(0, 9)}",
                    Name = "María Pérez",
                    Email = "mariaperez@gmail.com",
                    Gender = "femenino",
                    Birthdate = new DateTime(1990, 5, 12)
                },
                new User
                {
                    Rut = $"{random.Next(10000000, 99999999)}-{random.Next(0, 9)}",
                    Name = "Jorge González",
                    Email = "jorgegonzalez@gmail.com",
                    Gender = "otro",
                    Birthdate = new DateTime(1985, 11, 23)
                },
                new User
                {
                    Rut = $"{random.Next(10000000, 99999999)}-{random.Next(0, 9)}",
                    Name = "Carla Fuentes",
                    Email = "carlafuentes@gmail.com",
                    Gender = "femenino",
                    Birthdate = new DateTime(2000, 3, 17)
                },
                new User
                {
                    Rut = $"{random.Next(10000000, 99999999)}-{random.Next(0, 9)}",
                    Name = "Pedro Morales",
                    Email = "pedromorales@gmail.com",
                    Gender = "otro",
                    Birthdate = new DateTime(1995, 7, 29)
                },
                new User
                {
                    Rut = $"{random.Next(10000000, 99999999)}-{random.Next(0, 9)}",
                    Name = "Lucía Contreras",
                    Email = "luciacontreras@gmail.com",
                    Gender = "femenino",
                    Birthdate = new DateTime(1998, 9, 2)
                },
                new User
                {
                    Rut = $"{random.Next(10000000, 99999999)}-{random.Next(0, 9)}",
                    Name = "Diego Torres",
                    Email = "diegotorres@gmail.com",
                    Gender = "prefiero no decirlo",
                    Birthdate = new DateTime(2002, 12, 15)
                },
                new User
                {
                    Rut = $"{random.Next(10000000, 99999999)}-{random.Next(0, 9)}",
                    Name = "Sofía Araya",
                    Email = "sofiaaraya@gmail.com",
                    Gender = "femenino",
                    Birthdate = new DateTime(2002, 12, 15)
                },
                new User
                {
                    Rut = $"{random.Next(10000000, 99999999)}-{random.Next(0, 9)}",
                    Name = "Diego Araya",
                    Email = "diegoaraya@gmail.com",
                    Gender = "prefiero no decirlo",
                    Birthdate = new DateTime(2001, 4, 12)
                },
                new User
                {
                    Rut = $"{random.Next(10000000, 99999999)}-{random.Next(0, 9)}",
                    Name = "Oscar Araya",
                    Email = "oscararaya@gmail.com",
                    Gender = "prefiero no decirlo",
                    Birthdate = new DateTime(2003, 12, 10)
                },
                new User
                {
                    Rut = $"{random.Next(10000000, 99999999)}-{random.Next(0, 9)}",
                    Name = "Elias James",
                    Email = "eliasjames@gmail.com",
                    Gender = "masculino",
                    Birthdate = new DateTime(2003, 9, 5)
                },
            };
            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();
        }
    }
}