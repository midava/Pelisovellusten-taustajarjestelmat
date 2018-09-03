using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using System;

namespace Assignment_1
{
    public class RealTimeCityBikeDataFetcher : ICityBikeDataFetcher
    {
        public async Task<int> GetBikeCountInStation(string stationName)
        {
            try 
            {
                if (stationName.Any(char.IsDigit))
                {
                    throw new ArgumentException();
                }

            HttpClient client = new HttpClient();
            string message = await client.GetStringAsync("http://api.digitransit.fi/routing/v1/routers/hsl/bike_rental");
            BikeRentalStationList helkama = JsonConvert.DeserializeObject<BikeRentalStationList>(message);

            int bikes = 0;
            bool found = false;

            foreach (var station in helkama.stations) 
            {
                if (station.name == stationName)
                {
                    bikes = station.bikesAvailable;
                    found = true;
                    break;
                }
            }

            if (!found) 
            {
                throw new NotFoundException(stationName);
            }
            return bikes;
        }
        catch(ArgumentException ex)
        {
            Console.WriteLine("Invalid argument: " + ex.Message);
            return 0;
        }
        
        catch(NotFoundException ex)
        {
            Console.WriteLine("Not found: " + ex.Message);
            return 0;
        }
    }
}
}