namespace Multishop.Cargo.DTO.CargoDetailDtos
{
    public class UpdateCargoDetailDto
    {
        public int CargoDetailId { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public int Barcode { get; set; }
        public int CompanyId { get; set; }
    }
}
