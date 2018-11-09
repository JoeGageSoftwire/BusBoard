namespace BusBoard.ConsoleApp
{
    class Bus
    {
        public string id;
        public string towards;
        public string destinationName;
        public int timeToStation;

        public Bus(string towards, string destinationName, int timeToStation, string id)
        {
            this.towards = towards;
            this.destinationName = destinationName;
            this.timeToStation = timeToStation;
            this.id = id;
        }
    }
}