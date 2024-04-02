﻿using ACL.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace ACL.Controllers.V1
{
    [ApiController]
    [Route("api/v1/company/")]
    public class AclModuleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AclModuleController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("module")]
        public async Task<IActionResult> Index()
        {
            var _AclCompanyModules = await _context.AclCompanyModules.ToListAsync();

            return Ok(_AclCompanyModules);
        }

    }
}
