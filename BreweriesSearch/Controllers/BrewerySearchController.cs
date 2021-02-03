using BreweriesSearch.Models;
using BreweriesSearch.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace BreweriesSearch.Controllers
{
    public class BrewerySearchController : Controller
    {
        private readonly IBrewerySearchClient _brewerySearchClient;
        public BrewerySearchController(IBrewerySearchClient brewerySearchClient)
        {
            _brewerySearchClient = brewerySearchClient;
        }
        public async Task<IActionResult> GetAllBreweries()
        {

            var response = await _brewerySearchClient.GetBreweryInfo();
            var tempBreweryObj = new Class1();
            var model = new BreweryViewModel();
            var listOfBreweries = new List<Class1>();

            //foreach (Class1 brewery in response.Property1 )
            //{
            //    tempBreweryObj.name = brewery.name;
            //    tempBreweryObj.phone = brewery.phone;
            //    tempBreweryObj.street = brewery.street;
            //    tempBreweryObj.city = brewery.city;
            //    tempBreweryObj.state = brewery.state;
            //    tempBreweryObj.country = brewery.country;
            //    tempBreweryObj.postal_code = brewery.postal_code;
            //    tempBreweryObj.website_url = brewery.website_url;
            //    tempBreweryObj.brewery_type = brewery.brewery_type;

            //    listOfBreweries.Add(brewery);
            //}
            model.BreweriesList = response.Property1;
            return View();
        }
        //public async Task<IActionResult> SearchBreweries()
        //{


        //    return View();
        //}

    }
}
