using mvcproject.Models;

namespace mvcproject.Repository
{
    public class FavouriteRepository : IFavouriteRepository
    {
        private readonly  ProjectContext Context;

        public FavouriteRepository(ProjectContext context)
        {
            Context = context;
        }
        #region Add a favourite entity 
        public void Add(Favourite customerFavourite)
        {
            Context.Favourites.Add(customerFavourite);
        }
        #endregion

        #region Save Changes
        public void Save()
        {
            Context.SaveChanges();
        }
        #endregion
    }
}
