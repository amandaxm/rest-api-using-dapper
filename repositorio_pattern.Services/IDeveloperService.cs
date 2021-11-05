using repositorio_pattern.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace repository_pattern.Services
{
    public interface IDeveloperService
    {
        public Task<IEnumerable<Developer>> GetAllDevelopersAsync();
        public Task<Developer> GetDeveloperByIdAsync(int id);
        public Task<Developer> GetDeveloperByEmailAsync(string email);
        public void AddDeveloper(Developer developer);
        public void UpdateDeveloper(Developer developer);
        public void DeleteDeveloper(int id);
    }
}
