using mvcproject.Models;

namespace mvcproject.Repository
{
    public interface IAddressRepository:IRepository<Address>
    {
         List<Address> GetAll();
        Address GetById(int _id);

        Address GetAddressByCustomerId(string customerID);
        void AddAdresses(List<Address> addressList);
        void Delete(Address address);
        void Add(Address address);

        void Save();
    }
}
