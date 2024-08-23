namespace SharedKernel.Main.Application.Common.Constants
{
    public class AclRoutesUrl
    {
        public const string Base = "api/v1/";

        public class AclAuthRouteUrl
        {
            public const string Base = "api/v1/";
            public const string Login = Base + "login";
        }

        public class WeatherForecastRouteUrl
        {
            public const string GetWeatherForecast = "api/v1/GetWeatherForecast";
        }



        public class AclModuleRouteUrl
        {
            public const string List = Base + "modules";
            public const string Add = Base + "modules/add";
            public const string Edit = Base + "modules/edit";
            public const string View = Base + "modules/view/{id}";
            public const string Destroy = Base + "modules/delete/{id}";
        }
        public class AclCompanyRouteUrl
        {
            public const string ModelName = Base + "companies";
            public const string List = ModelName;
            public const string Add = ModelName + "/add";
            public const string Edit = ModelName + "/edit/{id}";
            public const string View = ModelName + "/view/{id}";
            public const string Destroy = ModelName + "/delete/{id}";
        }
        public class AclBranchRouteUrl
        {
            public const string ModelName = Base + "branches";
            public const string List = ModelName;
            public const string Add = ModelName + "/add";
            public const string Edit = ModelName + "/edit/{id}";
            public const string View = ModelName + "/view/{id}";
            public const string Destroy = ModelName + "/delete/{id}";
        }
        public class AclCompanyModuleRouteUrl
        {
            public const string ModelName = Base + "company/modules";
            public const string List = ModelName;
            public const string Add = ModelName + "/add";
            public const string Edit = ModelName + "/edit/{id}";
            public const string View = ModelName + "/view/{id}";
            public const string Destroy = ModelName + "/delete/{id}";
        }
        public class AclRolePageRouteUrl
        {
            public const string ModelName = Base + "roles/pages";
            public const string List = ModelName + "/{id}";
            public const string Edit = ModelName + "/update";
        }
        public class AclPageRouteUrl
        {
            public const string ModelName = Base + "pages";
            public const string List = ModelName;
            public const string Add = ModelName + "/add";
            public const string Edit = ModelName + "/edit";
            public const string View = ModelName + "/view/{id}";
            public const string Destroy = ModelName + "/delete/{id}";
        }
        public class AclPageRouteRouteUrl
        {
            public const string ModelName = Base + "page/routes";
            public const string List = ModelName;
            public const string Add = ModelName + "/add";
            public const string Edit = ModelName + "/edit/{id}";
            public const string Destroy = ModelName + "/delete/{id}";
        }
        public class AclSubmoduleRouteUrl
        {
            public const string ModelName = Base + "submodules";
            public const string List = ModelName;
            public const string Add = ModelName + "/add";
            public const string Edit = ModelName + "/edit";
            public const string View = ModelName + "/view/{id}";
            public const string Destroy = ModelName + "/delete/{id}";
        }
        public class AclRoleRouteUrl
        {
            public const string ModelName = Base + "roles";
            public const string List = ModelName;
            public const string Add = ModelName + "/add";
            public const string Edit = ModelName + "/edit/{id}";
            public const string View = ModelName + "/view/{id}";
            public const string Destroy = ModelName + "/delete/{id}";
        }
        public class AclUserGroupRoleRouteUrl
        {
            public const string ModelName = Base + "usergroups/roles";
            public const string List = ModelName + "/{userGroupId}";
            public const string Update = ModelName + "/update";
        }

        public class AclUserRouteUrl
        {
            public const string ModelName = Base + "users";
            public const string List = ModelName;
            public const string Add = ModelName + "/add";
            public const string Edit = ModelName + "/edit/{id}";
            public const string View = ModelName + "/view/{id}";
            public const string Destroy = ModelName + "/delete/{id}";
        }
        public class AclUserGroupRouteUrl
        {
            public const string ModelName = Base + "usergroups";
            public const string List = ModelName;
            public const string Add = ModelName + "/add";
            public const string View = ModelName + "/view/{id}";
            public const string Edit = ModelName + "/edit/{id}";
            public const string Destroy = ModelName + "/destroy/{id}";
        }
        public class AclPasswordRouteUrl
        {
            public const string ModelName = Base + "password";
            public const string Reset = ModelName + "/reset";
            public const string Forget = ModelName + "/forget";
            public const string VerifyToken = ModelName + "/forget/verify";

        }
        public class AclStateRouteUrl
        {
            public const string ModelName = Base + "states";
            public const string List = ModelName;
            public const string Add = ModelName + "/add";
            public const string View = ModelName + "/view/{id}";
            public const string Edit = ModelName + "/edit/{id}";
            public const string Destroy = ModelName + "/delete/{id}";

        }

        public class AclCountryRouteUrl
        {
            public const string ModelName = Base + "countries";
            public const string List = ModelName;
            public const string Add = ModelName + "/add";
            public const string Edit = ModelName + "/edit/{id}";
            public const string View = ModelName + "/view/{id}";
            public const string Destroy = ModelName + "/delete/{id}";
        }

    }
    public static class AclRoutesName
    {


        public static class AclAuthRouteNames
        {
            public const string Login = "acl.auth.login";
            public const string SignOut = "acl.auth.signout";
            public const string RefreshToken = "acl.auth.refreshToken";
            public const string CreateUser = "acl.auth.createUser";
        }

        public static class AclWeatherForecastRouteNames
        {
            public const string GetWeatherForecasts = "acl.weatherForecast.getWeatherForecasts";
        }

        public static class AclCompanyRouteNames
        {
            public const string List = "acl.company.list";
            public const string Add = "acl.company.add";
            public const string View = "acl.company.show";
            public const string Edit = "acl.company.edit";
            public const string Destroy = "acl.company.destroy";
        }
        public static class AclBranchRouteNames
        {
            public const string List = "acl.branch.list";
            public const string Add = "acl.branch.add";
            public const string View = "acl.branch.show";
            public const string Edit = "acl.branch.edit";
            public const string Destroy = "acl.branch.destroy";
        }

        public static class AclCompanyModuleRouteNames
        {
            public const string List = "acl.company_module.list";
            public const string Add = "acl.company_module.add";
            public const string View = "acl.company_module.view";
            public const string Edit = "acl.company_module.edit";
            public const string Destroy = "acl.company_module.destroy";
        }
        public static class AclModuleRouteNames
        {
            public const string List = "acl.module.list";
            public const string Add = "acl.module.add";
            public const string View = "acl.module.view";
            public const string Edit = "acl.module.edit";
            public const string Destroy = "acl.module.destroy";
        }
        public static class AclSubmoduleRouteNames
        {
            public const string List = "acl.submodule.list";
            public const string Add = "acl.submodule.add";
            public const string View = "acl.submodule.view";
            public const string Edit = "acl.submodule.edit";
            public const string Destroy = "acl.submodule.destroy";

        }
        public static class AclRoleRouteNames
        {
            public const string List = "acl.role.list";
            public const string Add = "acl.role.add";
            public const string View = "acl.role.view";
            public const string Edit = "acl.role.edit";
            public const string Destroy = "acl.role.destroy";

        }
        public static class AclRolePageRouteNames
        {
            public const string List = "acl.role&page.association";
            public const string Edit = "acl.role&page.association.update";
        }

        public static class AclPageNamesRouteNames
        {
            public const string Base = "acl.page.";
            public const string List = Base + "list";
            public const string Add = Base + "add";
            public const string View = Base + "view";
            public const string Edit = Base + "edit";
            public const string Destroy = Base + "destroy";
        }
        public static class AclPageRouteRouteNames
        {
            public const string Base = "acl.page.route.";
            public const string Add = Base + "add";
            public const string Edit = Base + "edit";
            public const string Destroy = Base + "destroy";
        }

        public static class AclUserRouteNames
        {
            public const string Base = "acl.user.";
            public const string List = Base + "list";
            public const string Add = Base + "add";
            public const string View = Base + "view";
            public const string Edit = Base + "edit";
            public const string Destroy = Base + "destroy";
        }

        public class AclUserGroupRoleRouteNames
        {
            public const string ModelName = "acl.usergroups.";
            public const string List = ModelName + "role.association";
            public const string Update = ModelName + "role.association.update";
        }
        public class AclUserGroupRouteNames
        {
            public const string ModelName = "acl.usergroups.";
            public const string List = ModelName + "list";
            public const string Add = ModelName + "add";
            public const string View = ModelName + "view";
            public const string Edit = ModelName + "edit";
            public const string Destroy = ModelName + "destroy";
        }

        public class AclPasswordRouteNames
        {
            public const string Reset = "acl.reset.password";
            public const string Forget = "acl.forget.password";
            public const string VerifyToken = "acl.verify.token.and.update.password";

        }
        public static class AclStateRouteNames
        {
            public const string Base = "acl.state.";
            public const string List = Base + "list";
            public const string Add = Base + "add";
            public const string View = Base + "view";
            public const string Edit = Base + "edit";
            public const string Destroy = Base + "destroy";
        }

        public class AclCountryRouteNames
        {
            public const string ModelName = "acl.countries.";
            public const string List = ModelName + "list";
            public const string Add = ModelName + "add";
            public const string View = ModelName + "view";
            public const string Edit = ModelName + "edit";
            public const string Destroy = ModelName + "destroy";
        }




    }

    public class Routes
    {
        public const string CreateEmailEventRouteName = "create-email-event";
        public const string CreateEmailEventRoute = "/api/notification/event/email/create";


        // Country
        public const string GetCountryName = "country";
        public const string GetCountryUrl = "/api/admin/country";
        public const string GetCountryByIdName = "country_by_id";
        public const string GetCountryByIdUrl = "/api/admin/country/{id}";
        public const string CreateCountryName = "create_country";
        public const string CreateCountryUrl = "/api/admin/country";
        public const string DeleteCountryName = "delete_country";
        public const string DeleteCountryUrl = "/api/admin/country/{id}";
        public const string UpdateCountryName = "update_country";
        public const string UpdateCountryUrl = "/api/admin/country";

        // Service Method
        public const string GetServiceMethodName = "service_method";
        public const string GetServiceMethodUrl = "/api/admin/service_method";
        public const string GetServiceMethodByIdName = "service_method_by_id";
        public const string GetServiceMethodByIdUrl = "/api/admin/service_method/{id}";
        public const string CreateServiceMethodName = "create_service_method";
        public const string CreateServiceMethodUrl = "/api/admin/service_method";
        public const string DeleteServiceMethodName = "delete_service_method";
        public const string DeleteServiceMethodUrl = "/api/admin/service_method/{id}";
        public const string UpdateServiceMethodName = "update_service_method";
        public const string UpdateServiceMethodUrl = "/api/admin/service_method";

        // Payer Payment Speed
        public const string GetPayerPaymentSpeedName = "payer_payment_speed";
        public const string GetPayerPaymentSpeedUrl = "/api/admin/payer_payment_speed";
        public const string GetPayerPaymentSpeedByIdName = "payer_payment_speed_by_id";
        public const string GetPayerPaymentSpeedByIdUrl = "/api/admin/payer_payment_speed/{id}";
        public const string CreatePayerPaymentSpeedName = "create_payer_payment_speed";
        public const string CreatePayerPaymentSpeedUrl = "/api/admin/payer_payment_speed";
        public const string DeletePayerPaymentSpeedName = "delete_payer_payment_speed";
        public const string DeletePayerPaymentSpeedUrl = "/api/admin/payer_payment_speed/{id}";
        public const string UpdatePayerPaymentSpeedName = "update_payer_payment_speed";
        public const string UpdatePayerPaymentSpeedUrl = "/api/admin/payer_payment_speed";


        // Business hour and weekend
        public const string GetBusinessHourAndWeekendName = "get_business_hour_and_weekend";
        public const string GetBusinessHourAndWeekendUrl = "/api/admin/business-hour-and-weekend";
        public const string GetBusinessHourAndWeekendByIdName = "get_business_hour_and_weekend_by_id";
        public const string GetBusinessHourAndWeekendByIdUrl = "/api/admin/business-hour-and-weekend/{id}";
        public const string CreateBusinessHourAndWeekendName = "create_business_hour_and_weekend";
        public const string CreateBusinessHourAndWeekendUrl = "/api/admin/business-hour-and-weekend";
        public const string DeleteBusinessHourAndWeekendName = "delete_business_hour_and_weekend";
        public const string DeleteBusinessHourAndWeekendUrl = "/api/admin/business-hour-and-weekend/{id}";
        public const string UpdateBusinessHourAndWeekendName = "update_business_hour_and_weekend";
        public const string UpdateBusinessHourAndWeekendUrl = "/api/admin/business-hour-and-weekend";


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


        // currency
        public const string GetCurrencyName = "get-currency";
        public const string GetCurrencyUrl = "/api/admin/getCurrency";
        public const string GetCurrencyByIdName = "get-currency-by-id";
        public const string GetCurrencyByIdUrl = "/api/admin/getCurrencyById/{id}";
        public const string CreateCurrencyName = "create-currency";
        public const string CreateCurrencyUrl = "/api/admin/createCurrency";
        public const string DeleteCurrencyName = "delete-currency";
        public const string DeleteCurrencyUrl = "/api/admin/deleteCurrency/{id}";
        public const string UpdateCurrencyName = "update-currency";
        public const string UpdateCurrencyUrl = "/api/admin/updateCurrency";

        // region
        public const string GetRegionName = "get_region";
        public const string GetRegionUrl = "/api/admin/region";
        public const string GetRegionByIdName = "get_regions_by_id";
        public const string GetRegionByIdUrl = "/api/admin/region/{id}";
        public const string CreateRegionName = "create_region";
        public const string CreateRegionUrl = "/api/admin/region";
        public const string DeleteRegionName = "delete_region";
        public const string DeleteRegionUrl = "/api/admin/region/{id}";
        public const string UpdateRegionName = "update_region";
        public const string UpdateRegionUrl = "/api/admin/region";

        public const string GetCorridorName = "get-corridor";
        public const string GetCorridorUrl = "/api/admin/getCorridor";
        public const string GetCorridorByIdName = "get-corridor-by-id";
        public const string GetCorridorByIdUrl = "/api/admin/getCorridorById/{id}";
        public const string CreateCorridorName = "create-corridor";
        public const string CreateCorridorUrl = "/api/admin/createCorridor";
        public const string DeleteCorridorName = "delete-corridor";
        public const string DeleteCorridorUrl = "/api/admin/deleteCorridor/{id}";
        public const string UpdateCorridorName = "update-corridor";
        public const string UpdateCorridorUrl = "/api/admin/updateCorridor";

        public const string GetPayerName = "get-payer";
        public const string GetPayerUrl = "/api/admin/getPayer";
        public const string GetPayerByIdName = "get-payer-by-id";
        public const string GetPayerByIdUrl = "/api/admin/getPayerById/{id}";
        public const string CreatePayerName = "create-payer";
        public const string CreatePayerUrl = "/api/admin/createPayer";
        public const string DeletePayerName = "delete-payer";
        public const string DeletePayerUrl = "/api/admin/deletePayer/{id}";
        public const string UpdatePayerName = "update-payer";
        public const string UpdatePayerUrl = "/api/admin/updatePayer";

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
        public const string UpdateProviderUrl = "/api/admin/provider";

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
        public const string UpdateTransactionTypeUrl = "/api/admin/transaction_type";
        public const string GetCorridorName = "get-corridor";
        public const string GetCorridorUrl = "/api/admin/getCorridor";
        public const string GetCorridorByIdName = "get-corridor-by-id";
        public const string GetCorridorByIdUrl = "/api/admin/getCorridorById/{id}";
        public const string CreateCorridorName = "create-corridor";
        public const string CreateCorridorUrl = "/api/admin/createCorridor";
        public const string DeleteCorridorName = "delete-corridor";
        public const string DeleteCorridorUrl = "/api/admin/deleteCorridor/{id}";
        public const string UpdateCorridorName = "update-corridor";
        public const string UpdateCorridorUrl = "/api/admin/updateCorridor";

        public const string GetPayerName = "get-payer";
        public const string GetPayerUrl = "/api/admin/getPayer";
        public const string GetPayerByIdName = "get-payer-by-id";
        public const string GetPayerByIdUrl = "/api/admin/getPayerById/{id}";
        public const string CreatePayerName = "create-payer";
        public const string CreatePayerUrl = "/api/admin/createPayer";
        public const string DeletePayerName = "delete-payer";
        public const string DeletePayerUrl = "/api/admin/deletePayer/{id}";
        public const string UpdatePayerName = "update-payer";
        public const string UpdatePayerUrl = "/api/admin/updatePayer";

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
}