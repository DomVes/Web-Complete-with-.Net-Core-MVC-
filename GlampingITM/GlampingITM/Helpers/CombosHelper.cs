using GlampingITM.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GlampingITM.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _context;
        public CombosHelper(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SelectListItem>> GetComboCategoriesAsync()
        {
            List<SelectListItem> list = await _context.Categories.Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString(),

            } )
                .OrderBy(c => c.Text)
                .ToListAsync();
            list.Insert(0, new SelectListItem { Text = "[Seleccione una categoría ...]", Value = "0" });
            return list;
        }
    }
}
