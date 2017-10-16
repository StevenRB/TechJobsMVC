using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        IList<Dictionary<string, string>> jobs = new List<Dictionary<string, string>>();

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search All";
            ViewBag.jobs = jobs;
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results

        public IActionResult Results(string searchType, string searchTerm)
        {
            //IEnumerable<Dictionary<string, string>> jobs = JobData.FindByColumnAndValue(searchType, searchTerm);

            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Jobs Found";

            //Conditional passing of csv
            if (searchType.Equals("all"))
            {
                if (string.IsNullOrEmpty(searchTerm))
                {
                    ViewBag.jobs = JobData.FindAll();
                }
                else
                {
                    ViewBag.jobs = JobData.FindByValue(searchTerm);
                }
            }

            else if (searchType != "all")
            {
                    ViewBag.jobs = JobData.FindByColumnAndValue(searchType,searchTerm);
            }

            
            //ViewData["searchresults"] = ViewBag.jobs.Count();

            if (ViewBag.jobs.Count == 0)
            {
                ViewData["searchresults"] = "No matches, try a different term.";
            }
            return View("Index");
        }
        /*
          // Fetch results
                    if (columnChoice.Equals("all"))
                    {
                        //Very similiar to else statement 
                        searchResults = JobData.FindByValue(searchTerm);
                        PrintJobs(searchResults);
                        //Console.WriteLine("Search all fields not yet implemented.");
                    }
                    else
                    {
                        searchResults = JobData.FindByColumnAndValue(columnChoice, searchTerm);
                        PrintJobs(searchResults);
                    }
         */

    }
}
