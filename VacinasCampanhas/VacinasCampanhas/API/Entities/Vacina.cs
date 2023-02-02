using Newtonsoft.Json;

namespace VacinasCampanhas.VacinasCampanhas.Domain.Entities
{
    public class Vacina
    {

        public int VacinaId { get; set; }

        public string NomeDaVacina { get; set; }

        public string? DicaDaVacina { get; set; }

        [JsonIgnore]
        public virtual Campanha Campanha { get; set; }

    }
} 
