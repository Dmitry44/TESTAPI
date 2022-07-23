using TESTAPI.Core;

namespace TESTAPI.Services
{
    public interface IDataService
    {
        Task<IEnumerable<Beer>> Load(string url);
    }
}
