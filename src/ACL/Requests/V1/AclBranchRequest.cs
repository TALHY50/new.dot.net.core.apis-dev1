namespace ACL.Requests.V1
{
    public class AclBranchRequest
    {
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string Description { get; set; }
        public required ulong Sequence { get; set; }
        public int? Status { get; set; }
    }
}
