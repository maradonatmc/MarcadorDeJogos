using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MarcadorDeJogos.Models;
using MarcadorDeJogos.Models.ViewModels;
using MarcadorDeJogos.Services;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace MarcadorDeJogos.Controllers
{
    public class ConfigGeneralController : Controller
    {
        private readonly ConfigGeneralService _configGeneralService;

        public ConfigGeneralController(ConfigGeneralService configGeneralService) {
            _configGeneralService = configGeneralService;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _configGeneralService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create() 
        {
            ConfigGeneralFormViewModel viewModel = null;
            await Task.Run(() => {
                viewModel = new ConfigGeneralFormViewModel { };
            });

            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int id) 
        {
            if (id == 0)
            {
                return NotFound();
            }

            var configGeneral = await _configGeneralService.FindByIdAsync(id);
            var viewModel = new ConfigGeneralFormViewModel { ConfigGeneral = configGeneral };
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var configGeneral = await _configGeneralService.FindByIdAsync(id);

            if (configGeneral != null)
            {
                await _configGeneralService.DeleteByIdAsync(id);
            }

            return RedirectToAction("Visualizar");
        }

        public async Task<IActionResult> Visualizar(string texto) {
            if (texto == null) {
                texto = "";
            }

            ViewData["texto"] = texto;

            IList<ConfigGeneral> retornoPesquisa;

            if (string.IsNullOrEmpty(texto))
            {
                retornoPesquisa = await _configGeneralService.FindAllAsync();
            }
            else
            {
                return View();
            }

            return View(retornoPesquisa);
        }

        public IActionResult Search() {
            return View();
        }

        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var configGeneral = await _configGeneralService.FindByIdAsync(id);
            if (configGeneral == null) {
                return NotFound();
            }

            return View(configGeneral);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ConfigGeneral configGeneral) {
            if (!ModelState.IsValid) {
                var viewModel = new ConfigGeneralFormViewModel { ConfigGeneral = configGeneral };

                return View(viewModel);
            }

            await _configGeneralService.InsertAsync(configGeneral);
            return RedirectToAction(nameof(Index), "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ConfigGeneral configGeneral)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ConfigGeneralFormViewModel { ConfigGeneral = configGeneral };

                return View(viewModel);
            }

            await _configGeneralService.EditAsync(configGeneral);

            return RedirectToAction("Visualizar");
        }
    }
}