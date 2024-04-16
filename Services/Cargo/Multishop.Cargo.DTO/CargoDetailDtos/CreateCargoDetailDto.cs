namespace Multishop.Cargo.DTO.CargoDetailDtos
{
    public class CreateCargoDetailDto
    {

        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public int Barcode { get; set; }
        public int CompanyId { get; set; }
    }
}
