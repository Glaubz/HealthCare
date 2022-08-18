using HealthCare.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace HealthCare.Domain.Entidades
{
    public class Academia : Entity, IAggregateRoot
    {
        public string Nome { get; set; }
        public IEnumerable<Usuario> Usuario { get; set; }
        public Endereco Endereco { get; set; }
        public DateTime DataHora { get; set; }
    }
}
