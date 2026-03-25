
using AutoMapper;
using EstudoDocker.Application.Interfaces;
using EstudoDocker.Application.Request;
using EstudoDocker.Domain.Interfaces.Repository;
using EstudoDocker.Domain.Kafka;

namespace EstudoDocker.Application.Services
{
    public class KafkaService : IKafkaService
    {
        private readonly IKafkaRepository _kafkaRepository;
        private readonly IMapper _mapper;
        public KafkaService(IKafkaRepository kafkaRepository, IMapper mapper)
        {
            _kafkaRepository = kafkaRepository;
            _mapper = mapper;
        }
        public string ConsumerMsg()
        {
            var msg = _kafkaRepository.ConsumerMsg();
            return msg;
        }

        public async Task<bool> ProducerMsgAsync(PessoaRequest pessoaRequest)
        {
            var pessoa = _mapper.Map<PesssoaMensagem>(pessoaRequest);
            var status = await _kafkaRepository.ProducerMsgAsync(pessoa).ConfigureAwait(false);
            return status;
        }
    }
}
