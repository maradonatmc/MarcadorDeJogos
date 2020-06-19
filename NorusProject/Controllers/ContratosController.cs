using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NorusProject.Models;
using NorusProject.Models.ViewModels;
using NorusProject.Services;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace NorusProject.Controllers
{
    public class ContratosController : Controller
    {
        private readonly ContratosService _contratosService;
        private readonly ClientesService _clientesService;

        public ContratosController(ContratosService contratosService, ClientesService clientesService) {
            _contratosService = contratosService;
            _clientesService = clientesService;
        }
        public async Task<IActionResult> Index()
        {
            var list = await _contratosService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create() 
        {
            var clientes = await _clientesService.FindAllAsync();
            var viewModel = new ContratosFormViewModel { Clientes = clientes };
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int? id) 
        {
            if (id == null)
            {
                return NotFound();
            }

            var contrato = await _contratosService.FindByIdAsync(id);
            var clientes = await _clientesService.FindByIdAsync(contrato.ClientesId);
            var viewModel = new ContratosFormViewModel { Contratos = contrato, Clientes = clientes };
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contrato = await _contratosService.FindByIdAsync(id);

            if (contrato != null)
            {
                await _contratosService.DeleteByIdAsync(id);
            }

            return RedirectToAction("Visualizar");
        }

        public async Task<IActionResult> Visualizar(string texto) {
            if (texto == null) {
                texto = "";
            }

            ViewData["texto"] = texto;

            IList<Contratos> retornoPesquisa;

            if (string.IsNullOrEmpty(texto))
            {
                retornoPesquisa = await _contratosService.FindAllAsync();
            }
            else
            {
                retornoPesquisa = await _contratosService.FindByAll(texto);
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

            var contrato = await _contratosService.FindByIdAsync(id);
            if (contrato == null) {
                return NotFound();
            }

            return View(contrato);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Contratos contratos, IFormFile file) {
            if (!ModelState.IsValid) {
                var clientes = await _clientesService.FindAllAsync();
                var viewModel = new ContratosFormViewModel { Contratos = contratos, Clientes = clientes };

                return View(viewModel);
            }

            string caminho = "";

            if (file != null && file.Length > 0)
            {
                caminho = Path.GetTempFileName() + file.FileName;

                using (var stream = new FileStream(caminho, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            contratos.PathArquivo = System.Text.ASCIIEncoding.Default.GetBytes(caminho);

            await _contratosService.InsertAsync(contratos);
            return RedirectToAction(nameof(Index), "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Contratos contratos)
        {
            if (!ModelState.IsValid)
            {
                var clientes = await _clientesService.FindAllAsync();
                var viewModel = new ContratosFormViewModel { Contratos = contratos, Clientes = clientes };

                return View(viewModel);
            }

            var contratoAlterado = await _contratosService.FindByNumeroContratoAsync(contratos.NumeroContrato);
            contratoAlterado = _contratosService.UpdateRegistroAtual(contratos, contratoAlterado);

            await _contratosService.EditAsync(contratoAlterado);

            return RedirectToAction("Visualizar");
        }
    }
}