namespace EstudoDocker.Application.Request
{
    public class PessoaRequest
    {
        public string Nome { get;  set; } = string.Empty;
        public int Idade { get;  set; }
        public TipoInstrucaoEnum TipoOperacao { get; set; }

    }
}
