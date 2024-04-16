namespace Multishop.Cargo.Entity.Entities
{
    public class CargoOperation
    {
        public int CargoOperationId { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public DateTime OperationDate { get; set; }
    }
}
