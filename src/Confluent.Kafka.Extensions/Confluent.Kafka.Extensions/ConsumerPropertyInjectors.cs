using System.Collections.Generic;
using Confluent.Kafka.Extensions.PropertyInjectors;

namespace Confluent.Kafka.Extensions
{
    public static class ConsumerPropertyInjectors
    {
        public static ConfigurationPropertyInjector<string> GroupId = new ConfigurationPropertyInjector<string>(ConfigConstants.GroupId);
        public static ConfigurationPropertyInjector<string> ClientId = new ConfigurationPropertyInjector<string>(ConfigConstants.ClientId);
        public static ConfigurationPropertyInjector<string> BootstrapServers = new BootstrapServersPropertyInjector(ConfigConstants.BootstrapServers);
        public static ConfigurationPropertyInjector<Dictionary<string, object>> DefaultTopicBuilder = new ConfigurationPropertyInjector<Dictionary<string, object>>(ConfigConstants.DefaultTopicConfigConfluentStyle);
        //TODO: The Rest
    }
}