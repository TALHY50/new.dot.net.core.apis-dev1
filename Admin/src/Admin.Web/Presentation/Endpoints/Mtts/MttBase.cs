﻿using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;


namespace Admin.Web.Presentation.Endpoints.Mtts
{
    public class MttBase : ApiControllerBase
    {
        protected MttBase(ILogger<MttBase> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }
    }
}
