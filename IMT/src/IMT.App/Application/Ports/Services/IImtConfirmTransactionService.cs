﻿using SharedKernel.Main.Application.Interfaces.Repositories.IMT.Repositories;
using Thunes.Request.ConfirmTrasaction;
using Thunes.Response.Common;

namespace IMT.App.Application.Ports.Services
{
    public interface IImtConfirmTransactionService: IImtProviderErrorDetailsRepository
    {
        public object ConfirmTrasaction(ConfirmTrasactionDTO trasactionDTO);
        public void ErrorStore(List<ErrorsResponse> Errors, ConfirmTrasactionDTO trasactionDTO);
    }
}
