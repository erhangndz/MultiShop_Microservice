namespace Multishop.Cargo.Entity.Entities
{
    public class CargoDetail
    {
        public int CargoDetailId { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public int Barcode { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }

    }
}
