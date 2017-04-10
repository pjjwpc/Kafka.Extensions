namespace Confluent.Kafka.Extensions
{
    public static class TopicConfigConstants
    {
        public const string RequestRequiredAcks = "request.required.acks";
        public const string Acks = "acks";
        public const string RequestTimeoutMs = "request.timeout.ms";
        public const string MessageTimeMs = "message.timeout.ms";
        public const string ProduceOffsetReport = "produce.offset.report";
        public const string Opaque = "opaque";
        public const string CompressionCodec = "compression.codec";
        public const string AutoCommitEnable = "auto.commit.enable";
        public const string EnableAutoCommit = "enable.auto.commit";
        public const string AutoCommitIntervalMs = "auto.commit.interval.ms";
        public const string AutoOffsetReset = "auto.offset.reset";
        public const string OffsetStorePath = "offset.store.path";
        public const string OffsetStoreSyncIntervalMs = "offset.store.sync.interval.ms";
        public const string OffsetStoreMethod = "offset.store.method";  
        public const string ConsumeCallbackMaxMessages = "consume.callback.max.messages";
    }
}