using System.Collections.Generic;

namespace BusBoard.Api
{
    public class BusStop
    {
        public List<Bus> BusList;
        public string StopName;

        public BusStop(List<Bus> busList, string stopName)
        {
            BusList = busList;
            StopName = stopName;
        }
    }
}