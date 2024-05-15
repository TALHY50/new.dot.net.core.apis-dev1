
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ACL.Application.Interfaces;
using ACL.Infrastructure.Database;
using SharedLibrary.CustomDataAnotator;

namespace ACL.Requests;

public partial class AclStateRequest
{

    [DefaultValue("2")]
    [Required(ErrorMessage = "country_id is required.")]
    [Range(1, ulong.MaxValue, ErrorMessage = "country_id is required.")]
    [ExistsInDatabase<ApplicationDbContext,ICustomUnitOfWork>("AclCountry", "Id")]
    public ulong CountryId { get; set; }

    [DefaultValue("Florida")]
    [Required(ErrorMessage = "name is required.")]
    [StringLength(50)]
    [UniqueValue<ApplicationDbContext, ICustomUnitOfWork>("AclState", "Name")]
    public  string Name { get; set; }

    [DefaultValue("Florida is state of USA")]
    [StringLength(255)]
    public  string Description { get; set; }

    [DefaultValue("1")]
    [Required(ErrorMessage = "status is required.")]
    [Range(1, 2, ErrorMessage = "status is required.")]
    public byte Status { get; set; }

    [DefaultValue("100")]
    [Required(ErrorMessage = "sequence is required.")]
    [Range(1, ulong.MaxValue, ErrorMessage = "sequence is required.")]
    public ulong Sequence { get; set; }

   
}
