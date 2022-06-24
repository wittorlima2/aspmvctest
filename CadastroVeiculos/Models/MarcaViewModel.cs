﻿using CadastroVeiculos.Domain.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroVeiculos.Models
{
    public class MarcaViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres")]
        [MinLength(2, ErrorMessage = "Minimo 2 caracteres")]
        public string Nome { get; set; }
        public Status Status { get; set; }
        public string StatuDesc
        {
            get
            {
                switch (Status)
                {
                    case Status.Cancelado:
                        return "Cancelado";
                    case Status.Ativo:
                        return "Ativo";
                    default:
                        return "Status não indenficado"; 
                }
            }
        }
    }
}
