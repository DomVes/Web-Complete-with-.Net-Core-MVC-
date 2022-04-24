using GlampingITM.Data.Entities;
using GlampingITM.Enum;
using GlampingITM.Helpers;

namespace GlampingITM.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCategoriesAsync();
            await CheckRolesAsync();
            await CheckCountriesAsync();
            await CheckUserAsync("1036784623", "Juan Esteban", "Castaño Castaño", "juan_esteban@yopmail.com", "301 285 96 82", "Carrera 92a calle 78b-141", UserType.Admin);
            await CheckUserAsync("1017436842", "Cristian", "Zapata", "cristian_zapata@yopmail.com", "312 234 56 34", "Calle 74 #92-43", UserType.User);
        }

        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country
                {
                    Name = "Colombia",
                    States = new List<State>()
                    {
                        new State()
                        {
                            Name = "Antioquia",
                            Cities = new List<City>() {
                                new City() { Name = "Medellín" },
                                new City() { Name = "Itagüí" },
                                new City() { Name = "Envigado" },
                                new City() { Name = "Bello" },
                                new City() { Name = "Barbosa" },
                                new City() { Name = "Santa Elena" },
                                new City() { Name = "La Ceja" },
                                new City() { Name = "La Unión" },
                                new City() { Name = "Girardota" },
                                new City() { Name = "La Estrella" },
                                new City() { Name = "Caldas" },
                                new City() { Name = "Sabaneta" },
                                new City() { Name = "Copacabana" },
                                new City() { Name = "San Cristóbal" },
                                new City() { Name = "Palmitas" },
                                new City() { Name = "San ta fé de Antioquia" },
                                
                            }
                        },
                        new State()
                        {
                            Name = "Bogotá",
                            Cities = new List<City>() {
                                new City() { Name = "Usaquen" },
                                new City() { Name = "Champinero" },
                                new City() { Name = "Santa fe" },
                                new City() { Name = "Useme" },
                                new City() { Name = "Bosa" },
                            }
                        },
                    }
                });               
                
            }

            await _context.SaveChangesAsync();
        }

        private async Task<User> CheckUserAsync(
            string document,
            string firstName,
            string lastName,
            string email,
            string phone,
            string address,
            UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,                    
                    City = _context.Cities.FirstOrDefault(),
                    UserType = userType,
                };

                await _userHelper.AddUserAsync(user, "adm123");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }


        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());

        }

        private async Task CheckCategoriesAsync()
        {
            if (!_context.Categories.Any())
            {
                _context.Categories.Add(new Category { Name = "Burbuja" });
                _context.Categories.Add(new Category { Name = "Cabaña" });
                _context.Categories.Add(new Category { Name = "Elevado" });
                _context.Categories.Add(new Category { Name = "Acuático" });
                _context.Categories.Add(new Category { Name = "Isla" });
                _context.Categories.Add(new Category { Name = "Arbol" });
                _context.Categories.Add(new Category { Name = "Castillo" });
                _context.Categories.Add(new Category { Name = "Lujo" });
                await _context.SaveChangesAsync();
            }
        }
    }
}
