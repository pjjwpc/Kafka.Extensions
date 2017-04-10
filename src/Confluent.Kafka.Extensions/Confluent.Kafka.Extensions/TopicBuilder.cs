using System;
using System.Collections.Generic;
using System.Text;

namespace Confluent.Kafka.Extensions
{
    public class TopicBuilder
    {
        private readonly string _topicName;

        public TopicBuilder(string topicName)
        {
            _topicName = topicName;
        }


    }
}
