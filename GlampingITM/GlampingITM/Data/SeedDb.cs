using GlampingITM.Data.Entities;
using GlampingITM.Enum;
using GlampingITM.Helpers;
using Microsoft.EntityFrameworkCore;

namespace GlampingITM.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private readonly IBlobHelper _blobHelper;

        public SeedDb(DataContext context, IUserHelper userHelper, IBlobHelper blobHelper)
        {
            _context = context;
            _userHelper = userHelper;
            this._blobHelper = blobHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCategoriesAsync();
            await CheckRolesAsync();
            await CheckCountriesAsync();
            await CheckUserAsync("101", "Esteban", "Castaño", "esteban@yopmail.com", 
                "301 285 96 82", "Carrera 92a Cll 78b", "YodaUser.jpg", UserType.Admin);
            await CheckUserAsync("202", "Cristian", "Zapata", "cristianz@yopmail.com", 
                "300 447 23 12", "Carrera 82c cll 51b", "DarthVaderUser.jpg", UserType.User);
            await CheckUserAsync("303", "Vanessa", "Medina", "vanem@yopmail.com", 
                "302 422 17 98", "Carrera 92a Cll 78b", "ObiWanUser.png", UserType.User);
            await CheckUserAsync("404", "Cristina", "Rodas", "cristinr@yopmail.com", 
                "300 588 44 31", "Carrera 82c cll 51b", "PalpatineUser.png", UserType.User);

            await CheckProductsAsync();
        }

        private async Task CheckProductsAsync()
        {
            if (!_context.Products.Any())
            {
                await AddProductAsync("Burbuja 01", 380000M, 4F, new List<string>() {"Burbujas" }, new List<string>() { "B1.1.jpg", "B1.2.jpg" });
                await AddProductAsync("Burbuja 02", 420000M, 4F, new List<string>() {"Burbujas" }, new List<string>() { "B2.1.jpg", "B2.2.jpg", "B2.3.jpg", "B2.4.jpg" });
                await AddProductAsync("Arbol 01", 730000M, 1F, new List<string>() { "Arboles" }, new List<string>() { "A1.1.jpg", "A1.2.jpg", "A1.3.jpg", "A1.4.jpg", "A1.5.jpg" });
                await AddProductAsync("Arbol 02", 630000M, 2F, new List<string>() { "Arboles" }, new List<string>() { "A2.1.jpg", "A2.2.jpg", "A2.3.jpg", "A2.4.jpg", "A2.5.jpg" });
                await AddProductAsync("Cabaña 01", 820000M, 2F, new List<string>() { "Cabañas" }, new List<string>() { "C1.1.jpg", "C1.2.jpg", "C1.3.jpg", "C1.4.jpg" });
                await AddProductAsync("Cabaña 02", 790000M, 3F, new List<string>() { "Cabañas" }, new List<string>() { "C2.1.jpg", "C2.2.jpg", "C2.3.jpg" });
                await AddProductAsync("Cabaña 03", 820000M, 2F, new List<string>() { "Cabañas" }, new List<string>() { "C3.1.png", "C3.2.jpg", "C3.3.jpg" });
                await AddProductAsync("Contenedor 01", 290000M, 4F, new List<string>() { "Contenedores"}, new List<string>() { "CON1.1.jpg", "CON1.2.jpg", "CON1.3.jpg" });
                await AddProductAsync("Domo 01", 670000M, 4F, new List<string>() { "Domos" }, new List<string>() { "DOMO1.1.jpg", "DOMO1.2.jpeg" });
                await AddProductAsync("Domo 02", 650000M, 3F, new List<string>() { "Domos" }, new List<string>() { "DOMO2.1.jpg", "DOMO2.2.jpg", "DOMO2.3.jpg","DOMO2.4.jpg", "DOMO2.5.jpg", "DOMO2.6.jpg" });
                await AddProductAsync("DOMO 03", 660000M, 1F, new List<string>() { "Domos" }, new List<string>() { "DOMO3.1.jpg", "DOMO3.2.jpg", "DOMO3.3.jpg", "DOMO3.4.jpg", "DOMO3.5.jpg" });
                await AddProductAsync("DOMO 04", 680000M, 2F, new List<string>() { "Domos" }, new List<string>() { "DOMO4.1.jpg", "DOMO4.2.jpg" });
                await AddProductAsync("Elevado 01", 320000M, 4F, new List<string>() { "Elevados" }, new List<string>() { "ELE1.1.jpg", "ELE1.2.jpg", "ELE1.3.jpg", "ELE1.4.jpg", "ELE1.5.jpg" });
                await AddProductAsync("Elevado 02", 330000M, 4F, new List<string>() { "Elevados" }, new List<string>() { "ELE2.1.jpg", "ELE2.2.jpg", "ELE2.3.jpg" });
                await AddProductAsync("Lago 01", 430000M, 4F, new List<string>() { "Lagos" }, new List<string>() { "LAG1.1.jpg", "LAG1.2.jpg", "LAG1.3.jpg", "LAG1.4.jpg" });
                await AddProductAsync("Lago 02", 400000M, 4F, new List<string>() { "Lagos" }, new List<string>() { "LAG2.1.jpg", "LAG2.2.jpg" });
                await AddProductAsync("Lago 03", 410000M, 4F, new List<string>() { "Lagos" }, new List<string>() { "LAG3.1.jpg", "LAG3.2.jpg", "LAG3.3.jpg", "LAG3.4.jpg" });
                await AddProductAsync("Moderna 01", 1100000M, 4F, new List<string>() { "Modernas" }, new List<string>() { "MOD1.1.jpg", "MOD1.2.jpg", "MOD1.3.jpg" });
                await AddProductAsync("Tematica 01", 1200000M, 4F, new List<string>() { "Tematicas" }, new List<string>() { "TEM1.1.jpg", "TEM1.2.jpg", "TEM1.3.png" });
                await AddProductAsync("Tipi 01", 500000M, 4F, new List<string>() { "Tipies" }, new List<string>() { "TIP1.1.jpg", "TIP1.2.jpg" });
                await AddProductAsync("Tipi 02", 500000M, 4F, new List<string>() { "Tipies" }, new List<string>() { "TIP2.1.jpg", "TIP2.2.jpg", "TIP2.3.jpg" });
                await AddProductAsync("Tipi 03", 500000M, 4F, new List<string>() { "Tipies" }, new List<string>() { "TIP3.1.jpg", "TIP3.2.jpg" });
                await AddProductAsync("Tipi 04", 500000M, 4F, new List<string>() { "Tipies" }, new List<string>() { "TIP4.1.jpg", "TIP4.2.jpg" });
                await AddProductAsync("Tubular 01", 600000M, 2F, new List<string>() { "Tubulares" }, new List<string>() { "TUB1.1.jpg" });
                await AddProductAsync("Tubular 02", 600000M, 2F, new List<string>() { "Tubulares" }, new List<string>() { "TUB2.1.jpg" });
                await AddProductAsync("Tubular 03", 600000M, 2F, new List<string>() { "Tubulares" }, new List<string>() { "TUB3.1.jpg" });
                await AddProductAsync("Tubular 04", 600000M, 2F, new List<string>() { "Tubulares" }, new List<string>() { "TUB4.1.jpg" });
                await _context.SaveChangesAsync();
            }

        }
        private async Task AddProductAsync(string name, decimal price, float stock, List<string> categories, List<string> images)
        {
            Product prodcut = new()
            {
                Description = name,
                Name = name,
                Price = price,
                Stock = stock,
                ProductCategories = new List<ProductCategory>(),
                ProductImages = new List<ProductImage>()
            };

            foreach (string? category in categories)
            {
                prodcut.ProductCategories.Add(new ProductCategory { Category = await _context.Categories.FirstOrDefaultAsync(c => c.Name == category) });
            }


            foreach (string? image in images)
            {
                Guid imageId = await _blobHelper.UploadBlobAsync($"{Environment.CurrentDirectory}\\wwwroot\\images\\products\\{image}", "products");
                prodcut.ProductImages.Add(new ProductImage { ImageId = imageId });
            }

            _context.Products.Add(prodcut);
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
                        new City() { Name = "Sabaneta" },
                        new City() { Name = "La Ceja" },
                        new City() { Name = "La Union" },
                        new City() { Name = "La Estrella" },
                        new City() { Name = "Copacabana" },
                    }
                },
                new State()
                {
                    Name = "Bogotá",
                    Cities = new List<City>() {
                        new City() { Name = "Usaquen" },
                        new City() { Name = "Champinero" },
                        new City() { Name = "Santa fe" },
                        new City() { Name = "Usme" },
                        new City() { Name = "Bosa" },
                    }
                },
                new State()
                {
                    Name = "Valle",
                    Cities = new List<City>() {
                        new City() { Name = "Calí" },
                        new City() { Name = "Jumbo" },
                        new City() { Name = "Jamundí" },
                        new City() { Name = "Chipichape" },
                        new City() { Name = "Buenaventura" },
                        new City() { Name = "Cartago" },
                        new City() { Name = "Buga" },
                        new City() { Name = "Palmira" },
                    }
                },
                new State()
                {
                    Name = "Santander",
                    Cities = new List<City>() {
                        new City() { Name = "Bucaramanga" },
                        new City() { Name = "Málaga" },
                        new City() { Name = "Barrancabermeja" },
                        new City() { Name = "Rionegro" },
                        new City() { Name = "Barichara" },
                        new City() { Name = "Zapatoca" },
                    }
                },
            }
                });
                _context.Countries.Add(new Country
                {
                    Name = "Estados Unidos",
                    States = new List<State>()
            {
                new State()
                {
                    Name = "Florida",
                    Cities = new List<City>() {
                        new City() { Name = "Orlando" },
                        new City() { Name = "Miami" },
                        new City() { Name = "Tampa" },
                        new City() { Name = "Fort Lauderdale" },
                        new City() { Name = "Key West" },
                    }
                },
                new State()
                {
                    Name = "Texas",
                    Cities = new List<City>() {
                        new City() { Name = "Houston" },
                        new City() { Name = "San Antonio" },
                        new City() { Name = "Dallas" },
                        new City() { Name = "Austin" },
                        new City() { Name = "El Paso" },
                    }
                },
                new State()
                {
                    Name = "California",
                    Cities = new List<City>() {
                        new City() { Name = "Los Angeles" },
                        new City() { Name = "San Francisco" },
                        new City() { Name = "San Diego" },
                        new City() { Name = "San Bruno" },
                        new City() { Name = "Sacramento" },
                        new City() { Name = "Fresno" },
                    }
                },
            }
                });
                _context.Countries.Add(new Country
                {
                    Name = "Ecuador",
                    States = new List<State>()
            {
                new State()
                {
                    Name = "Pichincha",
                    Cities = new List<City>() {
                        new City() { Name = "Quito" },
                    }
                },
                new State()
                {
                    Name = "Esmeraldas",
                    Cities = new List<City>() {
                        new City() { Name = "Esmeraldas" },
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
            string image,
            UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                Guid imageId = await _blobHelper.UploadBlobAsync($"{Environment.CurrentDirectory}\\wwwroot\\images\\users\\{image}", "users");
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
                    ImageId = imageId
                };

                await _userHelper.AddUserAsync(user, "adm123");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());

                string token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);

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
                _context.Categories.Add(new Category { Name = "Burbujas" });
                _context.Categories.Add(new Category { Name = "Cabañas" });
                _context.Categories.Add(new Category { Name = "Elevados" });
                _context.Categories.Add(new Category { Name = "Lagos" });
                _context.Categories.Add(new Category { Name = "Modernas" });
                _context.Categories.Add(new Category { Name = "Arboles" });
                _context.Categories.Add(new Category { Name = "Tematicas" });
                _context.Categories.Add(new Category { Name = "Tipies" });
                _context.Categories.Add(new Category { Name = "Contenedores" });
                _context.Categories.Add(new Category { Name = "Tubulares" });
                _context.Categories.Add(new Category { Name = "Domos" });
                await _context.SaveChangesAsync();
            }
        }
    }
}
