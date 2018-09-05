using System;
using System.Threading.Tasks;

namespace Assignment_1
{
        class Program 
        {
            static void Main(string[] args)
        {
            bool realtime = true;

            if(args.Length >= 2) 
            {
                if (args[1] == "realtime") 
                {
                    realtime = true;
                }
                else if (args[1] == "offline") 
                {
                    realtime = false;
                }
            }
            else if (args.Length == 0) 
            {
                return;
            }

            Console.WriteLine(args[0]);

            int count = 0;

            ICityBikeDataFetcher Futza;

            if (realtime) 
            {
                Futza = new RealTimeCityBikeDataFetcher();
            }
            else
            {
                Futza = new OfflineCityBikeDataFetcher();
            }

            Task<int> task = Futza.GetBikeCountInStation(args[0]);
            task.Wait();
            count = task.Result;

            Console.WriteLine("The Helkamas: " + count.ToString());
        }
    }
}