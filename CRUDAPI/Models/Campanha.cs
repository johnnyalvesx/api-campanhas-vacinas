using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDAPI.Models
{
    [Table("tb_campanhas")]
    public class Campanha
    {

        [Column("campanha_id")]
        public int CampanhaId { get; set; }

        [MaxLength(25, ErrorMessage = "Máximo de 25 caracteres.")]
        [Column("nome_da_campanha")]
        public string NomeDaCampanha { get; set; }

        [Column("data_de_inicio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de início")]
        public DateTime DataDeInicio { get; set; }

        [Column("data_de_termino")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de término")]
        public DateTime DataDeTermino { get; set; }

        [Column("status_da_campanha")]
        public string StatusDaCampanha { get; set; }

        // Propriedades de navegação

        public Vacina Vacinas { get; set; }
    }
}
