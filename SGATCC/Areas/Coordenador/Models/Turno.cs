using System;
using System.Collections.Generic;

namespace SGATCC.Areas.Coordenador.Models
{
    public class Turno
    {
        public int TurnoId { get; set; }
        public string Descricao { get; set; }

        public List<Turma> Turmas { get; set; }
    }
}
