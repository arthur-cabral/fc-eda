using API.KafkaHandler.Consumers;

namespace API.ExternalAPIs
{
    public class WalletService : IWalletService
    {
        private readonly IKafkaConsumerBalances _consumerBalances;

        public WalletService(IKafkaConsumerBalances consumerBalances)
        {
            _consumerBalances = consumerBalances;
        }

        public Task<double> GetBalanceByAccountId(string account_id)
        {
            _consumerBalances.GetBalanceByAccountId();

            return null;
        }
    }
}
