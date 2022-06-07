using Microsoft.EntityFrameworkCore;
using GlampingITM.Common;
using GlampingITM.Data.Entities;
using GlampingITM.Enum;
using GlampingITM.Helpers;

namespace GlampingITM.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private readonly IBlobHelper _blobHelper;
        private readonly IApiService _apiService;

        public SeedDb(DataContext context, IUserHelper userHelper, IBlobHelper blobHelper, IApiService apiService)
        {
            _context = context;
            _userHelper = userHelper;
            _blobHelper = blobHelper;
            _apiService = apiService;
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
                await AddProductAsync("Burbujas transparentes.", "Bubble Glamping", 380000M, 4F, new List<string>() {"Burbujas" }, new List<string>() { "B11.jpg", "B12.jpg" });
                await AddProductAsync("Burbujas transparentes.", "Elevated Glamping", 420000M, 4F, new List<string>() {"Burbujas" }, new List<string>() { "B21.jpg", "B22.jpg", "B23.jpg", "B24.jpg" });
                await AddProductAsync("Casa de madera.", "Glamping of Neverland", 730000M, 1F, new List<string>() { "Arboles" }, new List<string>() { "A11.jpg", "A12.jpg", "A13.jpg", "A14.jpg", "A15.jpg" });
                await AddProductAsync("Casa de madera.", "Bird's Nest Glamping", 630000M, 2F, new List<string>() { "Arboles" }, new List<string>() { "A21.jpg", "A22.jpg", "A23.jpg", "A24.jpg", "A25.jpg" });
                await AddProductAsync("Cabaña acogedora", "Cottage Glamping", 820000M, 2F, new List<string>() { "Cabañas" }, new List<string>() { "C11.jpg", "C12.jpg", "C13.jpg", "C14.jpg" });
                await AddProductAsync("Cabaña lujosa.", "Kamadeva Glamping", 790000M, 3F, new List<string>() { "Cabañas" }, new List<string>() { "C21.jpg", "C22.jpg", "C23.jpg" });
                await AddProductAsync("Cabaña lujosa.", "Bird House Glamping", 820000M, 2F, new List<string>() { "Cabañas" }, new List<string>() { "C31.png", "C32.jpg", "C33.jpg" });
                await AddProductAsync("Unicos y lujosos.", "Tiny Glamping", 290000M, 4F, new List<string>() { "Contenedores"}, new List<string>() { "CON11.jpg", "CON12.jpg", "CON13.jpg" });
                await AddProductAsync("Vista 360°.", "Prisma Glamping", 670000M, 4F, new List<string>() { "Domos" }, new List<string>() { "DOMO11.jpg", "DOMO12.jpeg" });
                await AddProductAsync("Vista 360°.", "Domos Glamping", 650000M, 3F, new List<string>() { "Domos" }, new List<string>() { "DOMO21.jpg", "DOMO22.jpg", "DOMO23.jpg","DOMO24.jpg", "DOMO25.jpg", "DOMO26.jpg" });
                await AddProductAsync("Vista 360°.", "Kettle Glamping", 660000M, 1F, new List<string>() { "Domos" }, new List<string>() { "DOMO31.jpg", "DOMO32.jpg", "DOMO33.jpg", "DOMO34.jpg", "DOMO35.jpg" });
                await AddProductAsync("Vista 360°.", "Glass Domo", 680000M, 2F, new List<string>() { "Domos" }, new List<string>() { "DOMO41.jpg", "DOMO42.jpg" });
                await AddProductAsync("Cada del árbol.", "Safari Glamping", 320000M, 4F, new List<string>() { "Elevados" }, new List<string>() { "ELE11.jpg", "ELE12.jpg", "ELE13.jpg", "ELE14.jpg", "ELE15.jpg" });
                await AddProductAsync("Cada del árbol.", "Sabana Glmaping", 330000M, 4F, new List<string>() { "Elevados" }, new List<string>() { "ELE21.jpg", "ELE22.jpg", "ELE23.jpg" });
                await AddProductAsync("Material orgánico.", "Under water", 430000M, 4F, new List<string>() { "Lagos" }, new List<string>() { "LAG11.jpg", "LAG12.jpg", "LAG13.jpg", "LAG14.jpg" });
                await AddProductAsync("Material orgánico.", "The lagoon", 400000M, 4F, new List<string>() { "Lagos" }, new List<string>() { "LAG21.jpg", "LAG22.jpg" });
                await AddProductAsync("Material orgánico.", "Upendi Glamping", 410000M, 4F, new List<string>() { "Lagos" }, new List<string>() { "LAG31.jpg", "LAG32.jpg", "LAG33.jpg", "LAG34.jpg" });
                await AddProductAsync("Lujo y clase.", "Glamorous Glamping", 1100000M, 4F, new List<string>() { "Modernas" }, new List<string>() { "MOD11.jpg", "MOD12.jpg", "MOD13.jpg" });
                await AddProductAsync("Donde los sueños se hacen realidad", "The shire Hobbits", 1200000M, 4F, new List<string>() { "Tematicas" }, new List<string>() { "TEM11.jpg", "TEM12.jpg", "TEM13.png" });
                await AddProductAsync("Tienda cónica.", "Natural Connection", 500000M, 4F, new List<string>() { "Tipies" }, new List<string>() { "TIP11.jpg", "TIP12.jpg" });
                await AddProductAsync("Tienda cónica.", "Magic tipi Glamping", 500000M, 4F, new List<string>() { "Tipies" }, new List<string>() { "TIP21.jpg", "TIP22.jpg", "TIP23.jpg" });
                await AddProductAsync("Tienda cónica.", "Romantic Night", 500000M, 4F, new List<string>() { "Tipies" }, new List<string>() { "TIP31.jpg", "TIP32.jpg" });
                await AddProductAsync("Tienda cónica.", "Relax Glamping", 500000M, 4F, new List<string>() { "Tipies" }, new List<string>() { "TIP41.jpg", "TIP42.jpg" });
                await AddProductAsync("Forma de cilindro.", "Capsule of Love", 600000M, 2F, new List<string>() { "Tubulares" }, new List<string>() { "TUB11.jpg" });
                await AddProductAsync("Forma de cilindro.", "Utopía", 600000M, 2F, new List<string>() { "Tubulares" }, new List<string>() { "TUB21.jpg" });
                await AddProductAsync("Forma de cilindro.", "Destiny Tunnel", 600000M, 2F, new List<string>() { "Tubulares" }, new List<string>() { "TUB31.jpg" });
                await AddProductAsync("Forma de cilindro.", "Emotional Hallway", 600000M, 2F, new List<string>() { "Tubulares" }, new List<string>() { "TUB41.jpg" });
                await _context.SaveChangesAsync();
            }

        }
        private async Task AddProductAsync(string description, string name, decimal price, float stock, List<string> categories, List<string> images)
        {
            Product product = new()
            {
                Description = description,
                Name = name,
                Price = price,
                Stock = stock,
                ProductCategories = new List<ProductCategory>(),
                ProductImages = new List<ProductImage>()
            };

            foreach (string category in categories)
            {
                product.ProductCategories.Add(new ProductCategory { Category = await _context.Categories.FirstOrDefaultAsync(c => c.Name == category) });
            }


            foreach (string image in images)
            {
                Guid imageId = await _blobHelper.UploadBlobAsync($"{Environment.CurrentDirectory}\\wwwroot\\images\\products\\{image}", "users");
                product.ProductImages.Add(new ProductImage { ImageId = imageId });
            }

            _context.Products.Add(product);
        }


        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                Response responseCountries = await _apiService.GetListAsync<CountryResponse>("/v1", "/countries");
                if (responseCountries.IsSuccess)
                {
                    List<CountryResponse> countries = (List<CountryResponse>)responseCountries.Result;
                    foreach (CountryResponse countryResponse in countries)
                    {
                        Country country = await _context.Countries.FirstOrDefaultAsync(c => c.Name == countryResponse.Name);
                        if (country == null)
                        {
                            country = new() { Name = countryResponse.Name, States = new List<State>() };
                            Response responseStates = await _apiService.GetListAsync<StateResponse>("/v1", $"/countries/{countryResponse.Iso2}/states");
                            if (responseStates.IsSuccess)
                            {
                                List<StateResponse> states = (List<StateResponse>)responseStates.Result;
                                foreach (StateResponse stateResponse in states)
                                {
                                    State state = country.States.FirstOrDefault(s => s.Name == stateResponse.Name);
                                    if (state == null)
                                    {
                                        state = new() { Name = stateResponse.Name, Cities = new List<City>() };
                                        Response responseCities = await _apiService.GetListAsync<CityResponse>("/v1", $"/countries/{countryResponse.Iso2}/states/{stateResponse.Iso2}/cities");
                                        if (responseCities.IsSuccess)
                                        {
                                            List<CityResponse> cities = (List<CityResponse>)responseCities.Result;
                                            foreach (CityResponse cityResponse in cities)
                                            {
                                                if (cityResponse.Name == "Mosfellsbær" || cityResponse.Name == "Șăulița")
                                                {
                                                    continue;
                                                }
                                                City city = state.Cities.FirstOrDefault(c => c.Name == cityResponse.Name);
                                                if (city == null)
                                                {
                                                    state.Cities.Add(new City() { Name = cityResponse.Name });
                                                }
                                            }
                                        }
                                        if (state.CitiesNumber > 0)
                                        {
                                            country.States.Add(state);
                                        }
                                    }
                                }
                            }
                            if (country.CitiesNumber > 0)
                            {
                                _context.Countries.Add(country);
                                await _context.SaveChangesAsync();
                            }
                        }
                    }
                }
            }
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
