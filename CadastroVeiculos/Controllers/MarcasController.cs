using AutoMapper;
using CadastroVeiculos.Domain.Entities;
using CadastroVeiculos.Domain.Services;
using CadastroVeiculos.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CadastroVeiculos.Controllers
{
    public class MarcasController : Controller
    {
        public readonly IMarcaService _marcaService;
        public readonly IMapper _mapper;

        public MarcasController(IMarcaService marcaService,
                                IMapper mapper)
        {
            _marcaService = marcaService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var marcasViewModel = _mapper.Map<ICollection<Marca>, ICollection<MarcaViewModel>>(_marcaService.GetAll());
            return View(marcasViewModel);
        }

        public ActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MarcaViewModel marca)
        {
            if (ModelState.IsValid)
            {
                var marcaDomain = _mapper.Map<MarcaViewModel, Marca>(marca);
                if (!MarcaExiste(marcaDomain))
                {
                    _marcaService.Create(marcaDomain);
                    return RedirectToAction("Index");
                }
            }
            return View(marca);
        }

        public ActionResult Edit(Guid id)
        {
            var marcaEntity = _marcaService.GetById(id);
            var marca = _mapper.Map<Marca, MarcaViewModel>(marcaEntity);
            return View(marca);
        }

        private bool MarcaExiste(Marca marca)
        {
            if (_marcaService.VerificarMarca(marca))
            {
                ModelState.AddModelError("Nome", "Nome já existe.");
                return true;
            }
            return false;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MarcaViewModel marca)
        {
            if (ModelState.IsValid)
            {
                var marcaDomain = _mapper.Map<MarcaViewModel, Marca>(marca);
                if (!MarcaExiste(marcaDomain))
                {
                    _marcaService.Update(marcaDomain);
                    return RedirectToAction("Index");
                }
            }
            return View(marca);
        }
    }
}
