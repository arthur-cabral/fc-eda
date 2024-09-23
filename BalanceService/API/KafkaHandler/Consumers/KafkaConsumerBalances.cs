using Confluent.Kafka;

namespace API.KafkaHandler.Consumers
{
    public class KafkaConsumerBalances : IKafkaConsumerBalances
    {
        private string kafkaServer = "localhost:9092";
        private string topic = "balances";

        public void GetBalanceByAccountId()
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = kafkaServer,
                GroupId = topic,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            try
            {
                using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
                {
                    consumer.Subscribe(topic);

                    CancellationTokenSource cts = new CancellationTokenSource();
                    Console.CancelKeyPress += (_, e) =>
                    {
                        e.Cancel = true;
                        cts.Cancel();
                    };

                    try
                    {
                        while (true)
                        {
                            var cr = consumer.Consume(cts.Token);
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        consumer.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Exceção: {ex.GetType().FullName} | " +
                             $"Mensagem: {ex.Message}");
            }
        }
    }
}
