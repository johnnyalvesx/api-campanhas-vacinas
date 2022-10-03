using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDAPI.Models
{
    [Table("tb_vacinas")]
    public class Vacina
    {
        [Column("pk_vacina_id")]
        public int VacinaId { get; set; }

        [Column("nome_da_vacina")]
        public string NomeDaVacina { get; set; }

        [Column("dica_da_vacina")]
        public string DicaDaVacina { get; set; }

        // Propriedades de navegação

        public List<Campanha> Campanhas { get; set; }
    }
}
