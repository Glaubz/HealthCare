namespace Gigers.Domain.Entidades
{
    public class Endereco : Entity
    {
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
    }
}
