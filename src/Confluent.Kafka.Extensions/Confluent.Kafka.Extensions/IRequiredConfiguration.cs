namespace Confluent.Kafka.Extensions
{
    public interface IRequiredConfiguration
    {
        IRequiredConfiguration AddBootstrapServer(string bootstrapServer);
    }
}