using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using RestSharp;

namespace BusBoard.Api
{
    public static class ApiFetcher
    {

        public static PostcodeJsonFormat GetCoordinates(string postcode)
        {
            var response = ApiRequest("https://api.postcodes.io", "postcodes/" + postcode);

            var coordinates = JsonConvert.DeserializeObject<PostcodeJsonFormat>(response);

            return coordinates;
        }

        public static List<StopPoint> GetStopPoints(PostcodeLongLat coordinates)
        {
            var response = ApiRequest("https://api.tfl.gov.uk",
                $"StopPoint?stopTypes=NaptanPublicBusCoachTram&radius=1500&lat={coordinates.latitude}&lon={coordinates.longitude}");

            var deserializedResponse = JsonConvert.DeserializeObject<StopPointJsonFormat>(response);

            var stopList = deserializedResponse.stopPoints.OrderBy(x => x.distance).Take(2).ToList();

            return stopList;
        }

        public static List<Bus> GetBuses(StopPoint stopPoint)
        {
            var response = ApiRequest("https://api.tfl.gov.uk",
                "StopPoint/" + stopPoint.naptanId +
                "/Arrivals?app_id=d55bb861&app_key=a5c391d03e8a461105ee02f229bdb8c7");

            var arrivals = JsonConvert.DeserializeObject<List<Bus>>(response).OrderBy(x => x.timeToStation).Take(5).ToList();

            return arrivals;
        }

        public static string ApiRequest(string uri, string restRequest)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var client = new RestClient();
            client.BaseUrl = new Uri(uri);

            var request = new RestRequest(restRequest, Method.GET) { RequestFormat = DataFormat.Json };

            IRestResponse response = client.Execute(request);

            return response.Content;
        }
    }
}