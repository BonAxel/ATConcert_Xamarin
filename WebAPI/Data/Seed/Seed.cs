namespace WebAPI.Data.Seed
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {


                //dataContext.PokemonOwners.AddRange(pokemonOwners);
                dataContext.SaveChanges();
            
        }
    }
}
