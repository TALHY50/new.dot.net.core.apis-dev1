using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMT.Application.Contracts.Requests.SendMoiney;

namespace IMT.Application.Domain.Ports.Services.SendMoney
{
    public interface IImtSendMoneyService
    {
        public object SendMoney(SendMoneyRequest request);
    }
}