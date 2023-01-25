using Microsoft.AspNetCore.Mvc;
using lab12.Models;

namespace lab12.Controllers
{
    public class CalcServiceController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Manual()
        {
            if (Request.Method == "POST")
            {
                try
                {
                    var calc = new CalcModel
                    {
                        X = Int32.Parse(HttpContext.Request.Form["x"]),
                        operation = HttpContext.Request.Form["operation"],
                        Y = Int32.Parse(HttpContext.Request.Form["y"])
                    };

                    ViewBag.Result = calc.Calc();
                }
                catch
                {
                    ViewBag.Result = "Invalid input";
                }

                return View("Result");
            }
            return View("Window");
        }



        [HttpGet]
        [ActionName("ManualWithSeparateHandlers")]
        public IActionResult ManualParsingSeparateGet()
        {
            return View("Window");
        }
        [HttpPost]
        [ActionName("ManualWithSeparateHandlers")]
        public IActionResult ManualParsingSeparatePost()
        {
            try
            {
                var calc = new CalcModel
                {
                    X = Int32.Parse(HttpContext.Request.Form["x"]),
                    operation = HttpContext.Request.Form["operation"],
                    Y = Int32.Parse(HttpContext.Request.Form["y"])
                };

                ViewBag.Result = calc.Calc();
            }
            catch
            {
                ViewBag.Result = "Invalid input";
            }

            return View("Result");
        }



        [HttpGet]
        public IActionResult ModelBindingInParameters()
        {
            return View("Window");
        }
        [HttpPost]
        public IActionResult ModelBindingInParameters(int x, string operation, int y)
        {
            if (ModelState.IsValid)
            {
                var calc = new CalcModel
                {
                    X = x,
                    operation = operation,
                    Y = y
                };
                ViewBag.Result = calc.Calc();
            }
            else
            {
                ViewBag.Result = "Invalid input";
            }

            return View("Result");
        }



        [HttpGet]
        public IActionResult ModelBindingInSeparateModel()
        {
            return View("Window");
        }
        [HttpPost]
        public IActionResult ModelBindingInSeparateModel(CalcModel model)
        {
            ViewBag.Result = ModelState.IsValid
                ? model.Calc()
                : "Invalid input";

            return View("Result");
        }
    }
}
