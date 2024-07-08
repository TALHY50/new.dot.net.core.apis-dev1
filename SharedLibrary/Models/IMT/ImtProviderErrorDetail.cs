using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Models.IMT
{
    public class ImtProviderErrorDetail
    {
        public int Id { get; set; }

        public int ImtProviderId { get; set; }

        public sbyte Type { get; set; }

        public int ReferenceId { get; set; }

        [StringLength(20)]
        public string ErrorCode { get; set; }

        [StringLength(255)]
        public string ErrorMessage { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
