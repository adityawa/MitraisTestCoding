using MitraisCodingTest.Repository;

namespace MitraisCodingTest.Service.Common
{
    public class Utilities
    {
        private static DB_MitraisCodingTestEntities context = new DB_MitraisCodingTestEntities();

        
        public static DB_MitraisCodingTestEntities GetDataContext()
        {
            if (context == null)
            {
                return new DB_MitraisCodingTestEntities();
            }
            else
            {
                return context;
            }
        }
    }
}
