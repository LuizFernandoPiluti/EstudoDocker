namespace EstudoDocker.Application.Request
{
    public class PessoaRequest
    {
 
        // public Guid Id { get;  set; }
     
        public string Nome { get;  set; } = string.Empty;
        public int Idade { get;  set; }
        public string TipoOperacao { get; set; }

    }
}
