﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace crud.DATA.Models
{
    public partial class Empresa
    {
        public Empresa()
        {
            Funcionario = new HashSet<Funcionario>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        [StringLength(200)]
        public string Nome { get; set; }
        [Required]
        [StringLength(50)]
        public string Telefone { get; set; }
        [Required]
        [StringLength(100)]
        public string Endereco { get; set; }
        [Required]
        [StringLength(50)]
        public string Bairro { get; set; }
        [Required]
        [StringLength(50)]
        public string Cidade { get; set; }
        [Required]
        [StringLength(50)]
        public string Numero { get; set; }
        [StringLength(50)]
        public string Complemento { get; set; }
        [Column("CEP")]
        [StringLength(50)]
        public string Cep { get; set; }

        [InverseProperty("IdEmpresaNavigation")]
        public virtual ICollection<Funcionario> Funcionario { get; set; }
    }
}