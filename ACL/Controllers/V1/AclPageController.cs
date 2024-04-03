using ACL.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ACL.Database.Models;
using ACL.Requests.V1;
using ACL.Interfaces.Repositories.V1;
using ACL.Response.V1;
using ACL.Requests;

namespace ACL.Controllers.V1
{

    [ApiController]
    [Route("api/v1/")]
    public class AclPageController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly IAclPageRepository _repository;

        public AclPageController(ApplicationDbContext context, IAclPageRepository AclPageRepository)
        {
            _context = context;
            _repository = AclPageRepository;
        }

        [HttpGet("pages", Name = "acl.company.list")]
        public async Task<IActionResult> Index()
        {
            return Ok(_repository.GetAll());
        }

        [HttpPost("pages/add", Name = "acl.page.add")]
        public async Task<AclResponse> Create(AclPageRequest request)
        {
            return _repository.Add(request);
        }
        [HttpPut("pages/edit/{id}", Name = "acl.page.edit")]
        public async Task<AclResponse> Edit(ulong id, AclPageRequest request)
        {
            return _repository.Edit(id, request);

        }

        [HttpDelete("pages/delete/{id}", Name = "acl.page.destroy")]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return _repository.deleteById(id);
        }

        [HttpDelete("pages/view/{id}", Name = "acl.page.view")]
        public async Task<AclResponse> View(ulong id)
        {
            return _repository.findById(id);

        }
    }
}
