using Multishop.Order.Application.Features.Mediator.Results.OrderDetailResults;

namespace Multishop.Order.Application.Features.Mediator.Results.OrderingResults
{
    public class GetOrderingByIdQueryResult
    {
        public int OrderingId { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public List<GetOrderDetailQueryResult> OrderDetails { get; set; }
    }
}
