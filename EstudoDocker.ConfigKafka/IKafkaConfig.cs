using Confluent.Kafka;

namespace EstudoDocker.ConfigKafka
{
    public interface IKafkaConfig
    {
        public string GroupId { get; set; }
        public string BootstrapServers { get; set; }
        public AutoOffsetReset AutoOffsetReset { get; set; }
        public string Topic { get; set; }
    }
}
