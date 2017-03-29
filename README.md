# Kafka.Extensions

The Kafka.Extensions library was built to serve as a fluent wrapper on top of the Confluent.Kafka library. It includes support for System.Reactive so that events can be piped to Observers in real time. This library is in its infancy. Nuget coming soon!

## Nuget
```
Install-Package Confluent.Kafka.Extensions
```

### Framework

* .NET Standard 1.3

# Examples
            
## Fully Fluent Builder
            
            var consumerBuilder = new ConsumerBuilder()
                    .AddBroker("kafka01.innovate.lan")
                    .AddBroker("kafka02.innovate.lan")
                    .AddBroker("kafka03.innovate.lan")
                    .ForTopic("Test")
                    .WithGroupId("Test-Group")
                    .AssignPartition(0, 0)
                    .AddObserver(new ExampleObserver())
                    .SubscribeOnBuild()
                .Build();

## Fully Fluent Builder w/ Convenience Options

            //Add all brokers conveniently in one calls
            var consumerBuilder2 = new ConsumerBuilder()
                    .AddBrokers("kafka01.innovate.lan", "kafka02.innovate.lan", "kafka03.innovate.lan")
                    .ForTopic("Test")
                    .WithGroupId("Test-Group")
                    .AssignPartition(0, 0)
                    .AddObserver(new ExampleObserver())
                    .SubscribeOnBuild()
                .Build();

## Fully Fluent Builder w/ Convenience Options
### Without assigning a partition

            //Don't need to assign a partition at all
            var consumerBuilder3 = new ConsumerBuilder()
                    .AddBrokers("kafka01.innovate.lan", "kafka02.innovate.lan", "kafka03.innovate.lan")
                    .ForTopic("Test")
                    .WithGroupId("Test-Group")
                    .AddObserver(new ExampleObserver())
                    .SubscribeOnBuild()
                .Build();
                
## Hybrid Fluent + Event Hooks

            var consumerBuilder4 = new ConsumerBuilder()
                    .AddBrokers("kafka01.innovate.lan", "kafka02.innovate.lan", "kafka03.innovate.lan")
                    .WithGroupId("Test-Group")
                    .AddObserver(new ExampleObserver())
                .Build();

            consumerBuilder4.OnMessage += (sender, msg) => { Console.WriteLine( msg.ToString() };
            consumerBuilder4.Subscribe("Test");
            
