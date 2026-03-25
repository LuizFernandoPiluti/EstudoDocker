namespace EstudoDocker.Domain.Kafka
{
    public class PesssoaMensagem
    {
    
        public Guid Id { get;  set; }
        public string Nome { get;  set; } = string.Empty;
        public int Idade { get;  set; }
        public string TipoOperacao { get; set; }


    }
}
