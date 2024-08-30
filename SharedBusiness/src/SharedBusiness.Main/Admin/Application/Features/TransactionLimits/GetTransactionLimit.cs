using ErrorOr;
using MediatR;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Contracts.Common;


namespace SharedBusiness.Main.Admin.Application.Features.TransactionLimits
{

    public record GetTransactionLimitQuery() : IRequest<ErrorOr<StatusModel>>;

    public class GetTransactionLimitHandler : IRequestHandler<GetTransactionLimitQuery, ErrorOr<StatusModel>>
    {
        private readonly IImtTransactionLimitRepository _repository;
        private readonly StatusModel ResponseModel;
        public GetTransactionLimitHandler(IImtTransactionLimitRepository repository)
        {
            _repository = repository;
            ResponseModel = new StatusModel();
        }
        public async Task<ErrorOr<StatusModel>> Handle(GetTransactionLimitQuery request, CancellationToken cancellationToken)
        {
            var data = _repository.All();
            if (data.Any())
            {
                ResponseModel.Status = new StatusEntityModel { 
                    Code = AppStatusCode.SUCCESS.ToString(),
                    Message = "Transaction Limit is fetched succesfully." 
                };
                ResponseModel.Data = data;
            }
            return ResponseModel;
        }
    }

}
