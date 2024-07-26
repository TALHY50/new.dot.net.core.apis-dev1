using System.ComponentModel.DataAnnotations;

namespace PayAll.Request.Common
{
    public class SupportingDocument
    {
        [Required]
        public string document_id { get; set; }
    }

}
