using System.Collections.Generic;

namespace Confluent.Kafka.Extensions
{
    public class DefaultTopicBuilder : IDefaultTopicConfig
    {
        private Dictionary<string, object> _config;

        public DefaultTopicBuilder(Dictionary<string, object> config)
        {
            _config = config;
        }

        IDefaultTopicConfig IDefaultTopicConfig.EnableAutoCommit(bool enabled)
        {
            throw new System.NotImplementedException();
        }

        IDefaultTopicConfig IDefaultTopicConfig.AutoCommitInternval(int milliseconds)
        {
            throw new System.NotImplementedException();
        }

        IDefaultTopicConfig IDefaultTopicConfig.AutoOffsetReset(AutoOffsetReset value)
        {
            throw new System.NotImplementedException();
        }

        IDefaultTopicConfig IDefaultTopicConfig.OffsetStorePath(string path)
        {
            throw new System.NotImplementedException();
        }

        IDefaultTopicConfig IDefaultTopicConfig.OffsetStoreSyncInternval(int milliseconds)
        {
            throw new System.NotImplementedException();
        }

        IDefaultTopicConfig IDefaultTopicConfig.OffsetStoreMethod(OffsetStoreMethod method)
        {
            throw new System.NotImplementedException();
        }

        IDefaultTopicConfig IDefaultTopicConfig.ConsumerCallBackMaxMessages(int maxMessages)
        {
            throw new System.NotImplementedException();
        }
    }
}