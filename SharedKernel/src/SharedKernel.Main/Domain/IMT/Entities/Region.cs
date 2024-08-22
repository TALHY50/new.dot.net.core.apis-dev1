namespace SharedKernel.Main.Domain.IMT.Entities
{
    public class Region
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? CompanyId { get; set; }
        public sbyte Status { get; set; }
        public int? CreatedById { get; set; }
        public int? UpdatedById { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
