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
            await CheckUserAsync("1010", "Esteban", "Castaño", "esteban@yopmail.com", "301 285 96 82", "Calle Azul Carrera Miel", UserType.Admin);
            await CheckUserAsync("2010", "Cristian", "Zapata", "cristian@yopmail.com", "312 234 56 34", "Calle Azul Carrera Miel", UserType.User);
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
                    //TODO: Pending Add City Entity
                    //City = _context.Cities.FirstOrDefault(),
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
