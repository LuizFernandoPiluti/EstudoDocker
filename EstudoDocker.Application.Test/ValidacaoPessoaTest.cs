
using EstudoDocker.Application.Request;
using EstudoDocker.Application.Validations;

namespace EstudoDocker.Application.Test
{
    public class ValidacaoPessoaTest
    {
   
        [Fact(DisplayName = "Teste sucesso para validar os dados de pessoa")]
        public  void ValidarPessoaOK()
        {

            // Arrange
            PessoaRequest pessoaRequest = new PessoaRequest
            {
                Nome = "Teste OK",
                Idade = 20
            };
            // Act
            ValidacaoPessoa.ValidarPessoa(pessoaRequest);

            //Assert
            Assert.True(ValidacaoPessoa.StatusValidacao);
        }
        [Fact(DisplayName = "Teste erro para validar os dados de pessoa nome invalido")]
        public void ValidarPessoaNaoOKNome()
        {

            // Arrange
            PessoaRequest pessoaRequest = new PessoaRequest
            {
                Nome = "Te",
                Idade = 20
            };
            // Act
            ValidacaoPessoa.ValidarPessoa(pessoaRequest);

            //Assert
            Assert.False(ValidacaoPessoa.StatusValidacao);
        }
        [Fact(DisplayName = "Teste erro para validar os dados de pessoa idade invalida")]
        public void ValidarPessoaNaoOKIdade()
        {

            // Arrange
            PessoaRequest pessoaRequest = new PessoaRequest
            {
                Nome = "Teste nao OK",
                Idade = 17
            };
            // Act
            ValidacaoPessoa.ValidarPessoa(pessoaRequest);

            //Assert
            Assert.False(ValidacaoPessoa.StatusValidacao);
        }

    }
}
