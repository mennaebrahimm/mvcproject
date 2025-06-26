using mvcproject.Models;

namespace mvcproject.Repository
{
    public class AddressRepository : IAddressRepository
    {
        ProjectContext Context;
        public AddressRepository(ProjectContext _Context) {
            Context= _Context;
        }



        #region Get all addresses
        public List<Address> GetAll()
        {
            List<Address> addresses = Context.Addresses.ToList();
            return addresses;
        }
        #endregion

        #region Get only one address
        public Address GetById(int _id)
        {
            Address address = Context.Addresses.FirstOrDefault(add => add.id == _id);
            return address;
        }
        #endregion

        #region get address by customer id
        public Address GetAddressByCustomerId(string customerID)
        {
            return Context.Addresses.FirstOrDefault(c=>c.customerId==customerID);
        }

        #endregion

        #region add only one address
        public void Add(Address address)
        {
            Context.Addresses.Add(address);
        }
        #endregion

        #region add more than one address (list of addresses)
        public void AddAdresses(List<Address> addressList)
        {
            Context.Addresses.AddRange(addressList);
        }
        #endregion

        #region delete one address
        public void Delete(Address address)
        {
            Address addressToBeDeleted = Context.Addresses.FirstOrDefault(add => add.id == address.id);
            if (addressToBeDeleted != null)
            {
                addressToBeDeleted.isDeleted = true;
            }
        }
        #endregion


        #region save changes
        public void Save()
        {
            Context.SaveChanges();
        } 
        #endregion

    }
}
