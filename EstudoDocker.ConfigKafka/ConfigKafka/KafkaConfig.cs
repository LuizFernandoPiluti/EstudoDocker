using Confluent.Kafka;

namespace EstudoDocker.ConfigKafka.ConfigKafka
{
    public class KafkaConfig
    {
        public string GroupId { get; set; }
        public string BootstrapServers { get; set; }
        public AutoOffsetReset AutoOffsetReset { get; set; }
        public string Topic { get; set; }

        public KafkaConfig()
        {
            GroupId = "estudo-docker-group";
            // BootstrapServers = "127.0.0.1:9091";
            BootstrapServers = "kafka1:19091";
            AutoOffsetReset = AutoOffsetReset.Earliest;
            Topic = "Estudo-kafka";
        }

        public ConsumerConfig GetConfig()
        {

            var conf = new ConsumerConfig
            {
                GroupId = GroupId,
                BootstrapServers = BootstrapServers,
                AutoOffsetReset = AutoOffsetReset
            };

            return conf;
        }
    }
    
}
