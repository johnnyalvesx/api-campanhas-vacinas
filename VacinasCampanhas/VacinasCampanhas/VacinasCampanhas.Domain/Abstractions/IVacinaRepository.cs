﻿using VacinasCampanhas.VacinasCampanhas.Domain.Entities;

namespace VacinasCampanhas.VacinasCampanhas.Domain.Abstractions
{
    public interface IVacinaRepository
    {
        Task<IEnumerable<Vacina>> PegarVacinasAsync();
        Task<Vacina> PegarVacinaPorIdAsync(int id);
    }
}
