using AcharDomainCore.Contracts.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.HomeService;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.HomeServiceDto;

namespace AcharDomainService
{
    public class HomeServiceService : IHomeServiceService
    {
        private readonly IHomeServiceRepository _repository;
        public HomeServiceService(IHomeServiceRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateHomeService(HomeServiceDto homeService, CancellationToken cancellationToken)
            => await _repository.CreateHomeService(homeService, cancellationToken);

        public async Task<bool> UpdateHomeService(HomeServiceDto homeService, CancellationToken cancellationToken)
            => await _repository.UpdateHomeService(homeService, cancellationToken);


        public async Task<int> HomeServiceCount(CancellationToken cancellationToken)
            => await _repository.HomeServiceCount(cancellationToken);


        public async Task<HomeServiceDto> GetHomeServiceById(int id, CancellationToken cancellationToken)
            => await _repository.GetHomeServiceById(id,cancellationToken);


        public async Task<List<HomeServiceDto>> GetHomeServices(CancellationToken cancellationToken)
            => await _repository.GetHomeServices(cancellationToken);


        public async Task<bool> DeleteHomeService(SoftDeleteDto delete, CancellationToken cancellationToken)
            => await _repository.DeleteHomeService(delete,cancellationToken);

    }
}
