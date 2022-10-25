namespace VacinasCampanhas.Application.Models
{
    public class VacinaResponse
    {
        public VacinaResponse(int vacinaId, string nomeDaVacina, string dicaDaVacina)
        {
            VacinaId = vacinaId;
            NomeDaVacina = nomeDaVacina;
            DicaDaVacina = dicaDaVacina;
        }

        public int VacinaId { get; }

        public string NomeDaVacina { get; }

        public string DicaDaVacina { get; }
    }
}
