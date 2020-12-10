using Microsoft.EntityFrameworkCore;
using SGATCC.Areas.Coordenador.Models;
using SGATCC.Areas.Coordenador.Repository.Interface;
using SGATCC.Contexto;
using System.Collections.Generic;
using System.Linq;

namespace SGATCC.Areas.Coordenador.Repository
{
    public class LancamentosRepository : ILancamentosRepository
    {
        private readonly ContextoSGATCC _contexto;

        public LancamentosRepository(ContextoSGATCC contexto)
        {
            _contexto = contexto;
        }
        public IEnumerable<Disciplina> BuscarDisciplinas()
        {
            return _contexto.Disciplinas.ToList();
        }
    }
}
