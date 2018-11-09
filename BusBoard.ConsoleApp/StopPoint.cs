using System.Runtime.CompilerServices;

namespace BusBoard.ConsoleApp
{
    public class StopPoint
    {
        public string naptanId;
        public string commonName;
        public float distance;

        public StopPoint(string naptanId, float distance, string commonName)
        {
            this.naptanId = naptanId;
            this.distance = distance;
            this.commonName = commonName;
        }
    }
}