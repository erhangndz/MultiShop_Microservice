namespace Multishop.Basket.Dtos
{
    public class BasketItemDto
    {

        public string ProductId { get; set; }


        public string ProductName { get; set; }
        public string ImageUrl { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public BasketItemDto(string productId, string productName, string imageUrl, int quantity, decimal price)
        {
            ProductId = productId;
            ProductName = productName;
            ImageUrl = imageUrl;
            Quantity = quantity;
            Price = price;
        }

        public BasketItemDto()
        {
            
        }


        public void UpdateOrderItems(string productId, string updatedName, string imageUrl, int quantity, decimal price)
        {
            ProductId=productId;
            ProductName = updatedName;
            ImageUrl = imageUrl;
            Quantity=quantity;
            Price = price;

        }
    }
}
