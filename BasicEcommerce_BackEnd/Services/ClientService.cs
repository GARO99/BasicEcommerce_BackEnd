using BasicEcommerce_BackEnd.Contracts;
using BasicEcommerce_BackEnd.Models;
using BasicEcommerce_BackEnd.Util.Exceptions;
using BasicEcommerce_BackEnd.Util.Request;

namespace BasicEcommerce_BackEnd.Services
{
    public class ClientService : IClientService
    {
        private readonly BasicEcommerceContext DbContext;

        public ClientService(BasicEcommerceContext dbContex)
        {
            DbContext = dbContex;
        }

        public Client Create(ClientRequest clientRequest)
        {
            if (this.DbContext.Clients.FirstOrDefault(c => c.IdNumberPerson == clientRequest.IdNumber) != null)
            {
                throw new ConflictException("Client allready exist");
            }
            Person? person = this.DbContext.People.FirstOrDefault(c => c.IdNumber == clientRequest.IdNumber);
            if (person == null)
            {
                person = new()
                {
                    IdNumber = clientRequest.IdNumber,
                    FirstName = clientRequest.FirstName,
                    LastName = clientRequest.LastName
                };
                this.DbContext.People.Add(person);
            }
            Client client = new()
            {
                IdNumberPerson = clientRequest.IdNumber,
                PhoneNumbre = clientRequest.PhoneNumbre,
            };
            this.DbContext.Clients.Add(client);
            this.DbContext.SaveChanges();

            return this.DbContext.Clients.First(c => c.Idclient == this.DbContext.Clients.Max(c => c.Idclient));
        }

        public void Delete(string idNumber)
        {
            Client? client = this.DbContext.Clients.FirstOrDefault(c => c.IdNumberPerson == idNumber);
            if (client == null)
            {
                throw new ConflictException("Client not exist");
            }

            this.DbContext.Clients.Remove(client);
            this.DbContext.SaveChanges();
        }

        public ICollection<Client> GetAll()
        {
            ICollection<Client> clientList = this.DbContext.Clients.ToList();
            foreach (Client client in clientList)
            {
                this.DbContext.Entry(client).Reference(c => c.Person).Load();
            }
            return clientList;
        }

        public Client GetById(string idNumber)
        {
            Client? client = this.DbContext.Clients.FirstOrDefault(c => c.IdNumberPerson == idNumber);
            if (client == null)
            {
                throw new ConflictException("Client not exist");
            }
            this.DbContext.Entry(client).Reference(u => u.Person).Load();

            return client;
        }

        public Client Update(ClientRequest clientRequest)
        {
            Client? client = this.DbContext.Clients.FirstOrDefault(c => c.IdNumberPerson == clientRequest.IdNumber);
            if (client == null)
            {
                throw new ConflictException("Client not exist");
            }
            this.DbContext.Entry(client).Reference(u => u.Person).Load();
            if (client.Person == null)
            {
                throw new ConflictException("Client data error");
            }
            client.Person.FirstName = clientRequest.FirstName;
            client.Person.LastName = clientRequest.LastName;
            client.PhoneNumbre = clientRequest.PhoneNumbre;

            this.DbContext.SaveChanges();

            return client;
        }
    }
}
