using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Contracts.Proposal
{
    public interface IPropsolRepository
    {
        Task<int> CreateProposal(Entites.Proposal proposal, CancellationToken cancellationToken);
        Task<bool> UpdateProposal(Entites.Proposal proposal, CancellationToken cancellationToken);
        Task<Entites.Proposal> GetProposalById(int id, CancellationToken cancellationToken);
        Task<List<Entites.Proposal>> GetProposals(CancellationToken cancellationToken);
        Task<bool> IsActiveProposal(int id, bool active, CancellationToken cancellationToken);
        public Task<bool> AcceptProposal(int proposalId, CancellationToken cancellationToken);
        public Task<bool> RejectProposal(int proposalId, CancellationToken cancellationToken);
        public Task<bool> ChangeProposalStatus(Entites.Proposal changeProposal, CancellationToken cancellationToken);

    }
}
