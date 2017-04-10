namespace Confluent.Kafka.Extensions
{
    public interface IConsumerNamingConfiguration
    {
        IRequiredConfiguration WithGroupId(string groupId);

        IRequiredConfiguration WithClientId(string clientId);
    }
}