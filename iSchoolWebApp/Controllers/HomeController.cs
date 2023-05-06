using iSchoolWebApp.Models;
using iSchoolWebApp.Utils;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Dynamic;

namespace iSchoolWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            DataRetrieval dataRetrieval = new DataRetrieval();
            var loadedNews = await dataRetrieval.GetData("news/");
            var jsonResult = JsonConvert.DeserializeObject<OlderRootModel>(loadedNews);
            return View(jsonResult);
        }

        public async Task<IActionResult> About()
        {      
            //first, I need to go get the data
            DataRetrieval dataRetrieval = new DataRetrieval();
            //go and load the data
            var loadedAbout = await dataRetrieval.GetData("about/");
            //issue is that loadedAbout is a string...
            //then I want to load the data into the model
            //another issue is that Visual Studio does NOT have a good JSON converter
            //Newtonsoft.Json to the rescue!
            //install newtonsoft in the NuGet packages...
            var jsonResult = JsonConvert.DeserializeObject<AboutRootModel>(loadedAbout);
            //add the page Title
            jsonResult.pageTitle = "My new HTML title for about";

            return View(jsonResult);
        }

        public async Task<IActionResult> Minors()
        {
            //load the data..
            DataRetrieval dataRetrieval = new DataRetrieval();
            //tell the instance to go get the data...
            var loadedMinors = await dataRetrieval.GetData("minors/");
            //cast it to json and the object we want
            var minorResult = JsonConvert.DeserializeObject<MinorsRootModel>(loadedMinors);

            //second get
            var loadedCourse = await dataRetrieval.GetData("course/");
            var courseResult = JsonConvert.DeserializeObject<List<CourseRootModel>>(loadedCourse);
          

            //using System.dynamic
            dynamic expando = new ExpandoObject();
            var comboModel = expando as IDictionary<string, object>;

            comboModel.Add("Minors", minorResult);
            comboModel.Add("Course", courseResult);

            return View(comboModel);
        }

        public async Task<IActionResult> Degrees()
        {
            DataRetrieval dataRetrieval = new DataRetrieval();
            var loadedDegrees = await dataRetrieval.GetData("degrees/");
            var jsonResult = JsonConvert.DeserializeObject<DegreesRootModel>(loadedDegrees);
            return View(jsonResult);
        }

        public async Task<IActionResult> Employment()
        {
            DataRetrieval dataRetrieval = new DataRetrieval();
            var loadedEmployment = await dataRetrieval.GetData("employment/");
            var jsonResult = JsonConvert.DeserializeObject<EmploymentRootModel>(loadedEmployment);
            return View(jsonResult);
        }

        public async Task<IActionResult> People()
        {
            DataRetrieval dataRetrieval = new DataRetrieval();
            var loadedPeople = await dataRetrieval.GetData("people/");
            var jsonResult = JsonConvert.DeserializeObject<PeopleRootModel>(loadedPeople);
            return View(jsonResult);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}