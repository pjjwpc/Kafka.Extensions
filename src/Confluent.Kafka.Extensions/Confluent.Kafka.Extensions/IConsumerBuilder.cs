using System;
using System.Collections.Generic;
using System.Text;

namespace Confluent.Kafka.Extensions
{
    public interface IConsumerBuilder
    {
        Consumer Build();
    }
}
