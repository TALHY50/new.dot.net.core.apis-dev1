﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedBusiness.Main.IMT.Contracts.Contracts.Responses
{
    public record TransactionTypeDto(
        uint id,
        string? Name,
        byte? Status);
}