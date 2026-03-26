

using EstudoDocker.Application.Interfaces;
using EstudoDocker.Application.Request;
using EstudoDocker.Domain.Kafka;
using Microsoft.Extensions.Hosting;
using System.Text.Json;

namespace EstudoDocker.App
{
    public class Worker : IHostedService
    {
        private readonly IKafkaService _kafkaService;
        private readonly IPessoaService _pessoaService;
        public Worker(IKafkaService kafkaService, IPessoaService pessoaService)
        {
            _kafkaService = kafkaService;
            _pessoaService = pessoaService;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                while (true)
                {
                    var msg = _kafkaService.ConsumerMsg();
                    if (!String.IsNullOrEmpty(msg))
                    {
                        var pesssoaMensagem = JsonSerializer.Deserialize<PesssoaMensagem>(msg);
                        if (pesssoaMensagem != null) 
                        {
                            TipoInstrucaoEnum tipoOperacao;
                            Enum.TryParse<TipoInstrucaoEnum>(pesssoaMensagem.TipoOperacao, true, out tipoOperacao);
                            switch (tipoOperacao)
                            {
                                case TipoInstrucaoEnum.Insert:
                                    var pessoaRequest = new PessoaRequest
                                    {   
                                        Nome = pesssoaMensagem.Nome,
                                        Idade = pesssoaMensagem.Idade
                                    };
                                    await _pessoaService.AddAsync(pessoaRequest).ConfigureAwait(false);
                                    break;
                                case TipoInstrucaoEnum.Update:
                                    var pessoaUpdateRequest = new PessoaUpdateRequest
                                    {
                                        Id = pesssoaMensagem.Id,
                                        Nome = pesssoaMensagem.Nome,
                                        Idade = pesssoaMensagem.Idade
                                    };
                                    await _pessoaService.UpdateAsync(pessoaUpdateRequest).ConfigureAwait(false);
                                    break;
                                case TipoInstrucaoEnum.Delete:
                                    // await _pessoaService.DeleteAsync(p.Id).ConfigureAwait(false);
                                    break;
                            }
                        }
                       

                    }

                }

            }
            catch (Exception)
            {

                throw;
            }
       
            Console.WriteLine("Starting...");
           
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Stopping...");
            return Task.CompletedTask;
        }
    }
}
