namespace CRUDAPI.Models
{
    public class Campanha
    {
        public int CampanhaId { get; set; }

        public string NomeDaCampanha { get; set; }

        public string DataDeInicio { get; set; }

        public string DataDeTermino { get; set; }

        public string StatusDaCampanha { get; set; }
    }
}
