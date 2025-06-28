using mvcproject.Models;

namespace mvcproject.Repository
{
    public interface IFavouriteRepository:IRepository<Favourite>
    {
        void Add(Favourite customerFavourite);
        void Save();
    }
}
