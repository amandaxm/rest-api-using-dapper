using repositorio_pattern.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace repositorio_pattern.DataAccess.Dapper
{
    public interface IDeveloperRepository
    {
        Task<IEnumerable<Developer>> GetAllDevelopersAsync();
        Task<Developer> GetDeveloperByIdAsync();
        Task<Developer> GetDeveloperByEmailAsync();
        void AddDeveloper(Developer developer);
        void UpdateDeveloper(Developer developer);
        void DeleteDeveloper(int id);
    }
}
