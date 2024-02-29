using Microsoft.Data.SqlClient;
using System.Data;

namespace ProductMicroservice.Base
{
    public class BaseRepository
    {
        protected readonly IDbConnection _dbConnection;

        public BaseRepository(IDbConnection dbConnection)
        {
            _dbConnection = new SqlConnection("Data Source=.;Initial Catalog=ProductDb; Integrated Security=true;Encrypt=True;TrustServerCertificate = True;");
        }
    }
}
