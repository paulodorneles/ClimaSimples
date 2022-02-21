namespace Clima.Application.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PrevisaoClima")]
    public partial class PrevisaoClimaModel
    {
        public int Id { get; set; }

        public int CidadeId { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataPrevisao { get; set; }

        [Required]
        [StringLength(15)]
        public string Clima { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TemperaturaMinima { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TemperaturaMaxima { get; set; }

        public virtual CidadeModel Cidade { get; set; }
    }
}
