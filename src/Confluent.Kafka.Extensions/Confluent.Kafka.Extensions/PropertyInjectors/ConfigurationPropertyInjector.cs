using System.Collections.Generic;

namespace Confluent.Kafka.Extensions.PropertyInjectors
{
    public class ConfigurationPropertyInjector<TValue>
    {
        protected readonly string Key;

        public ConfigurationPropertyInjector(string key)
        {
            Key = key;
        }

        public virtual void Inject(Dictionary<string, object> config, TValue value)
        {
            config[Key] = value;
        }
    }
}