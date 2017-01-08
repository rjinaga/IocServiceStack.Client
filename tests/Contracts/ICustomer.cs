namespace Contracts
{
    public interface ICustomer
    {
        Customer GetCustomer(int i, string s);
        void Save();
    }

}
