using GlampingITM.Common;
using GlampingITM.Models;

namespace GlampingITM.Helpers
{

    public interface IOrdersHelper
    {
        Task<Response> ProcessOrderAsync(ShowCartViewModel model);
    }

}
