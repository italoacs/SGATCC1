using SGATCC.Areas.Coordenador.Models;
using SGATCC.Areas.Coordenador.Repository.Interface;
using SGATCC.Areas.Coordenador.Services.Interface;
using System.Collections.Generic;

namespace SGATCC.Areas.Coordenador.Services
{
    public class LancamentosService : ILancamentosService
    {
        private readonly ILancamentosRepository _lancamentosRepository;

        public LancamentosService(ILancamentosRepository lancamentosRepository)
        {
            _lancamentosRepository = lancamentosRepository;
        }
        public IEnumerable<Disciplina> BuscarDisciplinas()
        {
            return _lancamentosRepository.BuscarDisciplinas();
        }
    }
}
