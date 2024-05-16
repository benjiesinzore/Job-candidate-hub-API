using Dapper;
using Models;
using System.Data;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Text;

namespace Libs
{
    public class SystemTools
    {
        public static IDbConnection Connection()
        {
            IDbConnection _db = new SqlConnection(ParamsModel.DBConnection.ToString());

            return _db;
        }


    }

}
