            ```
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
            ```
            ```
            //OR!
            //Add all brokers conveniently in one calls
            var consumerBuilder2 = new ConsumerBuilder()
                    .AddBrokers("kafka01.innovate.lan", "kafka02.innovate.lan", "kafka03.innovate.lan")
                    .ForTopic("Test")
                    .WithGroupId("Test-Group")
                    .AssignPartition(0, 0)
                    .AddObserver(new ExampleObserver())
                    .SubscribeOnBuild()
                .Build();
            ```
            ```
            //OR!
            //Don't need to assign a partition at all
            var consumerBuilder3 = new ConsumerBuilder()
                    .AddBrokers("kafka01.innovate.lan", "kafka02.innovate.lan", "kafka03.innovate.lan")
                    .ForTopic("Test")
                    .WithGroupId("Test-Group")
                    .AddObserver(new ExampleObserver())
                    .SubscribeOnBuild()
                .Build();
            ```
            ```
            //OR!
            //Hybrid
            var consumerBuilder4 = new ConsumerBuilder()
                    .AddBrokers("kafka01.innovate.lan", "kafka02.innovate.lan", "kafka03.innovate.lan")
                    .WithGroupId("Test-Group")
                    .AddObserver(new ExampleObserver())
                .Build();

            consumerBuilder4.OnMessage += (sender, msg) => { Console.WriteLine( msg.ToString() };
            consumerBuilder4.Subscribe("Test");
            ```
