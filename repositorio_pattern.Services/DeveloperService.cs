using repositorio_pattern.Domain;
using repository_pattern.DataAccess.Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace repository_pattern.Services
{
    public class DeveloperService : IDeveloperService
    {
        protected readonly IDeveloperRepository developerRepository;

        public DeveloperService(IDeveloperRepository developerRepository)
        {
            this.developerRepository = developerRepository;
        }

        public void AddDeveloper(Developer developer)
        {
            developerRepository.AddDeveloper(developer);
        }

        public void DeleteDeveloper(int id)
        {
            developerRepository.DeleteDeveloper(id);
        }

        public Task<IEnumerable<Developer>> GetAllDevelopersAsync()
        {
            return developerRepository.GetAllDevelopersAsync();
        }

        public Task<Developer> GetDeveloperByEmailAsync(string email)
        {
            return developerRepository.GetDeveloperByEmailAsync(email);
        }

        public Task<Developer> GetDeveloperByIdAsync(int id)
        {
            return developerRepository.GetDeveloperByIdAsync(id);
        }

        public void UpdateDeveloper(Developer developer)
        {
            developerRepository.UpdateDeveloper(developer);    
        }
    }
}
