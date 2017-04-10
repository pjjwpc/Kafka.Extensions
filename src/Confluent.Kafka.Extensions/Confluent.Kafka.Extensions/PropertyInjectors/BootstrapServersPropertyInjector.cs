using System.Collections.Generic;

namespace Confluent.Kafka.Extensions.PropertyInjectors
{
    public class BootstrapServersPropertyInjector 
        : ConfigurationPropertyInjector<string>
    {
        public BootstrapServersPropertyInjector(string key) 
            : base(key)
        {
        }

        public override void Inject(Dictionary<string, object> config, string value)
        {
            if (config.ContainsKey(Key))
            {
                config[Key] = $"{config[Key]},{value}";
            }
            else
            {
                config[Key] = value;
            }
        }
    }

}
