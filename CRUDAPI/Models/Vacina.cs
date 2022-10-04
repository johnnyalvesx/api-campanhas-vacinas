using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDAPI.Models
{
    [Table("tb_vacinas")]
    public class Vacina
    {
        [Column("vacina_id")]
        public int VacinaId { get; set; }

        [Column("nome_da_vacina")]
        public string NomeDaVacina { get; set; }

        [MaxLength(255, ErrorMessage = "Máximo de 255 caracteres.")]
        [Column("dica_da_vacina")]
        public string DicaDaVacina { get; set; }

        // Propriedades de navegação

        // public ICollection<Campanha> Campanhas { get; set; }

        // public int CampanhaId { get; set; }

        public Campanha Campanhas { get; set; }
    }
}
