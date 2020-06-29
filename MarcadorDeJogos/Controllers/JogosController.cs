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
    public class JogosController : Controller
    {
        private readonly JogosService _jogosService;
        private readonly TipoJogoService _tipoJogoService;

        public JogosController(JogosService jogosService, TipoJogoService tipoJogoService) {
            _jogosService = jogosService;
            _tipoJogoService = tipoJogoService;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _jogosService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create() 
        {
            var tipoJogo = await _tipoJogoService.FindAllAsync();
            JogosFormViewModel viewModel = new JogosFormViewModel { TipoJogo = tipoJogo };

            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int id) 
        {
            if (id == 0)
            {
                return NotFound();
            }

            var jogo = await _jogosService.FindByIdAsync(id);
            var tipoJogo = await _tipoJogoService.FindByIdAsync(jogo.TipoJogoId);
            var viewModel = new JogosFormViewModel { Jogos = jogo, TipoJogo = tipoJogo };
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var jogo = await _jogosService.FindByIdAsync(id);

            if (jogo != null)
            {
                await _jogosService.DeleteByIdAsync(id);
            }

            return RedirectToAction("Visualizar");
        }

        public async Task<IActionResult> Visualizar(string texto) {
            if (texto == null) {
                texto = "";
            }

            ViewData["texto"] = texto;

            IList<Jogos> retornoPesquisa;

            if (string.IsNullOrEmpty(texto))
            {
                retornoPesquisa = await _jogosService.FindAllAsync();
            }
            else
            {
                retornoPesquisa = await _jogosService.FindByNomeJogoAsync(texto);
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

        public async Task<IActionResult> Details(int? id) {
            if (id == null) {
                return NotFound();
            }

            var jogo = await _jogosService.FindByIdAsync(id);
            if (jogo == null) {
                return NotFound();
            }

            return View(jogo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Jogos jogos) {
            if (!ModelState.IsValid) {
                var tipoJogo = await _tipoJogoService.FindAllAsync();
                var viewModel = new JogosFormViewModel { Jogos = jogos, TipoJogo = tipoJogo };

                return View(viewModel);
            }

            await _jogosService.InsertAsync(jogos);
            return RedirectToAction(nameof(Index), "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Jogos jogos)
        {
            if (!ModelState.IsValid)
            {
                var tipoJogo = await _tipoJogoService.FindAllAsync();
                var viewModel = new JogosFormViewModel { Jogos = jogos, TipoJogo = tipoJogo };

                return View(viewModel);
            }

            await _jogosService.EditAsync(jogos);

            return RedirectToAction("Visualizar");
        }
    }
}