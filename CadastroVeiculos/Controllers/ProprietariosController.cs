using AutoMapper;
using CadastroVeiculos.Domain.Entities;
using CadastroVeiculos.Domain.Services;
using CadastroVeiculos.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CadastroVeiculos.Controllers
{
    public class ProprietariosController : Controller
    {
        public readonly IProprietarioService _proprietarioService;
        public readonly IMapper _mapper;

        public ProprietariosController(IProprietarioService proprietarioService,
                                       IMapper mapper)
        {
            _proprietarioService = proprietarioService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var proprietarioViewModel = _mapper.Map<ICollection<Proprietario>, ICollection<ProprietarioViewModel>>(_proprietarioService.GetAll());
            return View(proprietarioViewModel);
        }

        public ActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProprietarioViewModel proprietario)
        {
            if (ModelState.IsValid)
            {
                var proprietarioDomain = _mapper.Map<ProprietarioViewModel, Proprietario>(proprietario);

                if (!DocumentoExiste(proprietarioDomain))
                {
                    _proprietarioService.Create(proprietarioDomain);
                    return RedirectToAction("Index");
                }
            }
            return View(proprietario);
        }

        private bool DocumentoExiste(Proprietario proprietario)
        {
            if (_proprietarioService.VerificarDocumento(proprietario))
            {
                ModelState.AddModelError("Documento", "Documento já existe.");
                return true;
            }
            return false;
        }

        public ActionResult Edit(Guid id)
        {
            var proprietarioEntity = _proprietarioService.GetById(id);
            var proprietario = _mapper.Map<Proprietario, ProprietarioViewModel>(proprietarioEntity);
            return View(proprietario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProprietarioViewModel proprietario)
        {
            if (ModelState.IsValid)
            {
                var proprietarioDomain = _mapper.Map<ProprietarioViewModel, Proprietario>(proprietario);
                if (!DocumentoExiste(proprietarioDomain))
                {
                    _proprietarioService.Update(proprietarioDomain);
                    return RedirectToAction("Index");
                }
            }
            return View(proprietario);
        }
    }
}
