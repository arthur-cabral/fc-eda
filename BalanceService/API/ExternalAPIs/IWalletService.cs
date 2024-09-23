namespace API.ExternalAPIs
{
    public interface IWalletService
    {
        Task<double> GetBalanceByAccountId(string account_id);
    }
}
