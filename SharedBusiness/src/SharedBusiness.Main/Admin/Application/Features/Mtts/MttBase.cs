using Microsoft.Extensions.Logging;
using SharedBusiness.Main.Admin.Weblication.Features.Countries;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedBusiness.Main.Admin.Weblication.Features.Mtts
{
    public class MttBase : ApiControllerBase
    {
        public MttBase()
        {
            
        }
        protected MttBase(ILogger<MttBase> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }
    }
}
