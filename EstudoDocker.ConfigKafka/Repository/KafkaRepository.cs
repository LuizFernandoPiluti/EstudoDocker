

using Confluent.Kafka;
using EstudoDocker.ConfigKafka.ConfigKafka;
using EstudoDocker.Domain.Interfaces.Repository;
using EstudoDocker.Domain.Kafka;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace EstudoDocker.ConfigKafka.Repository
{
    public class KafkaRepository : IKafkaRepository
    {
        private readonly KafkaConfig _kafkaConfig;

        public KafkaRepository(KafkaConfig kafkaConfig)
        {
            _kafkaConfig = kafkaConfig;
            
        }
        public  string ConsumerMsg()
        {
            
            ConsumerConfig conf = new ConsumerConfig
            {
                GroupId = _kafkaConfig.GroupId,
                BootstrapServers = _kafkaConfig.BootstrapServers,
                AutoOffsetReset = _kafkaConfig.AutoOffsetReset,
                EnableAutoCommit = false,


            };
            using var consumerBuilder = new ConsumerBuilder<Ignore, string>(conf).Build();
            {
                consumerBuilder.Subscribe(_kafkaConfig.Topic);

                CancellationTokenSource cts = new CancellationTokenSource();

                try
                {
                    var consumer = consumerBuilder.Consume(cts.Token);
                    consumerBuilder.Commit();
                    return  consumer.Message.Value;
                }
                catch (System.Exception ex)
                {
                    consumerBuilder.Close();
                    throw new System.Exception(ex.Message);
                }
            }
        }

        public async Task<bool> ProducerMsgAsync(PesssoaMensagem pesssoaMensagem)
        {
            bool status = false;

            string message = JsonSerializer.Serialize(pesssoaMensagem);
            try
            {
                ProducerConfig config = new ProducerConfig { BootstrapServers = _kafkaConfig.BootstrapServers };
                using var p = new ProducerBuilder<Null, string>(config).Build();
                {
                    var msg = await p.ProduceAsync
                        (_kafkaConfig.Topic, new Message<Null, string> { Value = message });
                }

                status = true;

            }
            catch (System.Exception ex)
            {

                throw new System.Exception(ex.Message);
            }

            return status;
        }
    }
}
