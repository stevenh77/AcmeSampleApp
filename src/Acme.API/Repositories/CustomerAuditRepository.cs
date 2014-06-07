using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Acme.API.Interfaces;
using Acme.API.Models;
using Dapper;

namespace Acme.API.Repositories
{
    public class CustomerAuditRepository : ICustomerAuditRepository
    {
        // store centrally and amake available to entire app (stored here for now as the only usage)
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["AcmeSampleDb"].ConnectionString;

        public IEnumerable<CustomerAudit> GetAll()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<CustomerAudit>(
                    AcmeDatabase.StoredProc_CustomerSelectAll_Audit,
                    null,
                    commandType: CommandType.StoredProcedure).AsQueryable();
            }
        }
    }
}