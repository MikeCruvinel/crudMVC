// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace crud.DATA.Models
{
    public partial class Funcionario
    {
        [Required]
        [MaxLength(200)]
        [StringLength(200)]
        public string Nome { get; set; }
        [StringLength(50)]
        public string Cargo { get; set; }
        //[Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Salario { get; set; }
        [Column("Id_Empresa")]
        public int? IdEmpresa { get; set; }
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(IdEmpresa))]
        [InverseProperty(nameof(Empresa.Funcionario))]
        public virtual Empresa IdEmpresaNavigation { get; set; }
    }
}