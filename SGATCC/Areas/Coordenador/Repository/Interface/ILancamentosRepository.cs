using SGATCC.Areas.Coordenador.Models;
using System.Collections.Generic;

namespace SGATCC.Areas.Coordenador.Repository.Interface
{
    public interface ILancamentosRepository
    {
        IEnumerable<Disciplina> BuscarDisciplinas();
    }
}
