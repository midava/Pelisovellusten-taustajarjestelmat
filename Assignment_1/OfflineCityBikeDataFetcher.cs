using System;
using System.Threading.Tasks;

namespace Assignment_1 {
    public class OfflineCityBikeDataFetcher : ICityBikeDataFetcher {
        public async Task<int> GetBikeCountInStation (string stationName) {
            try {
                string[] lines = await System.IO.File.ReadAllLinesAsync (@"//Users/midava/Desktop/Assignment_1/bikedata.txt");

                int bikes = 0;
                bool found = false;

                foreach (string line in lines) {
                    string[] subStrings = line.Split (" : ");

                    if (subStrings.Length >= 2 && subStrings[0] == stationName) {
                        found = true;
                        bikes = Int32.Parse (subStrings[1]);
                        break;
                    }
                }
                if (!found) {
                    throw new NotFoundException (stationName);
                }
                return bikes;
            } catch (ArgumentException ex) {
                Console.WriteLine ("Invalid argument: " + ex.Message);
                return 0;
            } catch (NotFoundException ex) {
                Console.WriteLine ("Not found: " + ex.Message);
                return 0;
            } catch (Exception ex) {
                Console.WriteLine (ex.Message);
                return 0;
            }
        }
    }
}