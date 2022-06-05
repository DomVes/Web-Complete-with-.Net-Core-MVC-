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
            _blobHelper = blobHelper;
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
                await AddProductAsync("Burbuja 01", 380000M, 4F, new List<string>() {"Burbujas" }, new List<string>() { "B11.jpg", "B12.jpg" });
                await AddProductAsync("Burbuja 02", 420000M, 4F, new List<string>() {"Burbujas" }, new List<string>() { "B21.jpg", "B22.jpg", "B23.jpg", "B24.jpg" });
                await AddProductAsync("Arbol 01", 730000M, 1F, new List<string>() { "Arboles" }, new List<string>() { "A11.jpg", "A12.jpg", "A13.jpg", "A14.jpg", "A15.jpg" });
                await AddProductAsync("Arbol 02", 630000M, 2F, new List<string>() { "Arboles" }, new List<string>() { "A21.jpg", "A22.jpg", "A23.jpg", "A24.jpg", "A25.jpg" });
                await AddProductAsync("Cabaña 01", 820000M, 2F, new List<string>() { "Cabañas" }, new List<string>() { "C11.jpg", "C12.jpg", "C13.jpg", "C14.jpg" });
                await AddProductAsync("Cabaña 02", 790000M, 3F, new List<string>() { "Cabañas" }, new List<string>() { "C21.jpg", "C22.jpg", "C23.jpg" });
                await AddProductAsync("Cabaña 03", 820000M, 2F, new List<string>() { "Cabañas" }, new List<string>() { "C31.png", "C32.jpg", "C33.jpg" });
                await AddProductAsync("Contenedor 01", 290000M, 4F, new List<string>() { "Contenedores"}, new List<string>() { "CON11.jpg", "CON12.jpg", "CON13.jpg" });
                await AddProductAsync("Domo 01", 670000M, 4F, new List<string>() { "Domos" }, new List<string>() { "DOMO11.jpg", "DOMO12.jpeg" });
                await AddProductAsync("Domo 02", 650000M, 3F, new List<string>() { "Domos" }, new List<string>() { "DOMO21.jpg", "DOMO22.jpg", "DOMO23.jpg","DOMO24.jpg", "DOMO25.jpg", "DOMO26.jpg" });
                await AddProductAsync("DOMO 03", 660000M, 1F, new List<string>() { "Domos" }, new List<string>() { "DOMO31.jpg", "DOMO32.jpg", "DOMO33.jpg", "DOMO34.jpg", "DOMO35.jpg" });
                await AddProductAsync("DOMO 04", 680000M, 2F, new List<string>() { "Domos" }, new List<string>() { "DOMO41.jpg", "DOMO42.jpg" });
                await AddProductAsync("Elevado 01", 320000M, 4F, new List<string>() { "Elevados" }, new List<string>() { "ELE11.jpg", "ELE12.jpg", "ELE13.jpg", "ELE14.jpg", "ELE15.jpg" });
                await AddProductAsync("Elevado 02", 330000M, 4F, new List<string>() { "Elevados" }, new List<string>() { "ELE21.jpg", "ELE22.jpg", "ELE23.jpg" });
                await AddProductAsync("Lago 01", 430000M, 4F, new List<string>() { "Lagos" }, new List<string>() { "LAG11.jpg", "LAG12.jpg", "LAG13.jpg", "LAG14.jpg" });
                await AddProductAsync("Lago 02", 400000M, 4F, new List<string>() { "Lagos" }, new List<string>() { "LAG21.jpg", "LAG22.jpg" });
                await AddProductAsync("Lago 03", 410000M, 4F, new List<string>() { "Lagos" }, new List<string>() { "LAG31.jpg", "LAG32.jpg", "LAG33.jpg", "LAG34.jpg" });
                await AddProductAsync("Moderna 01", 1100000M, 4F, new List<string>() { "Modernas" }, new List<string>() { "MOD11.jpg", "MOD12.jpg", "MOD13.jpg" });
                await AddProductAsync("Tematica 01", 1200000M, 4F, new List<string>() { "Tematicas" }, new List<string>() { "TEM11.jpg", "TEM12.jpg", "TEM13.png" });
                await AddProductAsync("Tipi 01", 500000M, 4F, new List<string>() { "Tipies" }, new List<string>() { "TIP11.jpg", "TIP12.jpg" });
                await AddProductAsync("Tipi 02", 500000M, 4F, new List<string>() { "Tipies" }, new List<string>() { "TIP21.jpg", "TIP22.jpg", "TIP23.jpg" });
                await AddProductAsync("Tipi 03", 500000M, 4F, new List<string>() { "Tipies" }, new List<string>() { "TIP31.jpg", "TIP32.jpg" });
                await AddProductAsync("Tipi 04", 500000M, 4F, new List<string>() { "Tipies" }, new List<string>() { "TIP41.jpg", "TIP42.jpg" });
                await AddProductAsync("Tubular 01", 600000M, 2F, new List<string>() { "Tubulares" }, new List<string>() { "TUB11.jpg" });
                await AddProductAsync("Tubular 02", 600000M, 2F, new List<string>() { "Tubulares" }, new List<string>() { "TUB21.jpg" });
                await AddProductAsync("Tubular 03", 600000M, 2F, new List<string>() { "Tubulares" }, new List<string>() { "TUB31.jpg" });
                await AddProductAsync("Tubular 04", 600000M, 2F, new List<string>() { "Tubulares" }, new List<string>() { "TUB41.jpg" });
                await _context.SaveChangesAsync();
            }

        }
        private async Task AddProductAsync(string name, decimal price, float stock, List<string> categories, List<string> images)
        {
            Product product = new()
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
                product.ProductCategories.Add(new ProductCategory { Category = await _context.Categories.FirstOrDefaultAsync(c => c.Name == category) });
            }


            foreach (string? image in images)
            {
                Guid imageId = await _blobHelper.UploadBlobAsync($"{Environment.CurrentDirectory}\\wwwroot\\images\\products\\{image}", "products");
                product.ProductImages.Add(new ProductImage { ImageId = imageId });
            }

            _context.Products.Add(product);
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
