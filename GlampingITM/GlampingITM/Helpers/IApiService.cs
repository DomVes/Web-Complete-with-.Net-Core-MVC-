using GlampingITM.Common;

namespace GlampingITM.Helpers
{
    public interface IApiService
    {
        Task<Response> GetListAsync<T>(string servicePrefix, string controller);
    }

}
