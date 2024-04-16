using MediatR;

namespace Multishop.Order.Application.Features.Mediator.Commands.OrderDetailCommands
{
    public class UpdateOrderDetailCommand : IRequest
    {
        public int OrderDetailId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderingId { get; set; }
    }
}
