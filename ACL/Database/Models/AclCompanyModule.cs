using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace ACL.Database.Models
{
    [Table("acl_company_modules")]
    public class AclCompanyModule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public ulong Id { get; set; }

        [Required]
        [Column("company_id")]
        public ulong CompanyId { get; set; }

        [Required]
        [Column("module_id")]
        public ulong ModuleId { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
