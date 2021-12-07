using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RandomPasscode.Models;
using System;
using System.Text;

namespace RandomPasscode.Controllers     //be sure to use your own project's namespace!
{
    public class HomeController : Controller   //remember inheritance??
    {
        //for each route this controller is to handle:
        [HttpGet]       //type of request
        [Route("")]     //associated route string (exclude the leading /)
        public ViewResult Index()
        {

            if(HttpContext.Session.GetInt32("Count") == null)
            {
                HttpContext.Session.SetInt32("Count", 1);
            }
            int? count = HttpContext.Session.GetInt32("Count");
            
            ViewBag.Count = count;
            
            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var charsarr = new char[14];
            var random = new Random();

            for (int i = 0; i < charsarr.Length; i++)
            {
                charsarr[i] = characters[random.Next(characters.Length)];
            }

            var resultString = new String(charsarr);
            
            ViewBag.Passcode = resultString;

            
            return View();
        }
        
        [HttpGet]       //type of request
        [Route("/generate")]     //associated route string (exclude the leading /)
        public RedirectToActionResult Generate()
        {
            int? count = HttpContext.Session.GetInt32("Count");
            count++;
            HttpContext.Session.SetInt32("Count", (int) count);
            
            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var charsarr = new char[14];
            var random = new Random();

            for (int i = 0; i < charsarr.Length; i++)
            {
                charsarr[i] = characters[random.Next(characters.Length)];
            }

            var resultString = new String(charsarr);
            
            ViewBag.Passcode = resultString;
            
            return RedirectToAction("index");
        }
    }
}