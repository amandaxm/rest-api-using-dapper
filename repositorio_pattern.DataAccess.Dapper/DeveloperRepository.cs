using Dapper;
using Microsoft.Extensions.Configuration;
using repositorio_pattern.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using repository_pattern.DataAccess.Dapper;

namespace repositorio_pattern.DataAccess.Dapper
{
    public class DeveloperRepository : IDeveloperRepository
    {
        protected readonly IConfiguration _config;

        public DeveloperRepository(IConfiguration config)
        {
            _config = config;
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("Default"));
            }
        }




        public async Task<Developer> GetDeveloperByIdAsync(int id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT Id,DeveloperName,Email,GithubURL,ImageURL, Department,JoinedDate FROM developer WHERE Id =@Id";
                    return await dbConnection.QueryFirstOrDefaultAsync<Developer>(query, new { Id = id });
                }

            }
            catch
            {

                throw;
            }
        }

        public async Task<Developer> GetDeveloperByEmailAsync(string email)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT Id,DeveloperName,Email,GithubURL,ImageURL, Department,JoinedDate FROM developer WHERE Email =@Email";
                    return await dbConnection.QueryFirstOrDefaultAsync<Developer>(query, new { Email = email });
                }

            }
            catch
            {

                throw;
            }
        }

        public void UpdateDeveloper(Developer developer)
        {

            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"UPDATE developer SET DeveloperName = @DeveloperName,Email = @Email,GithubURL = @GithubURL,ImageURL = @ImageURL, Department = @Department,JoinedDate = @JoinedDate";
                    dbConnection.Execute(query, developer);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<IEnumerable<Developer>> GetAllDevelopersAsync()
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"SELECT * FROM developer";
                    return await dbConnection.QueryAsync<Developer>(query);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteDeveloper(int id)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"DELETE FROM developer WHERE Id =@Id";
                    dbConnection.Execute(query, new { Id = id });
                }

            }
            catch { }
        }

        public void AddDeveloper(Developer developer)
        {
            try
            {
                using (IDbConnection dbConnection = Connection)
                {
                    dbConnection.Open();
                    string query = @"INSERT INTO developer(DeveloperName,Email,GithubURL,ImageURL, Department) VALUES (@DeveloperName,@Email,@GithubURL,@ImageURL,@Department)";
                    dbConnection.Execute(query, developer);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
