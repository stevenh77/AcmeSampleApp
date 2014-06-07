using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Acme.API.Interfaces;
using Acme.DTOs;
using Dapper;
using Customer = Acme.API.Models.Customer;

namespace Acme.API.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["AcmeSampleDb"].ConnectionString;

        public IEnumerable<Customer> GetAll()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Customer>(
                    AcmeDatabase.StoredProc_CustomerSelectAll,
                    null,
                    commandType: CommandType.StoredProcedure).AsQueryable();
            }
        }

        public Customer Get(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Customer>(
                    AcmeDatabase.StoredProc_CustomerSelect,
                    new {Id = id},
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public int Insert(Customer model)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var param = new
                {
                    model.Name,
                    model.GenderId,
                    model.HouseNumber,
                    model.AddressLine1,
                    model.State,
                    model.CountryId,
                    model.CategoryId,
                    model.DateOfBirth,
                    model.User
                };
                return connection.Query<int>(
                    AcmeDatabase.StoredProc_CustomerInsert,
                    param, 
                    commandType: CommandType.StoredProcedure)
                    .First();
            }
        }

        public void Update(Customer model)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var param = new
                {
                    model.Id,
                    model.Name,
                    model.GenderId,
                    model.HouseNumber,
                    model.AddressLine1,
                    model.State,
                    model.CountryId,
                    model.CategoryId,
                    model.DateOfBirth,
                    model.User
                };
                connection.Execute(
                    AcmeDatabase.StoredProc_CustomerUpdate,
                    param,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(
                    AcmeDatabase.StoredProc_CustomerDelete,
                    new { Id = id },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<Customer> Search(string searchString)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Customer>(
                    AcmeDatabase.StoredProc_CustomerSearch,
                    new { searchString },
                    commandType: CommandType.StoredProcedure).AsQueryable();
            }
        }

        public IEnumerable<IEnumerable<ChartData>> GetCustomersByCategoryAndLocation()
        {
            using (var connection = new SqlConnection(connectionString))
            using (var multi = connection.QueryMultiple(
                AcmeDatabase.StoredProc_CustomersByCategoryAndLocation, 
                null,
                commandType: CommandType.StoredProcedure))
            {
                var categories = multi.Read<ChartData>().ToList();
                var locations = multi.Read<ChartData>().ToList();

                return new List<List<ChartData>>() { categories, locations };
            } 
        }
    }
}


        // example for code review using standard SQL objects 
        //public IQueryable<Customer> GetAll()
        //{
        //    var customers = new List<Customer>();
        //    using (var connection = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            var command = new SqlCommand(AcmeDatabase.StoredProc_GetCustomers, connection)
        //            {
        //                CommandType = CommandType.StoredProcedure
        //            };
        //            connection.Open();
        //            var dataReader = command.ExecuteReader();
        //            while (dataReader.Read())
        //            {
        //                var customer = new Customer()
        //                {
        //                    Id = dataReader.GetInt32(dataReader.GetOrdinal("Id")),
        //                    Name = dataReader.GetString(dataReader.GetOrdinal("Name"))
        //                };
        //                customers.Add(customer);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Debug.Write(string.Format("Exception: {0}", ex.Message));
        //            throw;
        //        }
        //    }
        //    return customers.AsQueryable();
        //}