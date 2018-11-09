using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using RestSharp;
using RestSharp.Authenticators;

using Newtonsoft.Json;
using BusBoard.Api;


namespace BusBoard.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var postcode = UserInterface.GetPostcode();

            var coordinates = ApiFetcher.GetCoordinates(postcode);

            var stopPoints = ApiFetcher.GetStopPoints(coordinates.result);

            foreach (var stopPoint in stopPoints)
            {
                var buses = ApiFetcher.GetBuses(stopPoint);
                
                UserInterface.ShowInformation(buses, stopPoint.commonName);
            }

            Console.ReadLine();
        }
    }
}
