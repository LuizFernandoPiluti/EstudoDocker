

using EstudoDocker.Application.Interfaces;
using EstudoDocker.Application.Request;
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
                        var p = JsonSerializer.Deserialize<PessoaRequest>(msg);
                        if (p != null) 
                        {
                            switch (p.TipoOperacao)
                            {
                                case "Insert":
                                    await _pessoaService.AddAsync(p).ConfigureAwait(false);
                                    break;
                                case "Update":
                                    await _pessoaService.UpdateAsync(p).ConfigureAwait(false);
                                    break;
                                case "Delete":
                                    await _pessoaService.DeleteAsync(p.Id).ConfigureAwait(false);
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
