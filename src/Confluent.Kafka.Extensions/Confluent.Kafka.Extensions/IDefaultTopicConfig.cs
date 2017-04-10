namespace Confluent.Kafka.Extensions
{
    public interface IDefaultTopicConfig
    {
        IDefaultTopicConfig EnableAutoCommit(bool enabled = true);

        IDefaultTopicConfig AutoCommitInternval(int milliseconds);

        IDefaultTopicConfig AutoOffsetReset(AutoOffsetReset value);

        IDefaultTopicConfig OffsetStorePath(string path);

        IDefaultTopicConfig OffsetStoreSyncInternval(int milliseconds);

        IDefaultTopicConfig OffsetStoreMethod(OffsetStoreMethod method);

        IDefaultTopicConfig ConsumerCallBackMaxMessages(int maxMessages);
    }
}