using BasicEcommerce_BackEnd.Models;
using BasicEcommerce_BackEnd.Util.Request;

namespace BasicEcommerce_BackEnd.Contracts
{
    public interface IClientService
    {
        ICollection<Client> GetAll();
        Client GetById(string idNumber);
        Client Create(ClientRequest clientRequest);
        Client Update(ClientRequest clientRequest);
        void Delete(string idNumber);
    }
}
