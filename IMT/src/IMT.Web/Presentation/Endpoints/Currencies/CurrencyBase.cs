﻿using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Presentation;

namespace Admin.App.Presentation.Endpoints.Currencies
{
    public class CurrencyBase : ApiControllerBase
    {
        protected CurrencyBase(ILogger<CurrencyBase> logger, ICurrentUser currentUser) : base(logger, currentUser)
        {
        }
    }
}