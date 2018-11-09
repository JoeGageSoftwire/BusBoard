using System.Collections.Generic;
using System.Security.Permissions;

namespace BusBoard.ConsoleApp
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