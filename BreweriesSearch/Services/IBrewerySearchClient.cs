using System.Threading.Tasks;

namespace BreweriesSearch.Services
{
    public interface IBrewerySearchClient
    {
        Task<BrewerySearchResponse> GetBreweryInfo(string theRest = "breweries");
    }
}
