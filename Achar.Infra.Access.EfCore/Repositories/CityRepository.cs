using Achar.Infra.Db.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.City;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.CityDto;
using AcharDomainCore.Entites;
using AcharDomainCore.Dtos.CategoryDto;
using Microsoft.EntityFrameworkCore;

namespace Achar.Infra.Access.EfCore.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly AppDbContext _context;

        public CityRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateCity(CityDto cityDto, CancellationToken cancellationToken)
        {
            var city = new City()
            {
                CreateAt = DateTime.Now,
                Title = cityDto.Title
            };

            await _context.Cities.AddAsync(city, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return city.Id;
        }

        public async Task<bool> UpdateCity(CityDto cityDto, CancellationToken cancellationToken)
        {
            var city = await _context.Cities.FindAsync(cityDto.Id, cancellationToken);
            if (city is null) return false;
            city.Title = cityDto.Title;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<City> GetCityById(int id, CancellationToken cancellationToken)
        {
            return await _context.Cities.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task<List<City>> GetAllCity(CancellationToken cancellationToken)
        {
            return await _context.Cities.AsNoTracking().ToListAsync(cancellationToken);

        }

        public async Task<bool> DeleteCity(SoftDeleteDto active, CancellationToken cancellationToken)
        {
            var city = await _context.Cities.FindAsync(active.Id, cancellationToken);
            if (city is null) return false;
            city.IsDeleted = active.IsDeleted;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
