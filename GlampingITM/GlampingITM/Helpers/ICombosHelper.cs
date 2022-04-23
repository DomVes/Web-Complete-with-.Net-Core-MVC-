using Microsoft.AspNetCore.Mvc.Rendering;

namespace GlampingITM.Helpers
{
    public interface ICombosHelper
    {
        Task<IEnumerable<SelectListItem>> GetComboCategoriesAsync();

        //TODO: Pending add StatesandCountries
        /*
         Task<IEnumerable<SelectListItem>> GetComboCountriesAsync();

         Task<IEnumerable<SelectListItem>> GetComboStatesAsync(int countryId);

         Task<IEnumerable<SelectListItem>> GetComboCitiesAsync(int stateId);

        */
    }
}
