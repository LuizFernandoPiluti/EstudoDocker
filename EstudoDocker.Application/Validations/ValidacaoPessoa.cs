
using EstudoDocker.Application.Request;

namespace EstudoDocker.Application.Validations
{
    public  static class ValidacaoPessoa
    {
    
        public static bool StatusValidacao { get; private set; }
        public static IList<string> MensagemValidacao { get; } = new List<string>();
        private static bool ValidarIdade(int idade)
        {
            return idade >= 18;

        }

        private static bool ValidarNome(string nome)
        { 
            return nome.Length > 2;
        }

        public static void ValidarPessoa(PessoaRequest pessoaRequest)
        {
            StatusValidacao = false;
            bool validarIdade = ValidarIdade(pessoaRequest.Idade);
            bool validarNome = ValidarNome(pessoaRequest.Nome);

            if (validarIdade && validarNome)
            {
                StatusValidacao = true;
            }

            if (!validarNome)
            {
                MensagemValidacao.Add("O nome é inválido.");
            }
            if (!validarIdade)
            {
                MensagemValidacao.Add("Idade minima para cadastro é 18 anos.");
            }
        }
    }
}
