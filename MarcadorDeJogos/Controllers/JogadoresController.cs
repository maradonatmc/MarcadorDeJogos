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
    public class JogadoresController : Controller
    {
        private readonly JogadoresService _jogadoresService;

        public JogadoresController(JogadoresService jogadoresService) {
            _jogadoresService = jogadoresService;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _jogadoresService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create() 
        {
            JogadoresFormViewModel viewModel = null;

            await Task.Run(() => {
                viewModel = new JogadoresFormViewModel();
            });

            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int id) 
        {
            if (id == 0)
            {
                return NotFound();
            }

            var jogador = await _jogadoresService.FindByIdAsync(id);
            var viewModel = new JogadoresFormViewModel { Jogadores = jogador };
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var jogador = await _jogadoresService.FindByIdAsync(id);

            if (jogador != null)
            {
                await _jogadoresService.DeleteByIdAsync(id);
            }

            return RedirectToAction("Visualizar");
        }

        public async Task<IActionResult> Visualizar(string texto) {
            if (texto == null) {
                texto = "";
            }

            ViewData["texto"] = texto;

            IList<Jogadores> retornoPesquisa;

            if (string.IsNullOrEmpty(texto))
            {
                retornoPesquisa = await _jogadoresService.FindAllAsync();
            }
            else
            {
                retornoPesquisa = await _jogadoresService.FindByNomeAsync(texto);
            }

            if (retornoPesquisa == null)
            {
                return View();
            }

            return View(retornoPesquisa);
        }

        public IActionResult Search() {
            return View();
        }

        public async Task<IActionResult> Details(int id) {
            if (id == 0) {
                return NotFound();
            }

            var jogador = await _jogadoresService.FindByIdAsync(id);
            if (jogador == null) {
                return NotFound();
            }

            return View(jogador);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Jogadores jogadores) {
            if (!ModelState.IsValid) {
                var viewModel = new JogadoresFormViewModel { Jogadores = jogadores };

                return View(viewModel);
            }

            await _jogadoresService.InsertAsync(jogadores);
            return RedirectToAction(nameof(Index), "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Jogadores jogadores)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new JogadoresFormViewModel { Jogadores = jogadores };

                return View(viewModel);
            }

            await _jogadoresService.EditAsync(jogadores);

            return RedirectToAction("Visualizar");
        }
    }
}