using Dapper;
using Models;
using System.Data;
using System.Data.SqlClient;

namespace Libs
{
    public class SystemTools
    {
        public static IDbConnection Connection()
        {
            IDbConnection _db = new SqlConnection(ParamsModel.DBConnection.ToString());

            return _db;
        }


        public static string AddOrUpdateCandidate(CandidateModel model)
        {

            var res = Connection().Query<string>(ParamsModel.InsertOrUpdateContactInfo,

                    new
                    {
                        first_name = model.FirstName,
                        last_name = model.LastName,
                        phone_number = model.Phone,
                        email = model.Email,
                        call_time_interval = model.CallTimeInterval,
                        linkedin_url = model.LinkedinUrl,
                        github_url = model.GithubUrl,
                        comment = model.Comment
                    }
                    , null, true, 0, commandType: CommandType.StoredProcedure).FirstOrDefault();


            return res;
        }


    }

}
