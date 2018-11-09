using System.Collections.Generic;
using System.Web.Mvc;
using BusBoard.Api;
using BusBoard.Web.Models;
using BusBoard.Web.ViewModels;

namespace BusBoard.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult BusInfo(PostcodeSelection selection)
        {
            // Add some properties to the BusInfo view model with the data you want to render on the page.
            // Write code here to populate the view model with info from the APIs.
            // Then modify the view (in Views/Home/BusInfo.cshtml) to render upcoming buses.
            var postcode = new BusInfo(selection.Postcode);
            var coordinates = ApiFetcher.GetCoordinates(postcode.PostCode);

            var stopPoints = ApiFetcher.GetStopPoints(coordinates.result);

            var busStops = new List<BusStop>();

            foreach (var stopPoint in stopPoints)
            {
                var buses = ApiFetcher.GetBuses(stopPoint);
                foreach (var bus in buses)
                {
                    bus.timeToStation = bus.timeToStation / 60;
                }
                var busStop = new BusStop(buses, stopPoint.commonName);

                busStops.Add(busStop);
            }

            return View(busStops);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Information about this site";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact us!";

            return View();
        }
    }
}