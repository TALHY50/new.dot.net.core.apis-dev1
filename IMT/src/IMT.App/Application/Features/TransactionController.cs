using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedBusiness.Main.Common.Domain.Entities;
using SharedBusiness.Main.Common.Infrastructure.Persistence.Context;
using SharedBusiness.Main.IMT.Application.Interfaces.Repositories;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Application.Common;
using SharedKernel.Main.Application.Common.Constants.Routes;
using StackExchange.Redis;
using SharedKernel.Main.Contracts.Common;

namespace IMT.App.Application.Features
{
    [Tags("Thunes")]
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ApiControllerBase
    {
        [Tags("Thunes.Money Transfer")]
        //[Authorize(Policy = "HasPermission")]
        [HttpPost(Routes.CreateMoneyTransferTransactionUrl, Name = Routes.CreateMoneyTransferTransactionName)]
        public async Task<ActionResult<ErrorOr<Transaction>>> Create(CreateTransactionCommand command)
        {
            return await Mediator.Send(command).ConfigureAwait(false);
        }

        public record CreateTransactionCommand(
            string invoice_id,
            string order_id,
            ReceiverAccountIdentifier receiver_account_identifier,
            Sender sender,
            Receiver receiver,
            string purpose_of_remittance,
            string document_reference_number,
            string reference
            )
            : IRequest<ErrorOr<Transaction>>;

        public class Receiver
        {
            public string last_name { get; set; }
            public string middle_name { get; set; }
            public string first_name { get; set; }
            public string nationality_country_iso_code { get; set; }
            public string date_of_birth { get; set; }
            public string country_of_birth_iso_code { get; set; }
            public string gender { get; set; }
            public string address { get; set; }
            public string postal_code { get; set; }
            public string city { get; set; }
            public string country_iso_code { get; set; }
            public string msisdn { get; set; }
            public string email { get; set; }
            public int id_type { get; set; }
            public string id_country_iso_code { get; set; }
            public string id_number { get; set; }
            public string occupation { get; set; }
        }

        public class ReceiverAccountIdentifier
        {
            public string iban { get; set; }
        }
        public class Sender
        {
            public string last_name { get; set; }
            public string middle_name { get; set; }
            public string first_name { get; set; }
            public string nationality_country_iso_code { get; set; }
            public string date_of_birth { get; set; }
            public string country_of_birth_iso_code { get; set; }
            public string gender { get; set; }
            public string address { get; set; }
            public string postal_code { get; set; }
            public string city { get; set; }
            public string country_iso_code { get; set; }
            public string msisdn { get; set; }
            public string email { get; set; }
            public string id_type { get; set; }
            public string id_number { get; set; }
            public string id_delivery_date { get; set; }
            public string occupation { get; set; }
        }



        internal sealed class CreateTransactionCommandValidator : AbstractValidator<CreateTransactionCommand>
        {
            public CreateTransactionCommandValidator()
            {
                // fontend validation
                RuleFor(r => r.invoice_id).NotEmpty().WithMessage("Invoice id is required.");
                RuleFor(r => r.order_id).NotEmpty().WithMessage("Order id is required.");
                RuleFor(r => r.receiver_account_identifier.iban).NotEmpty().WithMessage("Iban is required.");
                RuleFor(r => r.sender.last_name).NotEmpty().WithMessage("Sender Last name is required.");
                RuleFor(r => r.sender.middle_name).NotEmpty().WithMessage("Sender middle name is required.");
                RuleFor(r => r.sender.first_name).NotEmpty().WithMessage("Sender First name is required.");
                RuleFor(r => r.sender.nationality_country_iso_code).NotEmpty().WithMessage("National Country iso code is required.");
                RuleFor(r => r.sender.date_of_birth).NotEmpty().WithMessage("Date of birth is required.");
                RuleFor(r => r.sender.country_of_birth_iso_code).NotEmpty().WithMessage("Country of birth of iso code is required.");
                RuleFor(r => r.sender.gender).NotEmpty().WithMessage("Sender gender is required.");
                RuleFor(r => r.sender.address).NotEmpty().WithMessage("Sender address is required.");
                RuleFor(r => r.sender.postal_code).NotEmpty().WithMessage("Sender postal code is required.");
                RuleFor(r => r.sender.country_iso_code).NotEmpty().WithMessage("Sender country iso code is required.");
                RuleFor(r => r.sender.id_type).NotEmpty().WithMessage("Sender id type is required.");
                RuleFor(r => r.sender.id_number).NotEmpty().WithMessage("Sender id number is required.");
                RuleFor(r => r.sender.occupation).NotEmpty().WithMessage("Sender occupation is required.");
                RuleFor(r => r.receiver.last_name).NotEmpty().WithMessage("Receiver last name is required.");
                RuleFor(r => r.receiver.middle_name).NotEmpty().WithMessage("Receiver middle name is required.");
                RuleFor(r => r.receiver.first_name).NotEmpty().WithMessage("Receiver first name is required.");
                RuleFor(r => r.receiver.nationality_country_iso_code).NotEmpty().WithMessage("Receiver National Country iso code is required.");
                RuleFor(r => r.receiver.date_of_birth).NotEmpty().WithMessage("Receiver date of birth is required.");
                RuleFor(r => r.receiver.country_of_birth_iso_code).NotEmpty().WithMessage("Receiver country of birth iso code is required.");
                RuleFor(r => r.receiver.gender).NotEmpty().WithMessage("Receiver gender is required.");
                RuleFor(r => r.receiver.address).NotEmpty().WithMessage("Receiver address is required.");
                RuleFor(r => r.receiver.postal_code).NotEmpty().WithMessage("Receiver postal code is required.");
                RuleFor(r => r.receiver.city).NotEmpty().WithMessage("Receiver city is required.");
                RuleFor(r => r.receiver.country_iso_code).NotEmpty().WithMessage("Receiver country iso code is required.");
                RuleFor(r => r.receiver.email).NotEmpty().WithMessage("Receiver email is required.");
                RuleFor(r => r.receiver.id_type).NotEmpty().WithMessage("Receiver id type is required.");
                RuleFor(r => r.receiver.id_country_iso_code).NotEmpty().WithMessage("Receiver id country iso code is required.");
                RuleFor(r => r.receiver.id_number).NotEmpty().WithMessage("Receiver id number is required.");
                RuleFor(r => r.receiver.occupation).NotEmpty().WithMessage("Receiver occupation is required.");
                RuleFor(r => r.purpose_of_remittance).NotEmpty().WithMessage("Purpose of remittance is required.");
                RuleFor(r => r.document_reference_number).NotEmpty().WithMessage("Document reference number is required.");
                RuleFor(r => r.reference).NotEmpty().WithMessage("Reference is required.");
            }
        }

        internal sealed class CreateHolidaySettingHandler(ApplicationDbContext context, ITransactionRepository _transactionRepository, IQuotationRepository _quotationRepository, ITransactionRepository transactionRepository, IMoneyTransferRepository moneyTransferRepository) : IRequestHandler<CreateTransactionCommand, ErrorOr<Transaction>>
        {
            public async Task<ErrorOr<Transaction>> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
            {

                // business validation
                var quotation = _quotationRepository.Where(q => q.InvoiceId == request.invoice_id && q.OrderId == request.order_id).FirstOrDefault();
                if (quotation is null)
                {
                    // Not found Quotation
                    return Error.NotFound("Quotation not found", ApplicationStatusCodes.API_ERROR_RECORD_NOT_FOUND.ToString());
                }

                // operation on db



                // insert money transfer

                // insert transaction


                var entity = new Transaction
                {
                    //CountryId = request.CountryId,
                    //Date = request.Date,
                    //Type = request.Type,
                    //Gmt = request.Gmt,
                    //OpenAt = request.OpenAt,
                    //CloseAt = request.CloseAt,
                    //CompanyId = request.CompanyId
                };

                var moneyTransfer = new MoneyTransfer
                {
                    //CountryId = request.CountryId,
                    //Date = request.Date,
                    //Type = request.Type,
                    //Gmt = request.Gmt,
                    //OpenAt = request.OpenAt,
                    //CloseAt = request.CloseAt,
                    //CompanyId = request.CompanyId
                };


                moneyTransferRepository.AddAsync(moneyTransfer);

                return await transactionRepository.AddAsync(entity);
            }
        }




        //#pragma warning disable CS1717 // Assignment made to same variable
        //        private readonly IMoneyTransferService _transactionService;
        //        public TransactionController(IMoneyTransferService transactionService)
        //        {
        //            _transactionService = transactionService;
        //        }

        //        [Tags("Thunes.Transaction")]
        //        [HttpPost(ThunesUrl.CreateTransactionUrl)]
        //        public Object TransactionPost(ulong id, MoneyTransferDTO request)
        //        {
        //            try
        //            {
        //              return  _transactionService.CreateTransactionByQuotationId(id, request);
        //            }
        //            catch (ThunesException e)
        //            {
        //                return StatusCode(e.ErrorCode, e.Errors);
        //            }
        //        }
        //        [Tags("Thunes.Transaction")]
        //        [HttpPost(ThunesUrl.CreateTransactionFromQuotationExternalIdUrl)]
        //        public Object CreateTransactionFromQuotationExternalIdPost(string invoice_id, MoneyTransferDTO request)
        //        {
        //            try
        //            {
        //                return _transactionService.CreateTransactionByExternalId(invoice_id, request);
        //            }
        //            catch (ThunesException e)
        //            {
        //                return StatusCode(e.ErrorCode, e.Errors);
        //            }
        //        }
    }






}
