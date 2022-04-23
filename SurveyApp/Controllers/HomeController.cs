using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SurveyApp.Data;
using SurveyApp.Models;

namespace SurveyApp.Controllers
{
    public class HomeController : Controller
    {
      

        public IActionResult Login(string Email, string Password)
        {
            personRepository.loginPerson = null;

            if (Email != null && Password != null)
            {
                Person person = new Person(Email, Password);
                personRepository.LoginAuthorization(person);
                if (personRepository.loginPerson == null)
                {

                    TempData["Login"] = "Wrong Email or Password";
                }
                else
                {
                    return RedirectToAction("Login", "MainPage", new { area = "MainPage" });
                }
            }

            return View();
        }

        public IActionResult Register(string Name, string Surname, string Email, string Password)
        {
            if (!(Name == null) && !(Surname == null) && !(Email == null) && !(Password == null))
            {
                personRepository.getAllEmailsFromDatabase();
                //Console.WriteLine(personRepository.allEmails[0]);
                if (personRepository.allEmails != null && !personRepository.allEmails.Contains(Email))
                {

                    Person person = new Person(Email, Password, Name, Surname);


                    personRepository.registerPerson(person);

                    return RedirectToAction("Login");
                }
                else if (personRepository.allEmails == null)
                {
                    Person person = new Person(Email, Password, Name, Surname);

                    personRepository.registerPerson(person);

                    return RedirectToAction("Login");

                }
                else
                {

                    if (!(Name == null) && !(Surname == null) && !(Email == null) && !(Password == null))
                    {
                        TempData["Email"] = "Email  has been already used";
                    }

                    return RedirectToAction("Register");
                }
            }

            return View();


        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");


        }





    }
}
