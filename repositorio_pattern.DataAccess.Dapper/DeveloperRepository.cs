using Microsoft.Extensions.Configuration;
using repositorio_pattern.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace repositorio_pattern.DataAccess.Dapper
{
    public class DeveloperRepository: IDeveloperRepository
    {
        protected readonly IConfiguration _config;

        public DeveloperRepository(IConfiguration config)
        {
            _config = config;
        }
        public IDbConnection Connection
        {
            get {
                return new SqlConnection(_config.GetConnectionString("ConnectionStrings"));
            }
        }
        Task<IEnumerable<Developer>> IDeveloperRepository.GetAllDevelopersAsync()
        {
            throw new NotImplementedException();
        }

        Task<Developer> IDeveloperRepository.GetDeveloperByIdAsync()
        {
            throw new NotImplementedException();
        }

        Task<Developer> IDeveloperRepository.GetDeveloperByEmailAsync()
        {
            throw new NotImplementedException();
        }

        void IDeveloperRepository.AddDeveloper(Developer developer)
        {
            throw new NotImplementedException();
        }

        void IDeveloperRepository.UpdateDeveloper(Developer developer)
        {
            throw new NotImplementedException();
        }

        void IDeveloperRepository.DeleteDeveloper(int id)
        {
            throw new NotImplementedException();
        }
    }
}
