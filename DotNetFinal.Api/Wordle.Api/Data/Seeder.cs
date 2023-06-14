namespace Wordle.Api.Data
{
    public static class Seeder
    {
        public static void Seed(AppDbContext context)
        {
            SeedPlayers(context);
            SeedWords(context);
        }
 
        public static void SeedWords(AppDbContext db)
        {
        }

        public static void SeedPlayers (AppDbContext db)
        {
 
        }

   }
}
