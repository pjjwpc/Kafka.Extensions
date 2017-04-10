using System;
using Confluent.Kafka.Serialization;

namespace Confluent.Kafka.Extensions
{
    public interface IOptionalConsumerConfiguration
    {
        IOptionalConsumerConfiguration DefaultTopicConfig(Action<IDefaultTopicConfig> topicConfig);

        IOptionalConsumerConfiguration KeyDeserializer<TKey>(IDeserializer<TKey> keyDeserializer);

        IOptionalConsumerConfiguration ValueDeserializer<TValue>(IDeserializer<TValue> valueDeserializer);

        IOptionalConsumerConfiguration EnableAutoCommit(bool enabled = true);

        IOptionalConsumerConfiguration AutoCommitInternval(int milliseconds);

        IOptionalConsumerConfiguration EnableAutoCommitStore(bool enabled = true);

        IOptionalConsumerConfiguration QueuedMinimumMessages(int minimum);

        IOptionalConsumerConfiguration QueuedMaxMessagesKilobytes(int maxKilobytes);

        IOptionalConsumerConfiguration FetchWaitMax(int milliseconds);

        IOptionalConsumerConfiguration FetchMessageMaxBytes(int bytes);

        IOptionalConsumerConfiguration FetchMinBytes(int bytes);

        IOptionalConsumerConfiguration FetchErrorBackoff(int milliseconds);

        IOptionalConsumerConfiguration OffsetStoreMethod(OffsetStoreMethod method);

        IOptionalConsumerConfiguration EnablePartitionEnd(bool enabled = true);

        IOptionalConsumerConfiguration CheckCRCS(bool check = false);
    }
}