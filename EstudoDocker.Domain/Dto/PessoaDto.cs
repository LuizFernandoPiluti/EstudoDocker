namespace EstudoDocker.Domain.Dto
{
    public class PesssoaDto
    {
        public PesssoaDto(Guid id, string nome, int idade)
        {
            Id = id;
            Nome = nome;
            Idade = idade;
        }
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public int Idade { get; private set; }

        public void SetId(Guid id)
        {
            Id = id;
        }
        public void SetNome(string nome)
        {
            Nome = nome;
        }
        public void SetIdade(int idade)
        {
            Idade = idade;
        }

    }
}
