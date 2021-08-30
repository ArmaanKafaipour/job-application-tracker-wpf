using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace JobApplicationTracker
{
    public class DataAccess
    {
        public List<JobApp> GetJobApp(string companyName)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("JobApplications")))
            {
                //Direct SQL 
                //return connection.Query<JobApp>($"select * from tbl_jobApplication where Company = '{ companyName }'").ToList();

                //Stored procedure
                var output = connection.Query<JobApp>("dbo.JobApp_GetByCompany @Company", new { Company = companyName }).ToList();
                return output;
            }
        }

        public void InsertJobApp(string company, string position, string location, string link)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("JobApplications")))
            {
                //JobApp newJobApp = new JobApp { Company = company, Position = position, Location = location, Link = link };

                List<JobApp> jobApps = new List<JobApp>();

                jobApps.Add(new JobApp { Company = company, Position = position, Location = location, Link = link });

                connection.Execute("dbo.JobApp_Insert @Company, @Position, @Location, @Link", jobApps);
            }
        }
    }
}
