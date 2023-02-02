namespace VacinasCampanhas.Application.Models.Campanha
{
    public class CreateCampanhaDTO
    {
        public string NomeDaCampanha { get; set; }

        public DateTime DataDeInicio { get; set; }

        public DateTime DataDeTermino { get; set; }

        public string StatusDaCampanha { get; set; }

        public int VacinaId { get; set; }

    }
}
