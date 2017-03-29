using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;

namespace Confluent.Kafka.Extensions
{
    public class ConsumerBuilder : IConsumerBuilder
    {
        public ConsumerBuilder() { }
        public ConsumerBuilder(bool subscribeOnBuild)
        {
            _subscribeOnBuild = subscribeOnBuild;
        }

        private Subject<Message> _onMessageSubject = new Subject<Message>();
        protected IObservable<Message> _onMessageObservable
        {
            get
            {
                return _onMessageSubject.AsObservable();
            }
        }

        private Dictionary<string, object> _config = new Dictionary<string, object>();
        private List<string> _brokerList = new List<string>();
        private string _topic;
        private TopicPartitionOffset _topicPartitionOffset;
        private bool _subscribeOnBuild = false;

        /// <summary>
        /// Adds an individual broker to the broker list
        /// </summary>
        /// <param name="broker"></param>
        /// <returns></returns>
        public ConsumerBuilder AddBroker(string broker)
        {
            if (string.IsNullOrEmpty(broker))
                throw new ArgumentNullException(nameof(broker));

            _brokerList.Add(broker);
            return this;
        }

        /// <summary>
        /// Adds multiple brokers to the broker list at once
        /// </summary>
        /// <param name="brokers"></param>
        /// <returns></returns>
        public ConsumerBuilder AddBrokers(params string[] brokers)
        {
            _brokerList.AddRange(brokers);
            return this;
        }

        /// <summary>
        /// Sets the Kafka group.id configuration parameter to the specified string
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public ConsumerBuilder WithGroupId(string groupId)
        {
            if (string.IsNullOrEmpty(groupId))
                throw new ArgumentNullException(nameof(groupId));

            _config[ConfigConstants.GroupId] = groupId;
            return this;
        }

        /// <summary>
        /// The topic that the consumer will subscriber to when subscriber is called.
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        public ConsumerBuilder ForTopic(string topic)
        {
            _topic = topic;
            return this;
        }

        /// <summary>
        /// Assigns a specific partition to the consumer, topic must be set first using ForTopic!
        /// </summary>
        /// <param name="partition"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public ConsumerBuilder AssignPartition(int partition, int offset)
        {
            if (string.IsNullOrEmpty(_topic))
                throw new InvalidOperationException("You must set the topic before assigning a partition, Set a topic using the ForToopic method");

            _topicPartitionOffset = new TopicPartitionOffset(_topic, partition, offset);

            return this;
        }

        /// <summary>
        /// Adds a System.Reactive observer to listen to messages and errors during consumption
        /// </summary>
        /// <param name="observer"></param>
        /// <returns></returns>
        public ConsumerBuilder AddObserver(IObserver<Message> observer)
        {
            _onMessageSubject.Subscribe(observer);

            return this;
        }


        public ConsumerBuilder SubscribeOnBuild()
        {
            _subscribeOnBuild = true;
            return this;
        }

        public Consumer Build()
        {
            Consumer consumer = null;

            try
            {
                if (_brokerList.Count == 0)
                    throw new InvalidOperationException($"One broker must be added to build a consumer. Use the {nameof(AddBroker)} method to add a broker!");

                _config[ConfigConstants.BootstrapServers] = String.Join(", ", _brokerList.ToArray());
                consumer = new Consumer(_config);

                if (_topicPartitionOffset != null)
                {
                    consumer.Assign(new List<TopicPartitionOffset>() { _topicPartitionOffset });
                }

                consumer.OnMessage += (sender, msg) => _onMessageSubject.OnNext(msg);
                consumer.OnError += (sender, error) => _onMessageSubject.OnError(new Exception(error.Reason));
                consumer.OnConsumeError += (sender, msg) => _onMessageSubject.OnError(new Exception($"There was an error consuming a message", GenerateConsumeErrorException(msg)));

                return consumer;
            }
            finally
            {
                if (_subscribeOnBuild)
                {
                    consumer.Subscribe(_topic);
                }
            }
        }

        private void Consumer_OnMessage(object sender, Message e)
        {
            throw new NotImplementedException();
        }

        private Exception GenerateConsumeErrorException(Message message)
        {
            return new Exception($"Topic: {message.Topic}, Partition: {message.Partition}, Offset: {message.Offset}, Length: {message.Value.Length}");
        }
    }
}
