namespace VacinasCampanhas.VacinasCampanhas.Domain.Entities
{
    public class Campanha
    {

        public int Id { get; set; }

        public string NomeDaCampanha { get; set; }

        public DateTime DataDeInicio { get; set; }

        public DateTime DataDeTermino { get; set; }

        public string StatusDaCampanha { get; set; }

    }
}
