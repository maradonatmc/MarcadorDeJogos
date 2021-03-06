﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MarcadorDeJogos.Models;

namespace MarcadorDeJogos.Controllers {
    public class HomeController: Controller {
        public IActionResult Index() {
            return View();
        }

        public IActionResult Privacy() {
            ViewData["email"] = "renatoramos89@gmail.com";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
