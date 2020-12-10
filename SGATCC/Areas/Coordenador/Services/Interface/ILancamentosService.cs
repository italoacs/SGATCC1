using SGATCC.Areas.Coordenador.Models;
using System.Collections.Generic;

namespace SGATCC.Areas.Coordenador.Services.Interface
{
    public interface ILancamentosService
    {
        IEnumerable<Disciplina> BuscarDisciplinas();
    }
}
