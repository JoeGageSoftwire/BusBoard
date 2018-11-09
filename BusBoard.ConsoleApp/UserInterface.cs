using System;
using System.Collections.Generic;
using BusBoard.Api;

namespace BusBoard.ConsoleApp
{
    static class UserInterface
    {
        public static string GetPostcode()
        {
            Console.WriteLine("Please enter your postcode:");
            Console.WriteLine();

            var postcode = Console.ReadLine();

            return postcode;
        }

        public static void ShowInformation(List<Bus> buses, string stopName)
        {
            Console.WriteLine($"Next five buses at {stopName}:");

            var counter = 1;

            foreach (var bus in buses)
            {
                bus.timeToStation = bus.timeToStation / 60;
                Console.Write($"Bus number {counter}: ");
                Console.WriteLine($"ID: {bus.id}, Route: {bus.towards}, Destination: {bus.destinationName}, Time to station: {bus.timeToStation}");
                counter++;
            }
            Console.WriteLine();
        }
    }
}