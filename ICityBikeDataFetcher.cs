using System.Threading.Tasks;

namespace Assignment_1
{
    public interface ICityBikeDataFetcher
    {
       Task<int> GetBikeCountInStation(string stationName);  
    }
}