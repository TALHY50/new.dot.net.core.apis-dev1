using ACL.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ACL.Database.Models;
using ACL.Requests.V1;
using ACL.Interfaces.Repositories.V1;
using ACL.Response.V1;
using ACL.Requests;
using ACL.Interfaces;

namespace ACL.Controllers.V1
{

    [ApiController]
    [Route("api/v1/")]
    public class AclPageController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public AclPageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("pages", Name = "acl.company.list")]
        public async Task<IActionResult> Index()
        {
            return Ok(_unitOfWork.AclPageRepository.GetAll());
        }

        [HttpPost("pages/add", Name = "acl.page.add")]
        public async Task<AclResponse> Create(AclPageRequest request)
        {
            return _unitOfWork.AclPageRepository.Add(request);
        }
        [HttpPut("pages/edit/{id}", Name = "acl.page.edit")]
        public async Task<AclResponse> Edit(ulong id, AclPageRequest request)
        {
            return _unitOfWork.AclPageRepository.Edit(id, request);

        }

        [HttpDelete("pages/delete/{id}", Name = "acl.page.destroy")]
        public async Task<AclResponse> Destroy(ulong id)
        {
            return _unitOfWork.AclPageRepository.deleteById(id);
        }

        [HttpDelete("pages/view/{id}", Name = "acl.page.view")]
        public async Task<AclResponse> View(ulong id)
        {
            return _unitOfWork.AclPageRepository.findById(id);

        }
    }
}
