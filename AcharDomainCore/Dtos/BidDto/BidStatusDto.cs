using AcharDomainCore.Enums;

namespace AcharDomainCore.Dtos.BidDto
{
    public class BidStatusDto
    {
        public int Id { get; set; }
        public StatusBidEnum Status { get; set; }
    }
}
