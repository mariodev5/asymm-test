using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AysmmTest.WebAPI.Entities;
using AysmmTest.WebAPI.Exceptions;
using AysmmTest.WebAPI.Exceptions.Base;
using AysmmTest.WebAPI.Repositories;

namespace AysmmTest.WebAPI.Services
{
    public class DeveloperService : ICustomService<Developer>
    {
        private readonly IRepository<Developer> _developerRepository;

        public DeveloperService(IRepository<Developer> repository)
        {
            _developerRepository = repository;
        }

        public async Task<IEnumerable<Developer>> GetAllAsync()
        {
            return await _developerRepository.GetAllAsync();
        }

        public async Task<Developer> GetAsync(int id)
        {
            var Developer = await _developerRepository.GetAsync(id);

            if (Developer == null)
                throw new DataNotFoundException("Developer not found");

            return Developer;
        }

        public async Task<Developer> InsertAsync(Developer developer)
        {
            try
            {
                if (developer != null)
                {
                    var result = await _developerRepository.InsertAsync(developer);
                    return result;
                }
                else
                {
                    throw new DataFormatException("Request body not provided");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAsync(Developer developer)
        {
            try
            {
                if (developer != null)
                {
                    await _developerRepository.UpdateAsync(developer);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var developer = await GetAsync(id);

                if (developer != null)
                {
                    await _developerRepository.DeleteAsync(developer);
                }
                else
                {
                    throw new DataNotFoundException("Developer not found");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
