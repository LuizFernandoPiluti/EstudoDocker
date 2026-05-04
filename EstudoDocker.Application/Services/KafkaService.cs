
using AutoMapper;
using EstudoDocker.Application.Interfaces;
using EstudoDocker.Application.Request;
using EstudoDocker.Application.Validations;
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
            ValidacaoPessoa.ValidarPessoa(pessoaRequest);

            if (!ValidacaoPessoa.StatusValidacao)
            {
                if (!string.IsNullOrEmpty(ValidacaoPessoa.MensagemValidacao))
                {

                    throw new Exception(ValidacaoPessoa.MensagemValidacao);
                }
            }


            var pessoa = new PesssoaMensagem {
                Id = Guid.NewGuid(),
                Nome = pessoaRequest.Nome,
                Idade = pessoaRequest.Idade,
                TipoOperacao = pessoaRequest.TipoOperacao.ToString(),
            };
            var status = await _kafkaRepository.ProducerMsgAsync(pessoa).ConfigureAwait(false);
            return status;
        }
        public async Task<bool> ProducerMsgUpdateAsync(PessoaUpdateRequest pessoaRequest)
        {
            var pessoa = new PesssoaMensagem
            {
                Id = pessoaRequest.Id,
                Nome = pessoaRequest.Nome,
                Idade = pessoaRequest.Idade,
                TipoOperacao = pessoaRequest.TipoOperacao.ToString(),
            };
            var status = await _kafkaRepository.ProducerMsgAsync(pessoa).ConfigureAwait(false);
            return status;
        }
    }
}
