
using EstudoDocker.Application.Request;

namespace EstudoDocker.Application.Interfaces
{
    public interface IKafkaService
    {
        Task<bool> ProducerMsgAsync(PessoaRequest pessoaRequest);
        Task<bool> ProducerMsgUpdateAsync(PessoaUpdateRequest pessoaRequest);
        string ConsumerMsg();
    }
}
