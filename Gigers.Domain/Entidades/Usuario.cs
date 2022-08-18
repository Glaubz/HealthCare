using HealthCare.Domain.Interfaces;

namespace HealthCare.Domain.Entidades
{
    public class Usuario : Entity, IAggregateRoot
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public Endereco Endereco { get; set; }
    }
}
