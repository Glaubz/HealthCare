using Gigers.Domain.Interfaces;

namespace Gigers.Domain.Entidades
{
    public class Giger : Entity, IAggregateRoot
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public Endereco Endereco { get; set; }
    }
}
