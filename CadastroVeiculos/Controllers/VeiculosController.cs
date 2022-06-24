using AutoMapper;
using CadastroVeiculos.Domain.Entities;
using CadastroVeiculos.Domain.Services;
using CadastroVeiculos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace CadastroVeiculos.Controllers
{
    public class VeiculosController : Controller
    {
        private readonly IVeiculoService _veiculoService;
        private readonly IMarcaService _marcaService;
        private readonly IProprietarioService _proprietarioService;
        private readonly IMapper _mapper;

        public VeiculosController(IVeiculoService veiculoService,
                                  IMarcaService marcaService,
                                  IProprietarioService proprietarioService,
                                  IMapper mapper)
        {
            _veiculoService = veiculoService;
            _marcaService = marcaService;
            _proprietarioService = proprietarioService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            LoadMarcas();
            LoadProprietarios();
            var veiculosViewModel = _mapper.Map<ICollection<Veiculo>, ICollection<VeiculoViewModel>>(_veiculoService.GetAll());
            return View(veiculosViewModel);
        }

        private void LoadMarcas() => ViewBag.MarcaId = new SelectList(_marcaService.GetAllActive(), "Id", "Nome");
        private void LoadProprietarios() => ViewBag.ProprietarioId = new SelectList(_proprietarioService.GetAllActive(), "Id", "Nome");

        public ActionResult Create()
        {
            LoadMarcas();
            LoadProprietarios();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VeiculoViewModel veiculo)
        {
            if (ModelState.IsValid)
            {
                var veiculoDomain = _mapper.Map<VeiculoViewModel, Veiculo>(veiculo);
                if (!RENAVAMExiste(veiculoDomain))
                {
                    _veiculoService.Create(veiculoDomain);
                    return RedirectToAction("Index");
                }
            }
            LoadMarcas();
            LoadProprietarios();
            return View(veiculo);
        }

        public ActionResult Edit(Guid id)
        {
            LoadMarcas();
            LoadProprietarios();
            var veiculoEntity = _veiculoService.GetById(id);
            var veiculo = _mapper.Map<Veiculo, VeiculoViewModel>(veiculoEntity);
            return View(veiculo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VeiculoViewModel veiculo)
        {
            if (ModelState.IsValid)
            {
                var veiculoDomain = _mapper.Map<VeiculoViewModel, Veiculo>(veiculo);
                if (Validate(veiculoDomain))
                {
                    _veiculoService.Update(veiculoDomain);
                    return RedirectToAction("Index");
                }
            }
            LoadMarcas();
            LoadProprietarios();
            return View(veiculo);
        }

        private bool Validate(Veiculo veiculo)
        {
            if (RENAVAMExiste(veiculo))
                return false;
            if (ValidateStatus(veiculo))
                return false;

            return true;
        }

        private bool ValidateStatus(Veiculo veiculo)
        {
            if (!_veiculoService.VerificarStatus(veiculo))
            {
                ModelState.AddModelError("Status", "Status inválido");
                return true;
            }
            return false;
        }

        private bool RENAVAMExiste(Veiculo veiculo)
        {
            if (_veiculoService.VerificarRENAVAM(veiculo))
            {
                ModelState.AddModelError("RENAVAM", "RENAVAM já existe.");
                return true;
            }
            return false;
        }
    }
}
