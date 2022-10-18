using Microsoft.EntityFrameworkCore;
using VacinasCampanhas.VacinasCampanhas.Domain.Entities;

namespace VacinasCampanhas.VacinasCampanhas.Domain.Entities
{
    public class Campanha
    {

        public int CampanhaId { get; set; }

        public string NomeDaCampanha { get; set; }

        public DateTime DataDeInicio { get; set; }

        public DateTime DataDeTermino { get; set; }

        public string StatusDaCampanha { get; set; }

        public int VacinaId { get; set; }

        public Vacina Vacina { get; set; }

    }
}
