
using EstudoDocker.Domain.Kafka;

namespace EstudoDocker.Domain.Interfaces.Repository
{
    public interface IKafkaRepository
    {
        Task<bool> ProducerMsgAsync(PesssoaMensagem pesssoaMensagem);
        string ConsumerMsg();
    }
}
