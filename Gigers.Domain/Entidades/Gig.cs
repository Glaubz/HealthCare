using Gigers.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Gigers.Domain.Entidades
{
    public class Gig : Entity, IAggregateRoot
    {
        public string Titulo { get; set; }
        public IEnumerable<Giger> Giger { get; set; }
        public Endereco Endereco { get; set; }
        public DateTime DataHora { get; set; }
    }
}
