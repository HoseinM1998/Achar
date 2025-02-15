﻿using AcharDomainCore.Contracts.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.City;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.CityDto;
using AcharDomainCore.Entites;

namespace AcharDomainService
{
    public class CityService:ICityService
    {
        private readonly ICityRepository _repository;
        public CityService(ICityRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateCity(CityDto city, CancellationToken cancellationToken)
            => await _repository.CreateCity(city, cancellationToken);

        public async Task<bool> UpdateCity(CityDto city, CancellationToken cancellationToken)
            => await _repository.UpdateCity(city, cancellationToken);


        public async Task<City> GetCityById(int id, CancellationToken cancellationToken)
            => await _repository.GetCityById(id, cancellationToken);


        public async Task<List<City>> GetAllCity(CancellationToken cancellationToken)
            => await _repository.GetAllCity(cancellationToken);


        public async Task<bool> DeleteCity(SoftDeleteDto delete, CancellationToken cancellationToken)
            => await _repository.DeleteCity(delete, cancellationToken);

    }
}
