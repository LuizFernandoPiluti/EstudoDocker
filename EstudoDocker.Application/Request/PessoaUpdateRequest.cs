namespace EstudoDocker.Application.Request
{
    public class PessoaUpdateRequest
    {
        public Guid Id { get; set; }
        public string Nome { get;  set; } = string.Empty;
        public int Idade { get;  set; }
        public TipoInstrucaoEnum TipoOperacao { get; set; }

    }
}
