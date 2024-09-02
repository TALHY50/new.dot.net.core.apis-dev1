namespace SharedKernel.Main.Presentation.Routes
{
    public class Routes
    {
        public const string CreateEmailEventRouteName = "create-email-event";
        public const string CreateEmailEventRoute = "/api/notification/event/email/create";


        // Country

        // Service Method
        public const string GetServiceMethodName = "service_method";
        public const string GetServiceMethodUrl = "/api/admin/service_method";
        public const string GetServiceMethodByIdName = "service_method_by_id";
        public const string GetServiceMethodByIdUrl = "/api/admin/service_method/{Id}";
        public const string CreateServiceMethodName = "create_service_method";
        public const string CreateServiceMethodUrl = "/api/admin/service_method";
        public const string DeleteServiceMethodName = "delete_service_method";
        public const string DeleteServiceMethodUrl = "/api/admin/service_method/{Id}";
        public const string UpdateServiceMethodName = "update_service_method";
        public const string UpdateServiceMethodUrl = "/api/admin/service_method/{Id}";

        // Payer Payment Speed
        public const string GetPayerPaymentSpeedName = "payer_payment_speed";
        public const string GetPayerPaymentSpeedUrl = "/api/admin/payer_payment_speed";
        public const string GetPayerPaymentSpeedByIdName = "payer_payment_speed_by_id";
        public const string GetPayerPaymentSpeedByIdUrl = "/api/admin/payer_payment_speed/{Id}";
        public const string CreatePayerPaymentSpeedName = "create_payer_payment_speed";
        public const string CreatePayerPaymentSpeedUrl = "/api/admin/payer_payment_speed";
        public const string DeletePayerPaymentSpeedName = "delete_payer_payment_speed";
        public const string DeletePayerPaymentSpeedUrl = "/api/admin/payer_payment_speed/{Id}";
        public const string UpdatePayerPaymentSpeedName = "update_payer_payment_speed";
        public const string UpdatePayerPaymentSpeedUrl = "/api/admin/payer_payment_speed/{Id}";

        // Tax Rate
        public const string GetTaxRateName = "tax_rate";
        public const string GetTaxRateUrl = "/api/admin/tax_rate";
        public const string GetTaxRateByIdName = "tax_rate_by_id";
        public const string GetTaxRateByIdUrl = "/api/admin/tax_rate/{Id}";
        public const string CreateTaxRateName = "create_tax_rate";
        public const string CreateTaxRateUrl = "/api/admin/tax_rate";
        public const string DeleteTaxRateName = "delete_tax_rate";
        public const string DeleteTaxRateUrl = "/api/admin/tax_rate/{Id}";
        public const string UpdateTaxRateName = "update_tax_rate";
        public const string UpdateTaxRateUrl = "/api/admin/tax_rate/{Id}";

        // Currency Conversion Rate
        public const string GetCurrencyConversionRateName = "currency_conversion_rate";
        public const string GetCurrencyConversionRateUrl = "/api/admin/currency_conversion_rate";
        public const string GetCurrencyConversionRateByIdName = "currency_conversion_rate_by_id";
        public const string GetCurrencyConversionRateByIdUrl = "/api/admin/currency_conversion_rate/{Id}";
        public const string CreateCurrencyConversionRateName = "create_currency_conversion_rate";
        public const string CreateCurrencyConversionRateUrl = "/api/admin/currency_conversion_rate";
        public const string DeleteCurrencyConversionRateName = "delete_currency_conversion_rate";
        public const string DeleteCurrencyConversionRateUrl = "/api/admin/currency_conversion_rate/{Id}";
        public const string UpdateCurrencyConversionRateName = "update_currency_conversion_rate";
        public const string UpdateCurrencyConversionRateUrl = "/api/admin/currency_conversion_rate/{Id}";

        // Institution Fund
        public const string GetInstitutionFundName = "institution_fund";
        public const string GetInstitutionFundUrl = "/api/admin/institution_fund";
        public const string GetInstitutionFundByIdName = "institution_fund_by_id";
        public const string GetInstitutionFundByIdUrl = "/api/admin/institution_fund/{Id}";
        public const string CreateInstitutionFundName = "create_institution_fund";
        public const string CreateInstitutionFundUrl = "/api/admin/institution_fund";
        public const string DeleteInstitutionFundName = "delete_institution_fund";
        public const string DeleteInstitutionFundUrl = "/api/admin/institution_fund/{Id}";
        public const string UpdateInstitutionFundName = "update_institution_fund";
        public const string UpdateInstitutionFundUrl = "/api/admin/institution_fund/{Id}";

        // Business hour and weekend
        //public const string GetBusinessHourAndWeekendName = "get_business_hour_and_weekend";
        //public const string GetBusinessHourAndWeekendUrl = "/api/admin/business-hour-and-weekend";
        //public const string GetBusinessHourAndWeekendByIdName = "get_business_hour_and_weekend_by_id";
        //public const string GetBusinessHourAndWeekendByIdUrl = "/api/admin/business-hour-and-weekend/{id}";
        //public const string CreateBusinessHourAndWeekendName = "create_business_hour_and_weekend";
        //public const string CreateBusinessHourAndWeekendUrl = "/api/admin/business-hour-and-weekend";
        //public const string DeleteBusinessHourAndWeekendName = "delete_business_hour_and_weekend";
        //public const string DeleteBusinessHourAndWeekendUrl = "/api/admin/business-hour-and-weekend/{id}";
        //public const string UpdateBusinessHourAndWeekendName = "update_business_hour_and_weekend";
        //public const string UpdateBusinessHourAndWeekendUrl = "/api/admin/business-hour-and-weekend";


        // holiday settings
        public const string GetHolidaySettingName = "get_holiday_setting";
        public const string GetHolidaySettingUrl = "/api/admin/holiday-settings";
        public const string GetHolidaySettingByIdName = "get_holiday_setting_by_id";
        public const string GetHolidaySettingByIdUrl = "/api/admin/holiday-settings/{id}";
        public const string CreateHolidaySettingName = "create_holiday_setting";
        public const string CreateHolidaySettingUrl = "/api/admin/holiday-settings";
        public const string DeleteHolidaySettingName = "delete_holiday_setting";
        public const string DeleteHolidaySettingUrl = "/api/admin/holiday-settings/{id}";
        public const string UpdateHolidaySettingName = "update_holiday_setting";
        public const string UpdateHolidaySettingUrl = "/api/admin/holiday-settings";

        // institution 
        public const string GetInstitutionName = "get_institution";
        public const string GetInstitutionUrl = "/api/admin/institution";
        public const string GetInstitutionByIdName = "get_institution_by_id";
        public const string GetInstitutionByIdUrl = "/api/admin/institution/{id}";
        public const string CreateInstitutionName = "create_institution";
        public const string CreateInstitutionUrl = "/api/admin/institution";
        public const string DeleteInstitutionName = "delete_institution";
        public const string DeleteInstitutionUrl = "/api/admin/institution/{id}";
        public const string UpdateInstitutionName = "update_institution";
        public const string UpdateInstitutionUrl = "/api/admin/institution";

        // currency
        public const string GetCurrencyName = "get-currency";
        public const string GetCurrencyUrl = "/api/admin/Currency";
        public const string GetCurrencyByIdName = "get-currency-by-id";
        public const string GetCurrencyByIdUrl = "/api/admin/Currency/{id}";
        public const string CreateCurrencyName = "create-currency";
        public const string CreateCurrencyUrl = "/api/admin/Currency";
        public const string DeleteCurrencyName = "delete-currency";
        public const string DeleteCurrencyUrl = "/api/admin/Currency/{id}";
        public const string UpdateCurrencyName = "update-currency";
        public const string UpdateCurrencyUrl = "/api/admin/Currency/{id}";

        // region
      

        // corridor
        public const string GetCorridorName = "get-corridor";
        public const string GetCorridorUrl = "/api/admin/Corridor";
        public const string GetCorridorByIdName = "get-corridor-by-id";
        public const string GetCorridorByIdUrl = "/api/admin/Corridor/{id}";
        public const string CreateCorridorName = "create-corridor";
        public const string CreateCorridorUrl = "/api/admin/Corridor";
        public const string DeleteCorridorName = "delete-corridor";
        public const string DeleteCorridorUrl = "/api/admin/Corridor/{id}";
        public const string UpdateCorridorName = "update-corridor";
        public const string UpdateCorridorUrl = "/api/admin/Corridor/{id}";

        // payer
        public const string GetPayerName = "get-payer";
        public const string GetPayerUrl = "/api/admin/Payer";
        public const string GetPayerByIdName = "get-payer-by-id";
        public const string GetPayerByIdUrl = "/api/admin/Payer/{id}";
        public const string CreatePayerName = "create-payer";
        public const string CreatePayerUrl = "/api/admin/Payer";
        public const string DeletePayerName = "delete-payer";
        public const string DeletePayerUrl = "/api/admin/Payer/{id}";
        public const string UpdatePayerName = "update-payer";
        public const string UpdatePayerUrl = "/api/admin/Payer/{id}";

        // InstitutionMtt
        public const string GetInstitutionMttName = "get-institutionMtt";
        public const string GetInstitutionMttUrl = "/api/admin/InstitutionMtt";
        public const string GetInstitutionMttByIdName = "get-institutionMtt-by-id";
        public const string GetInstitutionMttByIdUrl = "/api/admin/InstitutionMtt/{id}";
        public const string CreateInstitutionMttName = "create-institutionMtt";
        public const string CreateInstitutionMttUrl = "/api/admin/InstitutionMtt";
        public const string DeleteInstitutionMttName = "delete-institutionMtt";
        public const string DeleteInstitutionMttUrl = "/api/admin/InstitutionMtt/{id}";
        public const string UpdateInstitutionMttName = "update-institutionMtt";
        public const string UpdateInstitutionMttUrl = "/api/admin/InstitutionMtt/{id}";

        // provider
        public const string GetProviderName = "get_provider";
        public const string GetProviderUrl = "/api/admin/provider";
        public const string GetProviderByIdName = "get_provider_by_id";
        public const string GetProviderByIdUrl = "/api/admin/provider/{id}";
        public const string CreateProviderName = "create_provider";
        public const string CreateProviderUrl = "/api/admin/provider";
        public const string DeleteProviderName = "delete_provider";
        public const string DeleteProviderUrl = "/api/admin/provider/{id}";
        public const string UpdateProviderName = "update_provider";
        public const string UpdateProviderUrl = "/api/admin/provider/{id}";

        // transaction_type
        public const string GetTransactionTypeName = "get_transaction_type";
        public const string GetTransactionTypeUrl = "/api/admin/transaction_type";
        public const string GetTransactionTypeByIdName = "get_transaction_type_by_id";
        public const string GetTransactionTypeByIdUrl = "/api/admin/transaction_type/{id}";
        public const string CreateTransactionTypeName = "create_transaction_type";
        public const string CreateTransactionTypeUrl = "/api/admin/transaction_type";
        public const string DeleteTransactionTypeName = "delete_transaction_type";
        public const string DeleteTransactionTypeUrl = "/api/admin/transaction_type/{id}";
        public const string UpdateTransactionTypeName = "update_transaction_type";
        public const string UpdateTransactionTypeUrl = "/api/admin/transaction_type/{id}";

        // mtt_payment_speed
        public const string GetMttPaymentSpeedName = "get_mtt_payment_speed";
        public const string GetMttPaymentSpeedUrl = "/api/admin/mtt_payment_speed";
        public const string GetMttPaymentSpeedByIdName = "get_mtt_payment_speed_by_id";
        public const string GetMttPaymentSpeedByIdUrl = "/api/admin/mtt_payment_speed/{id}";
        public const string CreateMttPaymentSpeedName = "create_mtt_payment_speed";
        public const string CreateMttPaymentSpeedUrl = "/api/admin/mtt_payment_speed";
        public const string DeleteMttPaymentSpeedName = "delete_mtt_payment_speed";
        public const string DeleteMttPaymentSpeedUrl = "/api/admin/mtt_payment_speed/{id}";
        public const string UpdateMttPaymentSpeedName = "update_mtt_payment_speed";
        public const string UpdateMttPaymentSpeedUrl = "/api/admin/mtt_payment_speed/{id}";


        // CreateMoneyTransferTransaction
        public const string CreateMoneyTransferTransactionName = "create_money_transaction";
        public const string CreateMoneyTransferTransactionUrl = "/v2/money-transfer/transaction/create";


        //Trasaction Limit
        public const string GetTransactionLimitName = "transaction_limit";
        public const string GetTransactionLimitUrl = "/api/admin/transactionlimits";
        public const string FindTransactionLimitByIdName = "transaction_limit_by_id";
        public const string FindTransactionLimitByIdUrl = "/api/admin/transactionlimits/{id}";
        public const string CreateTransactionLimitName = "create_transaction_limit";
        public const string CreateTransactionLimitUrl = "/api/admin/transactionlimits";
        public const string UpdateTransactionLimitName = "update_transaction_limit";
        public const string UpdateTransactionLimitUrl = "/api/admin/transactionlimits/{id}";
        public const string DeleteTransactionLimitName = "delete_transaction_limit";
        public const string DeleteTransactionLimitUrl = "/api/admin/transactionlimits/{id}";

    }

    public class AdminRoute
    {
        #region Mtts
        public const string CreateMttsRouteUrl = "/api/admin/mtts/create";
        public const string CreateMttsRouteName = "api.admin.mtts.create";

        public const string EditMttsRouteUrl = "/api/admin/mtts/edit/{id}";
        public const string EditMttsRouteName = "api.admin.mtts.edit";

        public const string ViewMttsRouteUrl = "/api/admin/mtts/view/{id}";
        public const string ViewMttsRouteName = "api.admin.mtts.view";

        public const string AllMttsRouteUrl = "/api/admin/mtts/get";
        public const string AllMttsRouteName = "api.admin.mtts.get";

        public const string DeleteMttsRouteUrl = "/api/admin/mtts/delete/{id}";
        public const string DeleteMttsRouteName = "api.admin.mtts.delete";
        #endregion Mtts
    }

    public class ImtRoute
    {
        #region Quotation
        public const string CreateQuotationRouteUrl = "/v1/money-transfer/quotation";
        public const string CreateQuotationRouteName = "money_transfer.quotation";
        #endregion Quotation
    }
}