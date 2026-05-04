
using EstudoDocker.Application.Request;

namespace EstudoDocker.Application.Validations
{
    public  static class ValidacaoPessoa
    {
    
        public static bool StatusValidacao { get; private set; }
        public static string MensagemValidacao { get; private set; } = string.Empty;
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
                MensagemValidacao += string.Concat(MensagemValidacao,"/","O nome é inválido.");
            }
            if (!validarIdade)
            {
                MensagemValidacao += string.Concat(MensagemValidacao, "/", "Idade minima para cadastro é 18 anos.");
            }
        }
    }
}
