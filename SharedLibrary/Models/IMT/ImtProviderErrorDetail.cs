using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Models.IMT
{
    [Table("imt_provider_error_details")]
    public class ImtProviderErrorDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int ImtProviderId { get; set; }

        [Required]
        [Column(TypeName = "tinyint")]
        public int Type { get; set; }

        [Required]
        public int ReferenceId { get; set; }

        [StringLength(20)]
        public string ErrorCode { get; set; }

        [StringLength(255)]
        public string ErrorMessage { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
