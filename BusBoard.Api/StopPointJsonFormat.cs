using System.Collections.Generic;

namespace BusBoard.Api
{
    public class StopPointJsonFormat
    {
        public List<StopPoint> stopPoints;

        public StopPointJsonFormat(List<StopPoint> stopPoints)
        {
            this.stopPoints = stopPoints;
        }
    }
}