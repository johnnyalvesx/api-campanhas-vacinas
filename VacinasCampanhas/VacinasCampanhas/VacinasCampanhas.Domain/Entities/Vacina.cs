﻿namespace VacinasCampanhas.VacinasCampanhas.Domain.Entities
{
    public class Vacina
    {

        public int VacinaId { get; set; }

        public string? NomeDaVacina { get; set; }

        public string? DicaDaVacina { get; set; }

        public Campanha? Campanha { get; set; }
    }
}