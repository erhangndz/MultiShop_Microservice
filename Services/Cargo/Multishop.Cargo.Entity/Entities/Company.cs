namespace Multishop.Cargo.Entity.Entities
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public List<CargoDetail> CargoDetails { get; set; }
    }
}
