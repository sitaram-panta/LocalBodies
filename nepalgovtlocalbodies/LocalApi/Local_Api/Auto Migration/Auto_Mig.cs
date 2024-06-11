using Local_Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Local_Api.Auto_Migration
{
    public class Auto_Mig
    {
        public static void Initialize(AppDbContext appDb)
        {
            try
            {

                appDb.Database.Migrate();

            }
            catch (Exception ex)
            {
                throw new Exception("Database migration failed. Please contact support.", ex);

            }

        }
    }
}