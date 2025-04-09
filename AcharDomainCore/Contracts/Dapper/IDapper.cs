using AcharDomainCore.Dtos.CityDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Dtos.SubCategoryDto;
using AcharDomainCore.Dtos.HomeServiceDto;

namespace AcharDomainCore.Contracts.Dapper
{
    public interface IDapper
    {
        Task<List<Entites.City>> GetAllCityDapper(CancellationToken cancellationToken);

        Task<List<Entites.Category>> GetAllCategoryDapper(CancellationToken cancellationToken);
        Task<List<SubCategoryDto>> GetAllSubCategory(CancellationToken cancellationToken);
        Task<List<HomeServiceDto>> GetAllHomeServiceDapper(CancellationToken cancellationToken);




    }
}
