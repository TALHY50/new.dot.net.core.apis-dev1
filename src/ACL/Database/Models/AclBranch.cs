using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ACL.Database.Models
{
    [Table("acl_branches")]
    public class AclBranch
    {
        [Key]
        [Column("id")]
        public ulong Id { get; set; }

        [Column("company_id")]
        public ulong CompanyId { get; set; }

        [Required]
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Column("address")]
        [StringLength(255)]
        public string Address { get; set; }

        [Column("description")]
        [StringLength(255)]
        public string Description { get; set; }

        [Column("status")]
        public byte Status { get; set; } // 1=active, 2=inactive

        [Column("sequence")]
        public ulong Sequence { get; set; }

        [Column("created_by_id")]
        public ulong CreatedById { get; set; }

        [Column("updated_by_id")]
        public ulong UpdatedById { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
